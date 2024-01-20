using Microsoft.AspNetCore.Mvc;
using QuillQuest.DataAccess.Repository.Interface;
using QuillQuest.Models.ViewModels;
using System.Security.Claims;
using QuillQuest.Utilities;
using QuillQuest.Models.Enums;
using QuillQuest.Models.Models;
using Stripe.Checkout;

namespace QuillQuestWeb.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class CartController : Controller
    {
        [BindProperty]
        public ShoppingCartVM ShoppingCartVm { get; set; }
        private readonly IUnitOfWork _unitOfWork;

        public CartController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
            var carts = _unitOfWork.ShoppingCartRepository.GetAll(c => c.ApplicationUserId == userId, includeProperties: "Product");

            ShoppingCartVm = new()
            {
                ShoppingCarts = carts,
                OrderHeader = new()
            };

            foreach (var cart in carts)
            {
                cart.Price = OrderTotalCalculator.GetPriceBasedOnQuantity(cart);
                ShoppingCartVm.OrderHeader.OrderTotal += (cart.Price * cart.Count);

            }
            return View(ShoppingCartVm);
        }

        public IActionResult Summary()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
            var carts = _unitOfWork.ShoppingCartRepository.GetAll(c => c.ApplicationUserId == userId, includeProperties: "Product");

            ShoppingCartVm = new()
            {
                ShoppingCarts = carts,
                OrderHeader = new()
            };

            ShoppingCartVm.OrderHeader.ApplicationUser = _unitOfWork.ApplicationUserRepository.Get(u => u.Id == userId);

            ShoppingCartVm.OrderHeader.Name = ShoppingCartVm.OrderHeader.ApplicationUser.Name;
            ShoppingCartVm.OrderHeader.PhoneNumber = ShoppingCartVm.OrderHeader.ApplicationUser.PhoneNumber;
            ShoppingCartVm.OrderHeader.StreetAddress = ShoppingCartVm.OrderHeader.ApplicationUser.StreetAddress;
            ShoppingCartVm.OrderHeader.City = ShoppingCartVm.OrderHeader.ApplicationUser.City;
            ShoppingCartVm.OrderHeader.State = ShoppingCartVm.OrderHeader.ApplicationUser.State;
            ShoppingCartVm.OrderHeader.PostalCode = ShoppingCartVm.OrderHeader.ApplicationUser.PostalCode;

            foreach (var cart in carts)
            {
                cart.Price = OrderTotalCalculator.GetPriceBasedOnQuantity(cart);
                ShoppingCartVm.OrderHeader.OrderTotal += (cart.Price * cart.Count);

            }
            return View(ShoppingCartVm);
        }

        [HttpPost]
        [ActionName("Summary")]
        public IActionResult SummaryPOST()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
            var carts = _unitOfWork.ShoppingCartRepository.GetAll(c => c.ApplicationUserId == userId, includeProperties: "Product");

            ShoppingCartVm.ShoppingCarts = carts;
            ShoppingCartVm.OrderHeader.OrderDate = DateTime.Now;
            ShoppingCartVm.OrderHeader.ApplicationUserId = userId;

            ApplicationUser applicationUser = _unitOfWork.ApplicationUserRepository.Get(u => u.Id == userId);

            foreach (var cart in carts)
            {
                cart.Price = OrderTotalCalculator.GetPriceBasedOnQuantity(cart);
                ShoppingCartVm.OrderHeader.OrderTotal += (cart.Price * cart.Count);

            }

            if (applicationUser.CompanyId.GetValueOrDefault() == Guid.Empty)
            {
                // Apply regular customer payment rules
                ShoppingCartVm.OrderHeader.OrderStatus = OrderStatusEnum.Pending;
                ShoppingCartVm.OrderHeader.PaymentStatus = PaymentStatusEnum.Pending;

            }
            else
            {
                // Apply company user payment rules
                ShoppingCartVm.OrderHeader.OrderStatus = OrderStatusEnum.Approved;
                ShoppingCartVm.OrderHeader.PaymentStatus = PaymentStatusEnum.ApprovedForDelayedPayment;
            }

            _unitOfWork.OrderHeaderRepository.Add(ShoppingCartVm.OrderHeader);
            _unitOfWork.Save();

            foreach (var cart in ShoppingCartVm.ShoppingCarts)
            {
                OrderDetail orderDetail = new()
                {
                    Id = Guid.NewGuid(),
                    ProductId = cart.ProductId,
                    OrderHeaderId = ShoppingCartVm.OrderHeader.Id,
                    Price = cart.Price,
                    Count = cart.Count
                };

                _unitOfWork.OrderDetailRepository.Add(orderDetail);
                _unitOfWork.Save();
            }

            if (applicationUser.CompanyId.GetValueOrDefault() == Guid.Empty)
            {
                // Apply regular customer payment rules
                // Stripe logic
                var domain = "https://localhost:7181/";
                var options = new SessionCreateOptions
                {
                    SuccessUrl = $"{domain}customer/cart/OrderConfirmation?id={ShoppingCartVm.OrderHeader.Id}",
                    CancelUrl = $"{domain}customer/cart/summary",
                    LineItems = new List<SessionLineItemOptions>(),
                    Mode = "payment",
                };

                foreach(var item in ShoppingCartVm.ShoppingCarts)
                {
                    var sessionLineItems = new SessionLineItemOptions
                    {
                        PriceData = new SessionLineItemPriceDataOptions
                        {
                            UnitAmount = (long)(item.Price * 100), // $20.50 => 2050
                            Currency = "usd",
                            ProductData = new SessionLineItemPriceDataProductDataOptions
                            {
                                Name = item.Product.Title
                            }
                        },
                        Quantity = item.Count
                    };
                    options.LineItems.Add(sessionLineItems);
                }
                var service = new SessionService();
                Session session = service.Create(options);
                _unitOfWork.OrderHeaderRepository.UpdateStripePaymentId(ShoppingCartVm.OrderHeader.Id, session.Id, session.PaymentIntentId);
                _unitOfWork.Save();
                Response.Headers.Add("Location", session.Url);
                return new StatusCodeResult(303);
            }

            return RedirectToAction(nameof(OrderConfirmation), new { id = ShoppingCartVm.OrderHeader.Id });
        }

        public IActionResult OrderConfirmation(Guid id)
        {
            OrderHeader orderHeader = _unitOfWork.OrderHeaderRepository.Get(o => o.Id == id, includeProperties: "ApplicationUser");

            if (orderHeader.PaymentStatus != PaymentStatusEnum.ApprovedForDelayedPayment)
            {
                // This is an order by customer
                var service = new SessionService();
                Session session = service.Get(orderHeader.SessionId);
                if (session.PaymentStatus.ToLower() == "paid")
                {
                    _unitOfWork.OrderHeaderRepository.UpdateStripePaymentId(id, session.Id, session.PaymentIntentId);
                    _unitOfWork.OrderHeaderRepository.UpdateStatus(id, OrderStatusEnum.Approved, PaymentStatusEnum.Approved);
                    _unitOfWork.Save();
                }
            }

            List<ShoppingCart>shoppingCarts = _unitOfWork.ShoppingCartRepository.
                GetAll(c => c.ApplicationUserId == orderHeader.ApplicationUserId).ToList();
            _unitOfWork.ShoppingCartRepository.RemoveRange(shoppingCarts);
            _unitOfWork.Save();

            return View(id);
        }

        public IActionResult Plus(Guid cartId)
        {
            var cartDb = _unitOfWork.ShoppingCartRepository.Get(c => c.Id == cartId);
            cartDb.Count += 1;
            _unitOfWork.Save();
            var currentCartSum = _unitOfWork.ShoppingCartRepository.GetAll(c => c.ApplicationUserId == cartDb.ApplicationUserId).Select(c => c.Count).Sum();
            HttpContext.Session.SetInt32(SD.SessionCart, currentCartSum);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Minus(Guid cartId)
        {
            var cartDb = _unitOfWork.ShoppingCartRepository.Get(c => c.Id == cartId);
            if (cartDb.Count <= 1)
            {
                // Remove item from cart
                _unitOfWork.ShoppingCartRepository.Remove(cartDb);
            }
            else
            {
                cartDb.Count -= 1;

            }
            _unitOfWork.Save();

            var currentCartSum = _unitOfWork.ShoppingCartRepository.GetAll(c => c.ApplicationUserId == cartDb.ApplicationUserId).Select(c => c.Count).Sum();
            HttpContext.Session.SetInt32(SD.SessionCart, currentCartSum);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Remove(Guid cartId)
        {
            var cartDb = _unitOfWork.ShoppingCartRepository.Get(c => c.Id == cartId);
            _unitOfWork.ShoppingCartRepository.Remove(cartDb);
            _unitOfWork.Save();
            var currentCartSum = _unitOfWork.ShoppingCartRepository.GetAll(c => c.ApplicationUserId == cartDb.ApplicationUserId).Select(c => c.Count).Sum();
            HttpContext.Session.SetInt32(SD.SessionCart, currentCartSum);

            return RedirectToAction(nameof(Index));
        }
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using QuillQuest.DataAccess.Repository.Interface;
using QuillQuest.Models.Enums;
using QuillQuest.Models.Models;
using QuillQuest.Models.ViewModels;
using QuillQuest.Utilities;
using Stripe;
using Stripe.Checkout;
using System.Diagnostics;
using System.Security.Claims;

namespace QuillQuestWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class OrderController : Controller
    {
        [BindProperty]
        public OrderVM OrderVm { get; set; }
        private readonly IUnitOfWork _unitOfWork;

        public OrderController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Details(string orderId)
        {
            var orderGuid = Guid.Parse(orderId);
            OrderVm = new()
            {
                OrderHeader = _unitOfWork.OrderHeaderRepository.Get(o => o.Id == orderGuid, includeProperties: "ApplicationUser"),
                OrderDetails = _unitOfWork.OrderDetailRepository.GetAll(o => o.OrderHeaderId == orderGuid, includeProperties: "Product")
            };

            return View(OrderVm);
        }

        [HttpPost]
        [Authorize(Roles = SD.Role_Admin + "," + SD.Role_Employee)]
        public IActionResult UpdateOrderDetail()
        {
            var orderHeaderDb = _unitOfWork.OrderHeaderRepository.Get(o => o.Id == OrderVm.OrderHeader.Id);

            orderHeaderDb.Name = OrderVm.OrderHeader.Name;
            orderHeaderDb.PhoneNumber = OrderVm.OrderHeader.PhoneNumber;
            orderHeaderDb.StreetAddress = OrderVm.OrderHeader.StreetAddress;
            orderHeaderDb.City = OrderVm.OrderHeader.City;
            orderHeaderDb.State = OrderVm.OrderHeader.State;
            orderHeaderDb.PostalCode = OrderVm.OrderHeader.PostalCode;
            if (!string.IsNullOrEmpty(OrderVm.OrderHeader.Carrier))
            {
                orderHeaderDb.Carrier = OrderVm.OrderHeader.Carrier;
            }
            if (!string.IsNullOrEmpty(OrderVm.OrderHeader.TrackingNumber))
            {
                orderHeaderDb.Carrier = OrderVm.OrderHeader.TrackingNumber;
            }
            _unitOfWork.OrderHeaderRepository.Update(orderHeaderDb);
            _unitOfWork.Save();

            TempData["Success"] = "Order Details Updated Successfully.";


            return RedirectToAction(nameof(Details), new { orderId = orderHeaderDb.Id });
        }

        [HttpPost]
        [Authorize(Roles = SD.Role_Admin + "," + SD.Role_Employee)]
        public IActionResult StartProcessing()
        {
            _unitOfWork.OrderHeaderRepository.UpdateStatus(OrderVm.OrderHeader.Id, OrderStatusEnum.Processing);
            _unitOfWork.Save();
            TempData["Success"] = "Order Details Updated Successfully.";


            return RedirectToAction(nameof(Details), new { orderId = OrderVm.OrderHeader.Id });
        }

        [HttpPost]
        [Authorize(Roles = SD.Role_Admin + "," + SD.Role_Employee)]
        public IActionResult ShipOrder()
        {
            var orderHeader = _unitOfWork.OrderHeaderRepository.Get(o => o.Id == OrderVm.OrderHeader.Id);
            orderHeader.TrackingNumber = OrderVm.OrderHeader.TrackingNumber;
            orderHeader.Carrier = OrderVm.OrderHeader.Carrier;
            orderHeader.OrderStatus = OrderStatusEnum.Shipped;
            orderHeader.ShippingDate = DateTime.Now;

            if (orderHeader.PaymentStatus == PaymentStatusEnum.ApprovedForDelayedPayment)
            {
                orderHeader.PaymentDueDate = DateOnly.FromDateTime(DateTime.Now.AddDays(30));
            }

            _unitOfWork.OrderHeaderRepository.Update(orderHeader);

            _unitOfWork.Save();
            TempData["Success"] = "Order Shipped Successfully.";

            return RedirectToAction(nameof(Details), new { orderId = OrderVm.OrderHeader.Id });
        }

        [HttpPost]
        [Authorize(Roles = SD.Role_Admin + "," + SD.Role_Employee)]
        public IActionResult CancelOrder()
        {
            var orderHeader = _unitOfWork.OrderHeaderRepository.Get(o => o.Id == OrderVm.OrderHeader.Id);
            if (orderHeader.PaymentStatus == PaymentStatusEnum.Approved)
            {
                var options = new RefundCreateOptions
                {
                    Reason=RefundReasons.RequestedByCustomer,
                    PaymentIntent = orderHeader.PaymentIntentId,
                };

                var service = new RefundService();
                Refund refund = service.Create(options);

                _unitOfWork.OrderHeaderRepository.UpdateStatus(orderHeader.Id, OrderStatusEnum.Cancelled, PaymentStatusEnum.Refunded);
            }
            else
            {
                _unitOfWork.OrderHeaderRepository.UpdateStatus(orderHeader.Id, OrderStatusEnum.Cancelled, PaymentStatusEnum.Cancelled);
            }

            _unitOfWork.Save();
            TempData["Success"] = "Order Cancelled Successfully.";

            return RedirectToAction(nameof(Details), new { orderId = OrderVm.OrderHeader.Id });
        }

        [HttpPost]
        [ActionName("Details")]
        [Authorize(Roles = SD.Role_Admin + "," + SD.Role_Employee)]
        public IActionResult DetailsPayNow()
        {
            OrderVm.OrderHeader = _unitOfWork.OrderHeaderRepository.Get(o => o.Id == OrderVm.OrderHeader.Id, includeProperties: "ApplicationUser");
            OrderVm.OrderDetails = _unitOfWork.OrderDetailRepository.GetAll(o => o.Id == OrderVm.OrderHeader.Id, includeProperties: "Product");

            // Stripe logic
            var domain = "https://localhost:7181/";
            var options = new SessionCreateOptions
            {
                SuccessUrl = $"{domain}customer/order/PaymentConfirmation?orderHeaderId={OrderVm.OrderHeader.Id}",
                CancelUrl = $"{domain}customer/order/details?orderId={OrderVm.OrderHeader.Id}",
                LineItems = new List<SessionLineItemOptions>(),
                Mode = "payment",
            };

            foreach (var item in OrderVm.OrderDetails)
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
            _unitOfWork.OrderHeaderRepository.UpdateStripePaymentId(OrderVm.OrderHeader.Id, session.Id, session.PaymentIntentId);
            _unitOfWork.Save();
            Response.Headers.Add("Location", session.Url);
            return new StatusCodeResult(303);
        }

        public IActionResult PaymentConfirmation(Guid orderHeaderId)
        {
            OrderHeader orderHeader = _unitOfWork.OrderHeaderRepository.Get(o => o.Id == orderHeaderId);

            if (orderHeader.PaymentStatus != PaymentStatusEnum.ApprovedForDelayedPayment)
            {
                // This is an order by company
                var service = new SessionService();
                Session session = service.Get(orderHeader.SessionId);
                if (session.PaymentStatus.ToLower() == "paid")
                {
                    _unitOfWork.OrderHeaderRepository.UpdateStripePaymentId(orderHeaderId, session.Id, session.PaymentIntentId);
                    _unitOfWork.OrderHeaderRepository.UpdateStatus(orderHeaderId, orderHeader.OrderStatus.Value, PaymentStatusEnum.Approved);
                    _unitOfWork.Save();
                }
            }

            return View(orderHeaderId);
        }

        #region API Calls

        [HttpGet]
        public IActionResult GetAll(string status)
        {
            IEnumerable<OrderHeader> orderHeaders;

            if (User.IsInRole(SD.Role_Admin) || User.IsInRole(SD.Role_Employee))
            {
                orderHeaders = _unitOfWork.OrderHeaderRepository.GetAll(includeProperties: "ApplicationUser").ToList();
            }
            else
            {
                var claimsIdentity = (ClaimsIdentity)User.Identity;
                var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
                orderHeaders = _unitOfWork.OrderHeaderRepository.GetAll(o => o.ApplicationUserId == userId, includeProperties: "ApplicationUser").ToList();
            }

            switch (status)
            {
                case "pending":
                    orderHeaders = orderHeaders.Where(o => o.OrderStatus == OrderStatusEnum.Pending);
                    break;
                case "inprocess":
                    orderHeaders = orderHeaders.Where(o => o.OrderStatus == OrderStatusEnum.Processing);
                    break;
                case "completed":
                    orderHeaders = orderHeaders.Where(o => o.OrderStatus == OrderStatusEnum.Shipped);
                    break;
                case "approved":
                    orderHeaders = orderHeaders.Where(o => o.OrderStatus == OrderStatusEnum.Approved);
                    break;
                default:
                    break;
            }
            return Json(new { data = orderHeaders });
        }

        #endregion
    }
}

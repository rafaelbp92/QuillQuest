using Microsoft.AspNetCore.Mvc;
using QuillQuest.DataAccess.Repository.Interface;
using QuillQuest.Models.ViewModels;
using System.Security.Claims;
using QuillQuest.Utilities;

namespace QuillQuestWeb.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class CartController : Controller
    {
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

            ShoppingCartVM shoppingCartVm = new()
            {
                ShoppingCarts = carts,
            };

            foreach (var cart in carts)
            {
                cart.Price = OrderTotalCalculator.GetPriceBasedOnQuantity(cart);
                shoppingCartVm.OrderTotal += (cart.Price * cart.Count);

            }
            return View(shoppingCartVm);
        }

        public IActionResult Summary()
        {
            return View();
        }

        public IActionResult Plus(Guid cartId)
        {
            var cartDb = _unitOfWork.ShoppingCartRepository.Get(c => c.Id == cartId);
            cartDb.Count += 1;
            _unitOfWork.Save();
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

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Remove(Guid cartId)
        {
            var cartDb = _unitOfWork.ShoppingCartRepository.Get(c => c.Id == cartId);
            _unitOfWork.ShoppingCartRepository.Remove(cartDb);
            _unitOfWork.Save();

            return RedirectToAction(nameof(Index));
        }
    }
}

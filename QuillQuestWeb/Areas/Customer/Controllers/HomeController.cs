using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuillQuest.DataAccess.Repository.Interface;
using QuillQuest.Models.Models;
using QuillQuest.Utilities;
using System.Diagnostics;
using System.Security.Claims;

namespace QuillQuestWeb.Areas.Customer.Controllers
{

    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            if (claim.Value != null)
            {
                var currentCartSum = _unitOfWork.ShoppingCartRepository.GetAll(c => c.ApplicationUserId == claim.Value).Select(c => c.Count).Sum();
                HttpContext.Session.SetInt32(SD.SessionCart, currentCartSum);
            }

            IEnumerable<Product> productList = _unitOfWork.ProductRepository.GetAll(includeProperties: "Category");
            return View(productList);
        }

        public IActionResult Details(Guid? id)
        {
            ShoppingCart cart = new ShoppingCart();
            Product product = _unitOfWork.ProductRepository.Get(p => p.Id == id, includeProperties: "Category");
            cart.Product = product;
            cart.ProductId = product.Id;
            return View(cart);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Details(ShoppingCart cart)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
            cart.ApplicationUserId = userId;

            ShoppingCart cartDb = _unitOfWork.ShoppingCartRepository.Get(c => c.ApplicationUserId == userId &&
                c.ProductId == cart.ProductId, tracked: false);

            if (cartDb != null)
            {
                // Update cart
                cartDb.Count += cart.Count;
                _unitOfWork.ShoppingCartRepository.Update(cartDb);           
            }
            else
            {
                // Add cart
                _unitOfWork.ShoppingCartRepository.Add(cart);
            }

            _unitOfWork.Save();

            var currentCartSum = _unitOfWork.ShoppingCartRepository.GetAll(c => c.ApplicationUserId == userId).Select(c => c.Count).Sum();
            HttpContext.Session.SetInt32(SD.SessionCart, currentCartSum);

            TempData["sucess"] = "Cart updated sucessfully";
           
            
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

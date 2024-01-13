using Microsoft.AspNetCore.Mvc;
using QuillQuest.DataAccess.Repository.Interface;
using QuillQuest.Models.Models;

namespace QuillQuestWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _repository;
        public ProductController(IUnitOfWork repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            List<Product> products = _repository.ProductRepository.GetAll().ToList();
            return View(products);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                _repository.ProductRepository.Add(product);
                TempData["success"] = "Product created successfully";
                _repository.Save();
                return RedirectToAction("Index");
            }

            return View();
        }

        public IActionResult Edit(Guid? id)
        {
            if (id == null || id == Guid.Empty)
            {
                return NotFound();
            }
            Product? product = _repository.ProductRepository.Get(c => c.Id == id);

            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                _repository.ProductRepository.Update(product);
                _repository.Save();
                TempData["success"] = "Product updated successfully";
                return RedirectToAction("Index");
            }

            return View();
        }

        public IActionResult Delete(Guid? id)
        {
            if (id == null || id == Guid.Empty)
            {
                return NotFound();
            }
            Product? product = _repository.ProductRepository.Get(c => c.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(Guid? id)
        {
            Product? product = _repository.ProductRepository.Get(c => c.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            _repository.ProductRepository.Remove(product);
            _repository.Save();
            TempData["success"] = "Product deleted successfully";
            return RedirectToAction("Index");
        }
    }
}

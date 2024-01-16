using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using QuillQuest.DataAccess.Repository.Interface;
using QuillQuest.Models.Models;
using QuillQuest.Models.ViewModels;
using QuillQuest.Utilities;

namespace QuillQuestWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _repository;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ProductController(IUnitOfWork repository, IWebHostEnvironment webHostEnvironment)
        {
            _repository = repository;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            List<Product> products = _repository.ProductRepository.GetAll(includeProperties: "Category").ToList();
            return View(products);
        }
        public IActionResult Upsert(Guid? id)
        {
            IEnumerable<SelectListItem> categories = _repository.CategoryRepository.GetAll().Select(c => new SelectListItem
            {
                Text = c.Name,
                Value = c.Id.ToString()
            });
            ProductVM productVM = new()
            {
                Product = new Product
                {
                    Author = "",
                    Title = "",
                    ISBN = "",
                    ImageUrl = null,
                    ListPrice = 0,
                    Price = 0,
                    Price50 = 0,
                    Price100 = 0,
                },
                Categories = categories
            };
            if (id == null || id == Guid.Empty)
            {
                //Create
                return View(productVM);
            }
            else
            {
                //Update
                Product? product = _repository.ProductRepository.Get(c => c.Id == id);

                if (product == null)
                {
                    return NotFound();
                }
                productVM.Product = product;
                return View(productVM);
            }

        }

        [HttpPost]
        public IActionResult Upsert(ProductVM productVM, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                string wwwRootpath = _webHostEnvironment.WebRootPath;
                string successMessage = "Product created successfully";

                if (file != null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string productPath = Path.Combine(wwwRootpath, @"images\product");

                    if (!string.IsNullOrEmpty(productVM.Product.ImageUrl))
                    {
                        // Delete old image
                        var oldImagePath = Path.Combine(wwwRootpath, productVM.Product.ImageUrl.TrimStart('\\'));
                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }

                    using (var fileStream = new FileStream(Path.Combine(productPath, fileName), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }

                    productVM.Product.ImageUrl = @$"\images\product\{fileName}";
                }

                if (productVM.Product.Id == Guid.Empty)
                {
                    // Create
                    _repository.ProductRepository.Add(productVM.Product);
                }
                else
                {
                    // Update
                    _repository.ProductRepository.Update(productVM.Product);
                    successMessage = "Product updated successfully";
                }

                _repository.Save();
                TempData["success"] = successMessage;
                return RedirectToAction("Index");
            }

            return View();
        }

        //public IActionResult Edit(Guid? id)
        //{
        //    if (id == null || id == Guid.Empty)
        //    {
        //        return NotFound();
        //    }
        //    Product? product = _repository.ProductRepository.Get(c => c.Id == id);

        //    if (product == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(product);
        //}

        //[HttpPost]
        //public IActionResult Edit(Product product)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _repository.ProductRepository.Update(product);
        //        _repository.Save();
        //        TempData["success"] = "Product updated successfully";
        //        return RedirectToAction("Index");
        //    }

        //    return View();
        //}

        //public IActionResult Delete(Guid? id)
        //{
        //    if (id == null || id == Guid.Empty)
        //    {
        //        return NotFound();
        //    }
        //    Product? product = _repository.ProductRepository.Get(c => c.Id == id);
        //    if (product == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(product);
        //}

        //[HttpPost, ActionName("Delete")]
        //public IActionResult DeletePost(Guid? id)
        //{
        //    Product? product = _repository.ProductRepository.Get(c => c.Id == id);
        //    if (product == null)
        //    {
        //        return NotFound();
        //    }
        //    _repository.ProductRepository.Remove(product);
        //    _repository.Save();
        //    TempData["success"] = "Product deleted successfully";
        //    return RedirectToAction("Index");
        //}

        #region API Calls

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Product> products = _repository.ProductRepository.GetAll(includeProperties: "Category").ToList();
            return Json(new { data = products });
        }

        [HttpDelete]
        public IActionResult Delete(Guid? id)
        {
            Product productDelete = _repository.ProductRepository.Get(p => p.Id == id);
            if (productDelete == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }

			if (!string.IsNullOrEmpty(productDelete.ImageUrl))
            {
				string wwwRootpath = _webHostEnvironment.WebRootPath;
				// Delete old image
				var oldImagePath = Path.Combine(wwwRootpath, productDelete.ImageUrl.TrimStart('\\'));
				if (System.IO.File.Exists(oldImagePath))
				{
					System.IO.File.Delete(oldImagePath);
				}
			}

			_repository.ProductRepository.Remove(productDelete);
			_repository.Save();
            return Json(new { success = true, message = "Product deleted successfully" });

		}

        #endregion
    }
}

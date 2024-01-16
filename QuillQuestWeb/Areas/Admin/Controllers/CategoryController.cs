using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuillQuest.DataAccess.Repository.Interface;
using QuillQuest.Models.Models;
using QuillQuest.Utilities;

namespace QuillQuestWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles  = SD.Role_Admin)]
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _repository;
        public CategoryController(IUnitOfWork repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            List<Category> categories = _repository.CategoryRepository.GetAll().ToList();
            return View(categories);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                _repository.CategoryRepository.Add(category);
                TempData["success"] = "Category created successfully";
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
            Category? category = _repository.CategoryRepository.Get(c => c.Id == id);
            //Category? category = context.Categories.FirstOrDefault(c => c.Id == id);
            //Category? category = context.Categories.Where(c => c.Id == id).FirstOrDefault();
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        [HttpPost]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                _repository.CategoryRepository.Update(category);
                _repository.Save();
                TempData["success"] = "Category updated successfully";
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
            Category? category = _repository.CategoryRepository.Get(c => c.Id == id);
            //Category? category = context.Categories.FirstOrDefault(c => c.Id == id);
            //Category? category = context.Categories.Where(c => c.Id == id).FirstOrDefault();
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(Guid? id)
        {
            Category? category = _repository.CategoryRepository.Get(c => c.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            _repository.CategoryRepository.Remove(category);
            _repository.Save();
            TempData["success"] = "Category deleted successfully";
            return RedirectToAction("Index");
        }
    }
}

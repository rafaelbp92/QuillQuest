using Microsoft.AspNetCore.Mvc;
using QuillQuest.DataAccess.Data;
using QuillQuest.Models.Models;

namespace QuillQuestWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly QuillQuestDbContext context;
        public CategoryController(QuillQuestDbContext _context)
        {
            context = _context;
        }

        public IActionResult Index()
        {
            List<Category> categories = context.Categories.ToList();
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
				context.Categories.Add(category);
				context.SaveChanges();
				TempData["success"] = "Category created successfully";
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
			Category? category = context.Categories.Find(id);
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
				context.Categories.Update(category);
				context.SaveChanges();
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
			Category? category = context.Categories.Find(id);
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
			Category? category = context.Categories.Find(id);
			if (category == null)
			{
				return NotFound();
			}
			context.Categories.Remove(category);
			context.SaveChanges();
            TempData["success"] = "Category deleted successfully";
            return RedirectToAction("Index");
		}
	}
}

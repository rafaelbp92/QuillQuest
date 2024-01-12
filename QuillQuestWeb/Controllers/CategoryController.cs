using Microsoft.AspNetCore.Mvc;
using QuillQuestWeb.Data;
using QuillQuestWeb.Models;

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
            context.Categories.Add(category);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

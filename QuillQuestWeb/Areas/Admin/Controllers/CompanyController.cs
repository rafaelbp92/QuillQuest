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
    public class CompanyController : Controller
    {
        private readonly IUnitOfWork _repository;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public CompanyController(IUnitOfWork repository, IWebHostEnvironment webHostEnvironment)
        {
            _repository = repository;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            List<Company> companies = _repository.CompanyRepository.GetAll().ToList();
            return View(companies);
        }
        public IActionResult Upsert(Guid? id)
        {
            Company company = new()
            {
                Name = ""

            };
            if (id == null || id == Guid.Empty)
            {
                //Create
                return View(company);
            }
            else
            {
                //Update
                Company? companyDb = _repository.CompanyRepository.Get(c => c.Id == id);

                if (companyDb == null)
                {
                    return NotFound();
                }
                return View(companyDb);
            }

        }

        [HttpPost]
        public IActionResult Upsert(Company company)
        {
            string successMessage = "Company ceated successfully";

            if (ModelState.IsValid)
            {

                if (company.Id == Guid.Empty)
                {
                    // Create
                    _repository.CompanyRepository.Add(company);
                }
                else
                {
                    // Update
                    _repository.CompanyRepository.Update(company);
                    successMessage = "Company updated successfully";
                }

                _repository.Save();
                TempData["success"] = successMessage;
                return RedirectToAction("Index");
            }

            return View();
        }

        #region API Calls

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Company> companies = _repository.CompanyRepository.GetAll().ToList();
            return Json(new { data = companies });
        }

        [HttpDelete]
        public IActionResult Delete(Guid? id)
        {
            Company companyDelete = _repository.CompanyRepository.Get(p => p.Id == id);
            if (companyDelete == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }

            _repository.CompanyRepository.Remove(companyDelete);
            _repository.Save();
            return Json(new { success = true, message = "Company deleted successfully" });

        }

        #endregion
    }
}

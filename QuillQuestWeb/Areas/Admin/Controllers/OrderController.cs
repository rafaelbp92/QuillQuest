using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using QuillQuest.DataAccess.Repository.Interface;
using QuillQuest.Models.Models;
using QuillQuest.Utilities;

namespace QuillQuestWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class OrderController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrderController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }

        #region API Calls

        [HttpGet]
        public IActionResult GetAll()
        {
            List<OrderHeader> orderHeaders = _unitOfWork.OrderHeaderRepository.GetAll(includeProperties: "ApplicationUser").ToList();
            return Json(new { data = orderHeaders });
        }

        #endregion
    }
}

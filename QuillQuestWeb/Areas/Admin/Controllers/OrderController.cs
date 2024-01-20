using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using QuillQuest.DataAccess.Repository.Interface;
using QuillQuest.Models.Enums;
using QuillQuest.Models.Models;
using QuillQuest.Models.ViewModels;
using QuillQuest.Utilities;
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
        [Authorize(Roles = SD.Role_Admin + "," +SD.Role_Employee)]
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
                orderHeaders = _unitOfWork.OrderHeaderRepository.GetAll(o => o.ApplicationUserId == userId ,includeProperties: "ApplicationUser").ToList();
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
					orderHeaders= orderHeaders.Where(o => o.OrderStatus == OrderStatusEnum.Shipped);
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using PagedList;
using RentABike.Logic;
using RentABike.Logic.Interfaces;
using RentABike.Models.Constants;
using RentABike.ViewModels;

namespace RentABike.Website.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly IBikeTypeService _bikeTypeService;

        private readonly IRentPointService _rentPointService;

        private readonly IBikeService _bikeService;

        private readonly ITarriffService _tarriffService;

        private readonly IOrderService _orderService;

        private readonly IStatusService _statusService;

        private string UserId => User.Identity.GetUserId();

        private ApplicationUserManager _userManager;


        public OrderController(IRentPointService rentPointService, IBikeTypeService bikeTypeService,
            IBikeService bikeService, ITarriffService tarriffService, IOrderService orderService, ApplicationUserManager userManager,
            IStatusService statusService)
        {
            _rentPointService = rentPointService;
            _bikeTypeService = bikeTypeService;
            _bikeService = bikeService;
            _orderService = orderService;
            _tarriffService = tarriffService;
            _userManager = userManager;
            _statusService = statusService;
            ViewBag.ErrorCancelingMessage = false;
        }

        [HttpGet]
        public ActionResult CreateOrder(int bikeId)
        {
            var newOrderViewModel = new CreationOrderViewModel();
            newOrderViewModel.RentPoints = newOrderViewModel.ReturnPoints = _rentPointService.AllRentPoint();
            newOrderViewModel.BikeId = bikeId;

            var bike = _bikeService.GetBikeByIdIncludingBikeType(bikeId);
            newOrderViewModel.BikeModel = bike.Model;
            newOrderViewModel.BikeTypeId = bike.BikeType.Id;
            newOrderViewModel.Tarriffs = _bikeTypeService.GetBikeTypeById(bike.BikeType.Id).Tarriffs;

            return View(newOrderViewModel);
        }

        [HttpPost]
        public ActionResult CreateOrder(CreationOrderViewModel viewModelOrder)
        {
            viewModelOrder.UserId = UserId;
            if (ModelState.IsValid)
            {
                var previewViewModel = new PreviewNewOrderViewModel
                {
                    BikeId = viewModelOrder.BikeId,
                    BikeModel = _bikeService.GetBikeById(viewModelOrder.BikeId).Model,
                    RentPointId = viewModelOrder.RentPointId,
                    RentPoint = _rentPointService.GetRentPointById(viewModelOrder.RentPointId),
                    StartDateTime = new DateTime(viewModelOrder.StartDate.Year, viewModelOrder.StartDate.Month, viewModelOrder.StartDate.Day,
                                                              viewModelOrder.StartTime.Hour, viewModelOrder.StartTime.Minute, 0),

                    ReturnPointId = viewModelOrder.ReturnPointId,
                    ReturnPoint = _rentPointService.GetRentPointById(viewModelOrder.ReturnPointId),

                    TarriffId = viewModelOrder.TarriffId
                };

                var tarriff = _tarriffService.GetTarriffByIdWithKindRent(viewModelOrder.TarriffId);
                previewViewModel.Tarriff = tarriff;

                previewViewModel.Amount = tarriff.Amount;
                previewViewModel.EndDateTime =
                    _orderService.CalculateEndDateOfRent(previewViewModel.StartDateTime, tarriff.Id);

                return View("ConfirmationOrder", previewViewModel);

            }
            viewModelOrder.RentPoints = viewModelOrder.ReturnPoints = _rentPointService.AllRentPoint();

            return View();
       }

        [HttpPost]
        public ActionResult ConfirmationOrder(PreviewNewOrderViewModel viewModelOrder)
        {
            if (ModelState.IsValid)
            {
                viewModelOrder.UserId = UserId;
                _orderService.AddNewOrder(viewModelOrder);

                return RedirectToAction("PersonalAccount", "Account");
            }

            return View(viewModelOrder);
        }

        [HttpGet]
        public ActionResult AllOrders()
        {
            var orders = _orderService.GetOrdersByUserId(UserId);
            return PartialView(orders);
        }

        //Orders for seller

        [HttpGet]
        public ActionResult AllOrdersForDelivery(string currentFilter, string searchString, int? page)
        {
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;
            
            //paging
            int pageSize = 4;
            int pageNumber = (page ?? 1);



            var sellerRentPointId = _userManager.FindById(UserId).RentPoint.Id;

            var listOrders = new List<OrderViewModel>(); 
            var orders = _orderService.GetBookedOrdersByRentPointId(sellerRentPointId);
            if (!String.IsNullOrEmpty(searchString))
            {
                orders = orders.Where(s => s.User.UserInfo.Name.Contains(searchString)
                                           || s.User.UserInfo.Surname.Contains(searchString)
                                           || s.Id == Convert.ToInt32(searchString));
            }

            foreach (var order in orders)
            {
                StringBuilder sb = new StringBuilder();
                listOrders.Add(new OrderViewModel
                {
                    OrderId = order.Id,
                    StatusOrder = order.Status.StatusName,
                    DateTimeCreationOrder = order.DateTimeCreationOrder,
                    TotalCost = order.Amount,
                    StartDateTimeRent = order.StartDateTimeRent,
                    EndDateTimeRent = order.EndDateTimeRent,
                    RentPoint = order.RentPoint,
                    ReturnRentPoint = order.RentPoint,
                    BikeModel = order.Bike.Model,
                    BikeTypeName = order.Bike.BikeType.Type,
                    CustomerFullName = sb.AppendLine(order.User.UserInfo.Surname + " " + order.User.UserInfo.Name + " " + order.User.UserInfo.Patronymic).ToString(),
                    CustomerPhoneNumber = order.User.UserInfo.Phone,
                    TarriffQuantity = order.Tarriff.Quantity,
                    TarriffType = order.Tarriff.KindOfRent.Kind,
                    Amount = order.Amount
                });

            }

            var pagedListOrder = listOrders.ToPagedList(pageNumber, pageSize);

            if (Request.IsAjaxRequest())
            {
                return PartialView("_OrdersDelivery", pagedListOrder);
            }
            return PartialView("AllOrdersForSeller", pagedListOrder);
        }

        [HttpGet]
        public ActionResult AllOrdersForReceipt(string currentFilter, string searchString, int? page)
        {
            var listOrders = new List<OrderViewModel>();

            var sellerRentPointId = _userManager.FindById(UserId).RentPoint.Id;
            var orders = _orderService.GetActiveOrdersByRentPointId(sellerRentPointId);
            if (!String.IsNullOrEmpty(searchString))
            {
                orders = orders.Where(s => s.User.UserInfo.Name.Contains(searchString)
                                           || s.User.UserInfo.Surname.Contains(searchString)
                                           || s.Id == Convert.ToInt32(searchString));
            }


            foreach (var order in orders)
            {
                StringBuilder sb = new StringBuilder();
                listOrders.Add(new OrderViewModel
                {
                    OrderId = order.Id,
                    StatusOrder = order.Status.StatusName,
                    DateTimeCreationOrder = order.DateTimeCreationOrder,
                    TotalCost = order.Amount,
                    StartDateTimeRent = order.StartDateTimeRent,
                    EndDateTimeRent = order.EndDateTimeRent,
                    RentPoint = order.RentPoint,
                    ReturnRentPoint = order.RentPoint,
                    BikeModel = order.Bike.Model,
                    BikeTypeName = order.Bike.BikeType.Type,
                    CustomerFullName = sb.AppendLine(order.User.UserInfo.Surname + " " + order.User.UserInfo.Name + " " + order.User.UserInfo.Patronymic).ToString(),
                    CustomerPhoneNumber = order.User.UserInfo.Phone,
                    TarriffQuantity = order.Tarriff.Quantity,
                    TarriffType = order.Tarriff.KindOfRent.Kind,
                    Amount = order.Amount
                });

            }
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            //paging
            int pageSize = 4;
            int pageNumber = (page ?? 1);

            var pagedListOrder = listOrders.ToPagedList(pageNumber, pageSize);

            if (Request.IsAjaxRequest())
            {
                return PartialView("_OrdersReceipt", pagedListOrder);
            }

            return PartialView("AllOrdersForSeller1", pagedListOrder);
        }

        public ActionResult CancelOrder(int orderId)
        {
            var order = _orderService.GetOrderById(orderId);
            if (order.Status.StatusName.Equals(OrderStatus.Booked))
            {
                //ViewBag.NOrder
                TimeSpan span = DateTime.UtcNow - order.StartDateTimeRent.ToUniversalTime();
                if (span.Minutes < 10)
                {
                    ViewBag.NOrder = orderId;
                    ViewBag.ErrorCancelingMessage = true;
                }
                else
                {
                    order.Status = _statusService.GetStatusByStatusName(OrderStatus.Cancelled);
                    _orderService.UpdateOrder(order);
                }
            }

            return RedirectToAction("PersonalAccount", "Account");
        }

        public ActionResult GiveOrder(int orderId)
        {
            var order = _orderService.GetOrderById(orderId);
            if (order.Status.StatusName.Equals(OrderStatus.Booked))
            {
                order.Status = _statusService.GetStatusByStatusName(OrderStatus.Active);
                _orderService.UpdateOrder(order);
            }

            return RedirectToAction("PersonalAccount", "Account");

        }

        public ActionResult GetOrder(int orderId)
        {
            var order = _orderService.GetOrderById(orderId);
            if (order.Status.StatusName.Equals(OrderStatus.Active))
            {
                order.Status = _statusService.GetStatusByStatusName(OrderStatus.Completed);
                _orderService.UpdateOrder(order);
            }

            return RedirectToAction("PersonalAccount", "Account");
        }
    }
}
using System;
using System.Collections.Generic;
using RentABike.DataProvider.Interfaces;
using RentABike.Logic.Interfaces;
using RentABike.Models;
using RentABike.Models.Constants;
using RentABike.ViewModels;

namespace RentABike.Logic
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IBikeService _bikeService;

        private readonly IStatusService _statusService;

        private readonly ITarriffService _tarriffService;

        public OrderService (IUnitOfWork unitOfWork, ITarriffService tarriffService, 
                             IBikeService bikeService, IStatusService statusService)
        {
            _unitOfWork = unitOfWork;
            _bikeService = bikeService;
            _statusService = statusService;
            _tarriffService = tarriffService;
        }

        public void AddNewOrder(PreviewNewOrderViewModel vm)
        {
            var now = DateTime.UtcNow;
            var newOrder = new Order
            {
                UserId = vm.UserId,
                DateTimeCreationOrder = new DateTime(now.Year, now.Month, now.Day, now.Hour, now.Minute, 0),
                RentPointId = vm.RentPointId,
                ReturnPointId = vm.ReturnPointId,
                StartDateTimeRent = vm.StartDateTime,
                Tarriff = _tarriffService.GetTarriffById(vm.TarriffId)
            };

            //status for new order

            var status = _statusService.GetStatusByStatusName(OrderStatus.Booked);
            if (status != null)
            {
                newOrder.Status = status;
            }

            var bike = _bikeService.GetBikeById(vm.BikeId);
            if (bike != null)
            {
                newOrder.Bike = bike;
            }

            //set the amount from the tariff (if it was changed on view)
            var tarriff = _tarriffService.GetTarriffById(vm.TarriffId);
            if (tarriff != null)
            {
                newOrder.Amount = tarriff.Amount;
                newOrder.EndDateTimeRent = CalculateEndDateOfRent(vm.StartDateTime, tarriff.Id);
            }

            _unitOfWork.OrderRepository.Create(newOrder);
            _unitOfWork.Save();
        }

        public DateTime CalculateEndDateOfRent(DateTime starDateTime, int tarriffId)
        {
            var tarriff = _tarriffService.GetTarriffByIdWithKindRent(tarriffId);
            var endDateTime = new DateTime();
            switch (tarriff.KindOfRent.Kind)
            {
                case "hour(s)":
                    endDateTime = starDateTime.AddHours(tarriff.Quantity);
                    break;
                case "day(s)":
                    endDateTime = starDateTime.AddDays(tarriff.Quantity);
                    break;
            }

            return endDateTime;
        }

        public IEnumerable<Order> GetActiveOrdersByRentPointId(int rentPointId)
        {
            return _unitOfWork.OrderRepository.GetAllWhere(r => r.RentPointId == rentPointId &&
                                                                (r.Status.StatusName == OrderStatus.Active ||
                                                                 r.Status.StatusName == OrderStatus.Annulled ||
                                                                 r.Status.StatusName == OrderStatus.Completed));
        }

        public Order GetOrderById(int orderId)
        {
            return _unitOfWork.OrderRepository.FindById(orderId);
        }

        public void UpdateOrder(Order order)
        {
            _unitOfWork.OrderRepository.Update(order);
            _unitOfWork.Save();
        }

        public IEnumerable<Order> GetBookedOrdersByRentPointId(int rentPointId)
        {
            return _unitOfWork.OrderRepository.GetAllWhere(r => r.RentPointId == rentPointId && 
                                                                                            (r.Status.StatusName == OrderStatus.Booked ||
                                                                                             r.Status.StatusName == OrderStatus.Annulled||
                                                                                             r.Status.StatusName == OrderStatus.Cancelled));
        }

        public IEnumerable<Order> GetOrdersByUserId(string userId)
        {
            var orders = _unitOfWork.OrderRepository.GetAllWhere(o => o.UserId == userId);
            return orders;

        }
    }
}


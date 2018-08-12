using System;
using System.Collections.Generic;
using RentABike.Models;
using RentABike.ViewModels;

namespace RentABike.Logic.Interfaces
{
    public interface IOrderService
    {
        void AddNewOrder(PreviewNewOrderViewModel vm);

        DateTime CalculateEndDateOfRent(DateTime starDateTime, int tarriffId);

        IEnumerable<Order> GetOrdersByUserId(string userId);

        IEnumerable<Order> GetBookedOrdersByRentPointId(int rentPointId);

        IEnumerable<Order> GetActiveOrdersByRentPointId(int rentPointId);

        Order GetOrderById(int orderId);

        void UpdateOrder(Order order);
    }
}

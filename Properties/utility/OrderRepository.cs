using System.Collections.Generic;
using OrderSystem.Properties.delegates;
using OrderSystem.Properties.model;
using OrderSystem.Properties.repository;

// Dependency Inversion Principle (DIP)
namespace OrderSystem.Properties.utility
{
    public class OrderRepository : IOrderRepo 
    {
        public event OrderDelegate.OrderAddedEventHandler OrderAdded;
        public event OrderDelegate.OrderProcessedEventHandler OrderProcessed;
        public event OrderDelegate.OrderProcessedNotificationEventHandler OrderProcessedNotification;

        public void AddOrder(Order order)
        {
            // Įtraukiame užsakymą
            OrderAdded?.Invoke(order);
            // Įvykdykime užsakymą
            order.IsProcessed = true;
            OrderProcessed?.Invoke(order);
            // Praneškime apie užsakymo apdorojimą
            OrderProcessedNotification?.Invoke($"Order {order.OrderId} processed successfully.");
        }
    }
}
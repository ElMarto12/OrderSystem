using System;
using OrderSystem.Properties.delegates;
using OrderSystem.Properties.model;
using OrderSystem.Properties.repository;


// Open/Closed Principle
namespace OrderSystem.Properties.utility
{
    public class OrderManager
    {
        private readonly IOrderRepo _orderRepository;

        public OrderManager(IOrderRepo orderRepository)
        {
            this._orderRepository = orderRepository;
            this._orderRepository.OrderAdded += NotifyOrderAdded;
            this._orderRepository.OrderProcessed += NotifyOrderProcessed;
            this._orderRepository.OrderProcessedNotification += NotifyOrderProcessedNotification;
        }

        public void PlaceOrder(Order order, OrderDelegate.ActionDelegate<Order> additionalAction = null)
        {
            _orderRepository.AddOrder(order);
            Console.WriteLine("Order placed successfully!");

            // Vykdome papildomą veiksmą su užsakymo objektu, jei toks yra nurodytas
            additionalAction?.Invoke(order);
        }

        private void NotifyOrderAdded(Order order)
        {
            Console.WriteLine($"New order added: {order.ProductName} by {order.CustomerName}");
        }

        private void NotifyOrderProcessed(Order order)
        {
            Console.WriteLine($"Order processed: {order.OrderId}");
        }
        
        private void NotifyOrderProcessedNotification(string message)
        {
            Console.WriteLine($"Notification: {message}");
        }
    }
}
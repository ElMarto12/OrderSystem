using System.Collections.Generic;
using OrderSystem.Properties.model;
using OrderSystem.Properties.delegates;

// Interface Segregation Principle (ISP)
namespace OrderSystem.Properties.repository
{
    public interface IOrderRepo
    {
        void AddOrder(Order order);
        event OrderDelegate.OrderAddedEventHandler OrderAdded;
        event OrderDelegate.OrderProcessedEventHandler OrderProcessed;
        event OrderDelegate.OrderProcessedNotificationEventHandler OrderProcessedNotification;
    }
}
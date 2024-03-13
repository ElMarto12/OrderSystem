using OrderSystem.Properties.model;

namespace OrderSystem.Properties.delegates
{
    public class OrderDelegate
    {
        // Asmeninis delegatas - Custom delegate
        public delegate void OrderAddedEventHandler(Order order);

        // Daugybinis delegatas - Multicast delegate
        public delegate void OrderProcessedEventHandler(Order order);
        public delegate void OrderProcessedNotificationEventHandler(string message);

        // Įvairių tipų delegatas - Generic delegate
        public delegate void ActionDelegate<T>(T obj);
    }
}
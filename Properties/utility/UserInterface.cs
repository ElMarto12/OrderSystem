using System;
using OrderSystem.Properties.model;

namespace OrderSystem.Properties.utility
{
    public class UserInterface
    {
        private readonly OrderManager _orderManager;

        public UserInterface(OrderManager orderManager)
        {
            this._orderManager = orderManager;
        }

        public void Start()
        {
            Console.WriteLine("Welcome to Order Management System!");
            while (true)
            {
                Console.WriteLine("1. Place an order");
                Console.WriteLine("2. Exit");

                Console.Write("Choose an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        PlaceOrder();
                        break;
                    case "2":
                        Console.WriteLine("Exiting...");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
        
        private void PlaceOrder()
        {
            Console.WriteLine("Enter order details:");
            Console.Write("Product Name: ");
            string productName = Console.ReadLine();
            Console.Write("Quantity: ");
            int quantity = int.Parse(Console.ReadLine() ?? string.Empty);
            Console.Write("Price: ");
            decimal price = decimal.Parse(Console.ReadLine() ?? string.Empty);
            Console.Write("Customer Name: ");
            string customerName = Console.ReadLine();

            Order newOrder = new Order
            {
                OrderId = GenerateOrderId(), // Generuojame unikalų užsakymo ID
                ProductName = productName,
                Quantity = quantity,
                Price = price,
                CustomerName = customerName,
                IsProcessed = false
            };

            // Pridedame užsakymą naudodami OrderManager
            _orderManager.PlaceOrder(newOrder, NotifyOrderPlaced);
        }

        private void NotifyOrderPlaced(Order order)
        {
            Console.WriteLine($"Order placed successfully! Order ID: {order.OrderId}");
        }

        // Papildomas metodas, kuris generuoja unikalų užsakymo ID
        private int GenerateOrderId()
        {
            // Čia gali būti naudojamas bet kokias ID generavimo logika
            // Šiuo atveju naudosime tiesiog skaičių seką
            Random random = new Random();
            return random.Next(1000, 10000);
        }
        
    }
}
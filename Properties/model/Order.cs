﻿//Single Responsibility
namespace OrderSystem.Properties.model
{
    public class Order
    {
        public int OrderId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string CustomerName { get; set; }
        public bool IsProcessed { get; set; }
    }
}
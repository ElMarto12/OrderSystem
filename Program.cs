
using OrderSystem.Properties.repository;
using OrderSystem.Properties.utility;

namespace OrderSystem
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            // Sukuriame OrderRepository objektą
            IOrderRepo orderRepository = new OrderRepository();

            // Sukuriame OrderManager objektą su OrderRepository įjungimu
            var orderManager = new OrderManager(orderRepository);

            // Sukuriame UserInterface objektą su OrderManager įjungimu
            var userInterface = new UserInterface(orderManager);

            // Paleidžiame vartotojo sąsają
            userInterface.Start();
        }
    }
}
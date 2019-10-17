using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;



namespace OrderFoodServiceConsoleApp
{
    class Program
    {
        static void Main()
        {
            using (ServiceHost host = new ServiceHost(typeof(OrderFoodService.OrderFoodServiceApi)))
            {
                host.Open();
                Console.WriteLine($"Order Food Service Started {DateTime.Now}");
                Console.ReadLine();
            }
        }
    }
}

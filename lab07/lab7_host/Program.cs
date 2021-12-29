using lab7;
using System;
using System.ServiceModel;

namespace lab7_host
{
    class Program
    {
        static void Main()
        {
            ServiceHost host = new ServiceHost(typeof(Feed1));
            host.Open();
            Console.WriteLine("Host Open");
            Console.ReadLine();
        }
    }
}

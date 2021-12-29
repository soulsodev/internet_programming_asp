using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            EdmService service = new EdmService();
            service.Print();

            Console.WriteLine("\n");
            Console.WriteLine("Enter Name: ");
            string name = Console.ReadLine();
            service.Add(name);

            Console.WriteLine("\n");
            Console.WriteLine("Enter Id");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter new Name: ");
            name = Console.ReadLine();
            service.Update(id, name);

            Console.WriteLine("\n\n");
            service.Print();
        }
    }
}

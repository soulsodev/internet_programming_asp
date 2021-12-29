using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using WCFSimplex;

namespace Host
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost host = new ServiceHost(typeof(WCFSimplex.WCFSimplex));
            host.Open();
            Console.WriteLine("SERVICE HOST");
            Console.Read();
        }
    }
}

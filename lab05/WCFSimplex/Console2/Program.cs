using System;
using static System.Console;

namespace Console2
{
    class Program
    {
        private static int x, y, chooseMethod, k, k1;
        private static string s, s1;
        private static float f, f1;
        private static double d;

        static void Main(string[] args)
        {
            var client = new WcfSimplex.WCFSimplexClient("NetTcpBinding_IWCFSimplex");
           // WCFSimplex
            WriteLine("NetTcpBinding Client");
            for (;;)
            {
                StartOperations(client);
            }
        }

        public static void StartOperations(WcfSimplex.WCFSimplexClient client)
        {
            try
            {
                WriteLine("\nMETHOD:\n1 - ADD: \n2 - CONCAT\n3 - SUM");
                chooseMethod = Convert.ToInt32(ReadLine());
                switch (chooseMethod)
                {
                    case 1:
                        WriteLine("ADD (int X, int Y):\nEnter X:");
                        x = Convert.ToInt32(ReadLine());
                        WriteLine("Enter Y:");
                        y = Convert.ToInt32(ReadLine());
                        WriteLine("Result: " + client.Add(x, y));
                        break;
                    case 2:
                        WriteLine("CONCAT (string S, double D):\nEnter X:");
                        s = ReadLine();
                        WriteLine("Enter D:");
                        d = Convert.ToDouble(ReadLine());
                        WriteLine($"Result: " + client.Concat(s, d));
                        break;
                    case 3:
                        WriteLine("SUM (2 pairs: float F, int K, string S):\n" +
                            "Enter F1:");
                        f = (float)Convert.ToDouble(ReadLine());
                        WriteLine("Enter F2:");
                        f1 = (float)Convert.ToDouble(ReadLine());
                        WriteLine("Enter K1:");
                        k = Convert.ToInt32(ReadLine());
                        WriteLine("Enter K2:");
                        k1 = Convert.ToInt32(ReadLine());
                        WriteLine("Enter S1:");
                        s = ReadLine();
                        WriteLine("Enter S2:");
                        s1 = ReadLine();
                        var sumResult = client.Sum(new WcfSimplex.A { s = s, k = k, f = f }, new WcfSimplex.A { s = s1, k = k1, f = f1 });
                        WriteLine("Result: " + "{F = " + sumResult.f + ", K = " + sumResult.k + ", S = " + sumResult.s + "}");
                        break;
                    default:
                        WriteLine("Incorrect value");
                        break;
                }
            } catch (FormatException ex)
            {
                WriteLine(ex.Message);
            }
        }
    }
}

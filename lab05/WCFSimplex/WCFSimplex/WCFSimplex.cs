using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFSimplex
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class WCFSimplex : IWCFSimplex
    {
        public int Add(int x, int y)
        {
            return(x + y);
        }

        public string Concat(string s, double d)
        {
            return string.Concat(s, d);
        }

        public A Sum(A a1, A a2)
        {
            return new A(
                string.Concat(a1.s, a2.s),
                a1.k + a2.k,
                a1.f + a2.f);
        }
    }
}

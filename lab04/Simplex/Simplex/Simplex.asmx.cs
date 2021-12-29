using System;
using System.Web.Script.Services;
using System.Web.Services;

namespace Simplex
{
    /// <summary>
    /// Summary description for Simplex
    /// </summary>
    [WebService(Namespace = "http://TVI/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [ScriptService]
    public class Simplex : WebService
    {

        [WebMethod(Description = "Return sum of x and y", MessageName = "Add")]
        public int Add(int x, int y)
        {
            return x + y;
        }

        [WebMethod(Description = "Return concat string and d", MessageName = "Concat")]
        public string Concat(string s, double d)
        {
            return String.Concat(s, d);
        }

        [WebMethod(Description = "Return sum of two objects A", MessageName = "Sum")]
        public A Sum(A a1, A a2)
        {
            return new A(
                String.Concat(a1.s + a2.s),
                a1.k + a2.k,
                a1.f + a2.f);
        }

        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        [WebMethod(Description = "Return sum of x and y. Response JSON", MessageName = "Adds")]
        public int Adds(int x, int y)
        {
            return x + y;
        }
    }
}

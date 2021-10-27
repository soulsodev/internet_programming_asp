using System;
using System.Web;
using Newtonsoft.Json;
using System.Linq;
using System.Collections.Generic;
using System.Net;
using System.Web.SessionState;

namespace Lab_1.App_Code
{

    public class WebHandler : IHttpHandler, IRequiresSessionState
    {
        public static int result = 0;
        public bool IsReusable => true;

        public void ProcessRequest(HttpContext context)
        {
            if (context.Session["stack"] == null)
            {
                Stack<int> EmptyStack = new Stack<int>();
                context.Session.Add("stack", EmptyStack);
            }
            Stack<int> stack = (Stack<int>)context.Session["stack"];
            switch (context.Request.HttpMethod)
            {
                case "GET":
                    {
                        context.Response.Write(JsonConvert.SerializeObject(new
                        {
                            result = result + stack.FirstOrDefault()
                        }));
                        break;
                    };
                case "POST":
                    {
                        String resultInput = context.Request.Params["RESULT"];
                        if (resultInput != "")
                        {
                            result = Convert.ToInt32(resultInput);
                        }
                        break;
                    };
                case "PUT":
                    {
                        stack.Push(Convert.ToInt32(context.Request.Params["ADD"]));
                        break;
                    };
                case "DELETE":
                    {
                        if (stack.Count != 0)
                        {
                            stack.Pop();
                        }
                        break;
                    };
            }
            context.Response.AddHeader("access-control-allow-origin", "*");
            context.Response.AddHeader("Access-Control-Allow-Methods", "*");
        }
    }
}
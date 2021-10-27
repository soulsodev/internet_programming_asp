using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Filters;

namespace lab02.Filters
{
    public class CorsFilter : ActionFilterAttribute
    {
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            actionExecutedContext.Response.Headers.Add("Access-Control-Allow-Origin", "*");
            actionExecutedContext.Response.Headers.Add("Access-Control-Allow-Headers", "*");
            actionExecutedContext.Response.Headers.Add("Access-Control-Allow-Credentials", "true");
            actionExecutedContext.Response.Headers.Add("Access-Control-Allow-Methods", "*");

            base.OnActionExecuted(actionExecutedContext);
        }
    }
}
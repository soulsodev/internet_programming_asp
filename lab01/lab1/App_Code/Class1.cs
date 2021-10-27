using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace lab1.App_Code {

public class AllowCrossSiteAttribute : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext filterContext)
    {
        filterContext.RequestContext.HttpContext.Response.AddHeader("Access-Control-Allow-Origin", "http://localhost");
        filterContext.RequestContext.HttpContext.Response.AddHeader("Access-Control-Allow-Headers", "*");
        filterContext.RequestContext.HttpContext.Response.AddHeader("Access-Control-Allow-Credentials", "true");

        base.OnActionExecuting(filterContext);
    }
}
}
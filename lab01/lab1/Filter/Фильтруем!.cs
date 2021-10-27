using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace lab1.Filter {

    public class Фильтруем_ : ActionFilterAttribute, IActionFilter {

        public override void OnActionExecuted(ActionExecutedContext filterContext) {
            throw new NotImplementedException();
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext) {
            filterContext.RequestContext.HttpContext.Response.AddHeader("Access-Control-Allow-Origin", "http://localhost");
            filterContext.RequestContext.HttpContext.Response.AddHeader("Access-Control-Allow-Headers", "*");
            filterContext.RequestContext.HttpContext.Response.AddHeader("Access-Control-Allow-Credentials", "true");
        }
    }
}
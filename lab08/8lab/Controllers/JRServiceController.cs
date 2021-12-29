
using _8lab.Models;
using System.Web.Mvc;

namespace _8lab.Controllers
{
    public class JRServiceController : Controller
    {
        private static bool ignoreMethods = false;

        [HttpPost]
        public JsonResult Multi(ReqJsonRpc[] body)
        {
            int length = body.Length;
            JsonResult[] result = new JsonResult[length];

            for (int i = 0; i < length; i++)
                result[i] = Single(body[i]);

            return Json(result);
        }

        [HttpPost]
        public JsonResult Single(ReqJsonRpc body)
        {
            string method = body.Method;
            ReqParams param = body.Params;
            string jsonrpc = body.Jsonrpc;
           

            if (ignoreMethods)
                return Json(GetError(body.Id, new ErrorMessage { Message = "Methods are not available", Code = -32601 }, jsonrpc));

            int? result = null;

            string key = param.Key;
            int value = int.Parse(param.Value == null || param.Value == "" ? "0" : param.Value);

            switch (method)
            {
                case "SetM": { result = SetM(key, value); break; }
                case "GetM": { result = GetM(key); break; }
                case "AddM": { result = AddM(key, value); break; }
                case "SubM": { result = SubM(key, value); break; }
                case "MulM": { result = MulM(key, value); break; }
                case "DivM": { result = DivM(key, value); break; }
                case "ErrorExit": { ErrorExit(); break; }

                default:
                    {
                        return Json(GetError(body.Id, new ErrorMessage
                        {
                            Message = string.Format("Function {0} is not found", body.Method),
                            Code = -32601
                        }, jsonrpc));
                    }
            }

            return Json(new ResJsonRpc()
            {
                Id = body.Id,
                Jsonrpc = jsonrpc,
                Method = body.Method,
                Result = result
            }, JsonRequestBehavior.AllowGet
            );
        }

        private JsonRpcError GetError(string id, ErrorMessage error, string jsonrpc)
        {
            return new JsonRpcError()
            {
                Id = id,
                Jsonrpc = jsonrpc,
                Error = error
            };
        }

        private int? SetM(string k, int x)
        {
            HttpContext.Session[k] = x;
            return GetM(k);
        }

        private int? GetM(string k)
        {
            object result = HttpContext.Session[k];
            if (result == null)
                return null;
            else
                return int.Parse(result.ToString());
        }

        private int? AddM(string k, int x)
        {
            int? value = GetM(k);
            HttpContext.Session[k] = value == null ? x : value + x;
            return GetM(k);
        }

        private int? SubM(string k, int x)
        {
            int? value = GetM(k);
            HttpContext.Session[k] = value == null ? x : value - x;
            return GetM(k);
        }

        private int? MulM(string k, int x)
        {
            int? value = GetM(k);
            HttpContext.Session[k] = value == null ? x : value * x;
            return GetM(k);
        }

        private int? DivM(string k, int x)
        {
            int? value = GetM(k);
            HttpContext.Session[k] = value == null ? x : value / x;
            return GetM(k);
        }

        private void ErrorExit()
        {
            HttpContext.Session.Clear();
            ignoreMethods = true;
        }
    }
}
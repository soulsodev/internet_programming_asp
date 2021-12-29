using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _8lab.Models
{
    public class ReqJsonRpc
    {
        public string Id { get; set; }
        public string Jsonrpc { get; set; }
        public string Method { get; set; }
        public ReqParams Params { get; set; }
    }
}
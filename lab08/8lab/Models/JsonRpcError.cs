using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _8lab.Models
{
    public class JsonRpcError
    {
        public string Jsonrpc { get; set; }
        public ErrorMessage Error { get; set; }
        public string Id { get; set; }
    }
}
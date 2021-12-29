using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _8lab.Models
{
    public class ResJsonRpc
    {
        public string Id { get; set; }
        public string Jsonrpc { get; set; }
        public string Method { get; set; }
        public int? Result { get; set; }
    }
}
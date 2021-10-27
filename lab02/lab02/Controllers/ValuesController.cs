using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace lab02.Controllers
{
    public class ValuesController : ApiController
    {
        public static int resultValue = 0;
        public static Stack<int> stack = new Stack<int>();

        public class PostRequest
        {
            public int resultValue;
        }

        public class PutRequest
        {
            public int addValue;
        }

        public IHttpActionResult Options()
        {
            return Ok();
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            return Json(JsonConvert.SerializeObject(new
            {
                resultValue = resultValue + stack.FirstOrDefault()
            }));
        }

        [HttpPost]
        public IHttpActionResult Post([FromBody] PostRequest value)
        {
            if (value != null) 
            { 
                resultValue = value.resultValue; 
            }
            return Ok(resultValue);
        }

        [HttpPut] 
        public IHttpActionResult Put([FromBody] PutRequest value)
        {
            if (value != null)
            {
                stack.Push(value.addValue);
            }
            return Ok(value);
        }

        [HttpDelete]
        public IHttpActionResult Delete()
        {
            if (stack.Count != 0)
            {
                return Ok(stack.Pop());
            }
            else
            {
                return BadRequest();
            }
        }
    }
}

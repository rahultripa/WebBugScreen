using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace screenshare3.Controllers
{
    public class student
  {
    public int id { get; set; }
  }
    public class TestController : ApiController
    {
        // GET: api/Test
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Test/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Test
        public HttpResponseMessage Post([FromBody]student value)
        {
      var response = Request.CreateResponse(HttpStatusCode.OK);
      response.Headers.Location = new Uri("https://localhost:44308/JdaBugViiew/Index");
      return response;
     // return value.id.ToString();
         }

        // PUT: api/Test/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Test/5
        public void Delete(int id)
        {
        }
    }
}

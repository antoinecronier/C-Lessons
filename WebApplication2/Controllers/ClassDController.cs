using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication2.Controllers
{
    public class ClassDController : ApiController
    {
        // GET: api/ClassD
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/ClassD/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/ClassD
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/ClassD/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ClassD/5
        public void Delete(int id)
        {
        }
    }
}

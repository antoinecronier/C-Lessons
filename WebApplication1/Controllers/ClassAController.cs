using ClassLibrary1;
using ClassLibrary2.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication1.Controllers
{
    public class ClassAController : ApiController
    {
        private MySQLManager<ClassA> manager;

        public ClassAController()
        {
            manager = new MySQLManager<ClassA>();
        }
        public IEnumerable<ClassA> GetAllProducts()
        {
            return manager.GetFromMySQL();
        }

        public IHttpActionResult GetProduct(int id)
        {
            return Ok(manager.GetFromMySQL(id));
        }
    }
}

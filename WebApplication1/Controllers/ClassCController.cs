using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication1.Controllers
{
    public class ClassCController : ApiController
    {
        ClassA[] itemA = new ClassA[]
        {
            new ClassA { Field1 = 1, Field2 = "Tomato Soup", Field3 = "Groceries"},
            new ClassA { Field1 = 2, Field2 = "Yo-yo", Field3 = "Toys"},
            new ClassA { Field1 = 3, Field2 = "Hammer", Field3 = "Hardware"}
        };

        public IEnumerable<ClassA> GetAllProducts()
        {
            return itemA;
        }

        public IHttpActionResult GetProduct(int id)
        {
            var item = itemA.FirstOrDefault((p) => p.Field1 == id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }
    }
}

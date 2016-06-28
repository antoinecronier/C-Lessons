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

        /// <summary>
        /// Controller default constructor.
        /// </summary>
        public ClassAController()
        {
            manager = new MySQLManager<ClassA>(DataConnectionResource.LOCALMYQSL);
        }

        /// <summary>
        /// Return List of all items.
        /// </summary>
        /// <returns>IEnumerable items.</returns>
        public IEnumerable<ClassA> GetAll()
        {
            return manager.Get();
        }

        /// <summary>
        /// Get one item.
        /// </summary>
        /// <param name="id">Whished item id.</param>
        /// <returns>IHttpActionResult item.</returns>
        public IHttpActionResult Get(int id)
        {
            return Ok(manager.Get(id));
        }
    }
}

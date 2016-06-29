using ClassLibrary2.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace WebApplication2.Controllers.Base
{
    public class BaseController<T> : ApiController where T : class
    {
        private MySQLManager<T> manager;

        /// <summary>
        /// Controller default constructor.
        /// </summary>
        public BaseController()
        {
            manager = new MySQLManager<T>(DataConnectionResource.LOCALMYQSL);
        }

        /// <summary>
        /// Return List of all items.
        ///  GET api/values
        /// </summary>
        /// <returns>IEnumerable items.</returns>
        [HttpGet]
        public async Task<IEnumerable<T>> Get()
        {
            return await manager.Get();
        }

        /// <summary>
        /// Get one item.
        ///  GET api/values/5
        /// </summary>
        /// <param name="id">Whished item id.</param>
        /// <returns>IHttpActionResult item.</returns>
        [HttpGet]
        public async Task<IHttpActionResult> Get(int id)
        {
            return Ok(await manager.Get(id));
        }

        // POST api/values
        [HttpPost]
        public async Task<IHttpActionResult> Post(T value)
        {
            await manager.Insert(value);
            return Ok(value);
        }

        [HttpPost]
        virtual public async Task<IHttpActionResult> Post(IEnumerable<T> values)
        {
            return Ok(await manager.Insert(values));
        }

        // PUT api/values/5
        [HttpPut]
        public async Task<IHttpActionResult> Put(T value)
        {
            return Ok(await manager.Update(value));
        }

        [HttpPut]
        virtual public async Task<IHttpActionResult> Put(IEnumerable<T> values)
        {
            return Ok(await manager.Update(values));
        }

        // DELETE api/values/5
        [HttpDelete]
        public async Task<IHttpActionResult> Delete(T value)
        {
            return Ok(await manager.Delete(value));
        }

        [HttpDelete]
        virtual public async Task<IHttpActionResult> Delete(IEnumerable<T> values)
        {
            return Ok(await manager.Delete(values));
        }
    }
}

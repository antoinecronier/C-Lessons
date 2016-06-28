﻿using ClassLibrary1;
using ClassLibrary2.Database;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
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
        ///  GET api/values
        /// </summary>
        /// <returns>IEnumerable items.</returns>
        [HttpGet]
        public async Task<IEnumerable<ClassA>> Get()
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
        public async Task<IHttpActionResult> Post(ClassA value)
        {
            await manager.Insert(value);
            return Ok(value);
        }

        [HttpPost]
        [Route("api/ClassAs/")]
        public async Task<IHttpActionResult> Post(IEnumerable<ClassA> values)
        {
            return Ok(await manager.Insert(values));
        }

        // PUT api/values/5
        [HttpPut]
        public async Task<IHttpActionResult> Put(ClassA value)
        {
            return Ok(await manager.Update(value));
        }

        [HttpPut]
        [Route("api/ClassAs/")]
        public async Task<IHttpActionResult> Put(IEnumerable<ClassA> values)
        {
            return Ok(await manager.Update(values));
        }

        // DELETE api/values/5
        [HttpDelete]
        public async Task<IHttpActionResult> Delete(ClassA value)
        {
            return Ok(await manager.Delete(value));
        }

        [HttpDelete]
        [Route("api/ClassAs")]
        public async Task<IHttpActionResult> Delete(IEnumerable<ClassA> values)
        {
            return Ok(await manager.Delete(values));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ClassLibrary1;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class ClassBsController : ApiController
    {
        private ClassBContext db = new ClassBContext();

        // GET: api/ClassBs
        public IQueryable<ClassB> GetClassBs()
        {
            return db.ClassBs;
        }

        // GET: api/ClassBs/5
        [ResponseType(typeof(ClassB))]
        public IHttpActionResult GetClassB(int id)
        {
            ClassB classB = db.ClassBs.Find(id);
            if (classB == null)
            {
                return NotFound();
            }

            return Ok(classB);
        }

        // PUT: api/ClassBs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutClassB(int id, ClassB classB)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != classB.Field1)
            {
                return BadRequest();
            }

            db.Entry(classB).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClassBExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/ClassBs
        [ResponseType(typeof(ClassB))]
        public IHttpActionResult PostClassB(ClassB classB)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ClassBs.Add(classB);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = classB.Field1 }, classB);
        }

        // DELETE: api/ClassBs/5
        [ResponseType(typeof(ClassB))]
        public IHttpActionResult DeleteClassB(int id)
        {
            ClassB classB = db.ClassBs.Find(id);
            if (classB == null)
            {
                return NotFound();
            }

            db.ClassBs.Remove(classB);
            db.SaveChanges();

            return Ok(classB);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ClassBExists(int id)
        {
            return db.ClassBs.Count(e => e.Field1 == id) > 0;
        }
    }
}
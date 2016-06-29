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
using WebApplication2.Controllers.Base;
using System.Threading.Tasks;

namespace WebApplication2.Controllers
{
    public class ClassBController : BaseController<ClassB>
    {
        [Route("api/ClassBs")]
        public override Task<IHttpActionResult> Post(IEnumerable<ClassB> values)
        {
            return base.Post(values);
        }

        [Route("api/ClassBs")]
        public override Task<IHttpActionResult> Put(IEnumerable<ClassB> values)
        {
            return base.Put(values);
        }

        [Route("api/ClassBs")]
        public override Task<IHttpActionResult> Delete(IEnumerable<ClassB> values)
        {
            return base.Delete(values);
        }
    }
}
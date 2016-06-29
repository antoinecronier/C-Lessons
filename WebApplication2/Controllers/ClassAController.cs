using ClassLibrary1;
using ClassLibrary2.Database;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using WebApplication2.Controllers.Base;

namespace WebApplication1.Controllers
{
    public class ClassAController : BaseController<ClassA>
    {
        [Route("api/ClassAs")]
        public override Task<IHttpActionResult> Post(IEnumerable<ClassA> values)
        {
            return base.Post(values);
        }

        [Route("api/ClassAs")]
        public override Task<IHttpActionResult> Put(IEnumerable<ClassA> values)
        {
            return base.Put(values);
        }

        [Route("api/ClassAs")]
        public override Task<IHttpActionResult> Delete(IEnumerable<ClassA> values)
        {
            return base.Delete(values);
        }
    }
}

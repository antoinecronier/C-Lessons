using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using WebApplication2.Controllers.Base;

namespace WebApplication2.Controllers
{
    public class ClassCController : BaseController<ClassC>
    {
        [Route("api/ClassCs")]
        public override Task<IHttpActionResult> Post(IEnumerable<ClassC> values)
        {
            return base.Post(values);
        }

        [Route("api/ClassCs")]
        public override Task<IHttpActionResult> Put(IEnumerable<ClassC> values)
        {
            return base.Put(values);
        }

        [Route("api/ClassCs")]
        public override Task<IHttpActionResult> Delete(IEnumerable<ClassC> values)
        {
            return base.Delete(values);
        }
    }
}

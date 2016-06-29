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
    public class ClassDController : BaseController<ClassD>
    {
        [Route("api/ClassDs")]
        public override Task<IHttpActionResult> Post(IEnumerable<ClassD> values)
        {
            return base.Post(values);
        }

        [Route("api/ClassDs")]
        public override Task<IHttpActionResult> Put(IEnumerable<ClassD> values)
        {
            return base.Put(values);
        }

        [Route("api/ClassDs")]
        public override Task<IHttpActionResult> Delete(IEnumerable<ClassD> values)
        {
            return base.Delete(values);
        }
    }
}

using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using WebApplication2.Controllers.Base;

namespace WebApplication2.Controllers
{
    public class ClassEController : BaseController<ClassE>
    {
        [Route("api/ClassEs")]
        public override Task<IHttpActionResult> Post(IEnumerable<ClassE> values)
        {
            return base.Post(values);
        }

        [Route("api/ClassEs")]
        public override Task<IHttpActionResult> Put(IEnumerable<ClassE> values)
        {
            return base.Put(values);
        }

        [Route("api/ClassEs")]
        public override Task<IHttpActionResult> Delete(IEnumerable<ClassE> values)
        {
            return base.Delete(values);
        }
    }
}

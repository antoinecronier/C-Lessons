using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebApplicationMVCSecure.Controllers.Base;
using WebApplicationMVCSecure.Database;
using WebApplicationMVCSecure.Models;

namespace WebApplicationMVCSecure.Controllers
{
    public class UsersToAddressesController : BaseController<UsersToAddresses>
    {
        public new async Task<ActionResult> Create()
        {
            SQLManager<User> managerUser = new SQLManager<Models.User>(DataConnectionResource.LOCALMSSQLSERVER);
            
            return View(await managerUser.Get() as List<User>);
        }
    }
}
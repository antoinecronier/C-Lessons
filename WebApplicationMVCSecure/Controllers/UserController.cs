using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebApplicationMVCSecure.Controllers.Base;
using WebApplicationMVCSecure.Database;
using WebApplicationMVCSecure.Models;

namespace WebApplicationMVCSecure.Controllers
{
    public class UserController : BaseController<User>
    {
        SQLManager<Address> dataManagerAddress;

        public UserController()
        {
            dataManagerAddress = new SQLManager<Address>(DataConnectionResource.LOCALMSSQLSERVER);
        }

        public override async Task<ActionResult> Create()
        {
            this.ViewBag.AddressList = (await dataManagerAddress.Get()).ToList();
            this.ViewBag.AddressItem = new Address();
            return View();
        }
        
        public async Task<ActionResult> BoxedAddressItem(int id)
        {
            this.ViewBag.NoFooter = true;
            return View("~/Views/Address/Widgets/BoxedAddressItem.cshtml",await dataManagerAddress.Get(id));
        }
    }
}
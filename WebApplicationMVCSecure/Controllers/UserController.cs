using Newtonsoft.Json;
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
using WebApplicationMVCSecure.Utils.Comparer;
using WebApplicationMVCSecure.Utils.Generator;
using Windows.Data.Json;

namespace WebApplicationMVCSecure.Controllers
{
    public class UserController : BaseController<User>
    {
        SQLManager<Address> dataManagerAddress;
        SQLManager<UsersToAddresses> dataManagerUserToAddress;

        public UserController()
        {
            dataManagerAddress = new SQLManager<Address>(DataConnectionResource.LOCALMSSQLSERVER);
            dataManagerUserToAddress = new SQLManager<UsersToAddresses>(DataConnectionResource.LOCALMSSQLSERVER);
        }

        [Authorize]
        public override async Task<ActionResult> Create()
        {
            this.ViewBag.AddressList = (await dataManagerAddress.Get()).ToList();
            this.ViewBag.AddressItem = new Address();
            ViewBag.ItemListCSSClass = "col-md-3";
            return View();
        }

        [Authorize]
        public async Task<ActionResult> BoxedAddressItem(int id)
        {
            this.ViewBag.NoFooter = true;
            return View("~/Views/Address/Widgets/BoxedAddressItem.cshtml",await dataManagerAddress.Get(id));
        }

        [Authorize]
        public async Task<ActionResult> AddAddress(string json)
        {
            Address address = JsonConvert.DeserializeObject<Address>(json);
            await dataManagerAddress.Insert(address);
            return View("~/Views/Address/Widgets/BoxedAddressItem.cshtml", address);
        }

        [Authorize]
        public async Task<ActionResult> EditAddress(string json)
        {
            Address address = JsonConvert.DeserializeObject<Address>(json.Replace("Address_",""));
            await dataManagerAddress.Update(address);
            return View("~/Views/Address/Widgets/BoxedAddressItem.cshtml", address);
        }

        [Authorize]
        public override async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            User item = await dataManager.Get(id);
            item.Address = await dataManagerAddress.Get(item.AddressId);


            List<UsersToAddresses> links = dataManagerUserToAddress.DbSetT.SqlQuery("SELECT * from dbo.UsersToAddresses WHERE UserId = " + item.Id + ";").ToList();
            List<Address> userAddresses = new List<Address>();
            List<Address> otherAddress = (await dataManagerAddress.Get()).ToList();

            foreach (var address in links)
            {
                Address temp = await dataManagerAddress.Get(address.AddressId);
                userAddresses.Add(temp);
                otherAddress.Remove(temp);
            }

            ViewBag.AddressListUser = userAddresses;
            ViewBag.AddressListAll = otherAddress;
            ViewBag.ItemListCSSClass = "col-md-5";
            ViewBag.ItemListProperty = "draggable=true";
            ViewBag.NoJQuery = true;

            if (item == null)
            {
                return HttpNotFound();
            }

            return View(item);
        }

        [Authorize]
        [HttpPost]
        public async Task EditUsersToAddresses(string json)
        {
            List<UsersToAddresses> usersToAddresses = JsonConvert.DeserializeObject<List<UsersToAddresses>>(json);

            //Use null
            List<UsersToAddresses> currentUserAddresses = dataManagerUserToAddress.DbSetT.SqlQuery("SELECT * from dbo.UsersToAddresses WHERE UserId = " + usersToAddresses[0].UserId).ToList();

            List<UsersToAddresses> toDelete = new List<UsersToAddresses>(currentUserAddresses);

            if (usersToAddresses[0].AddressId != 0)
            {
                List<UsersToAddresses> toAdd = new List<UsersToAddresses>(usersToAddresses);

                foreach (var cUa in currentUserAddresses)
                {
                    var itemsToAdd = usersToAddresses.FindAll(x => x.AddressId == cUa.AddressId && x.UserId == cUa.UserId);
                    foreach (var item in itemsToAdd)
                    {
                        toAdd.Remove(item);
                    }
                }

                foreach (var uTa in usersToAddresses)
                {
                    var itemsToDelete = currentUserAddresses.Find(x => x.AddressId == uTa.AddressId);
                    toDelete.Remove(itemsToDelete);
                }

                if (toAdd.Count > 0)
                {
                    await dataManagerUserToAddress.Insert(toAdd);
                }
            }
            if (toDelete.Count > 0 && User.Identity.IsAuthenticated)
            {
                await dataManagerUserToAddress.Delete(toDelete);
            }
        }
    }
}
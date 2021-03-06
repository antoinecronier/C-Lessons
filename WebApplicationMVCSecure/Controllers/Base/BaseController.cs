﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebApplicationMVCSecure.Database;
using WebApplicationMVCSecure.Models.Base;
using WebApplicationMVCSecure.Utils.FlashMessage;

namespace WebApplicationMVCSecure.Controllers.Base
{
    /*
     * Add flash notification
     * Country selector from .NET hardcoded
     * Ajax autocompletion "ex city"
     * Minimise js & css => network only one js
     * 
     */

    public abstract class BaseController<T> : Controller where T : BaseModel
    {
        public const string INDEX = "Index";

        protected SQLManager<T> dataManager;

        public BaseController()
        {
            this.dataManager = new SQLManager<T>(DataConnectionResource.LOCALMSSQLSERVER);
        }

        [HttpGet]
        [Authorize]
        public virtual async Task<ActionResult> Index()
        {
            List<T> items = (await dataManager.Get()).ToList();
            return View(items);
        }

        [HttpGet]
        [Authorize]
        public virtual async Task<ActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public virtual async Task<ActionResult> Create(T item)
        {
            if (ModelState.IsValid)
            {
                await dataManager.Insert(item);
            }
            return RedirectToAction(INDEX).Success("item with new id : "+item.Id+ " has been created");
        }

        [HttpGet]
        [Authorize]
        public virtual async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            T item = await dataManager.Get(id);

            if (item == null)
            {
                return HttpNotFound();
            }

            return View(item);
        }

        [HttpPost, ActionName("Delete")]
        [Authorize]
        [ValidateAntiForgeryToken]
        public virtual async Task<ActionResult> DeleteConfirmed(int? id)
        {
            if (ModelState.IsValid)
            {
                T item = (T)Activator.CreateInstance(typeof(T));
                item = await dataManager.Get(id);
                await dataManager.Delete(item);
            }
            return RedirectToAction(INDEX).Error("item with id : " + id + " has been deleted");
        }

        [HttpGet]
        [Authorize]
        public virtual async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            T item = await dataManager.Get(id);

            if (item == null)
            {
                return HttpNotFound();
            }

            return View(item);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public virtual async Task<ActionResult> Edit(T item)
        {
            if (ModelState.IsValid)
            {
                await dataManager.Update(item);
            }
            return RedirectToAction(INDEX).Information("item with id : " + item.Id + " has been deleted");
        }

        [HttpGet]
        [Authorize]
        public virtual async Task<ActionResult> Detail(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            T item = await dataManager.Get(id);

            if (item == null)
            {
                return HttpNotFound();
            }

            return View(item);
        }
    }
}
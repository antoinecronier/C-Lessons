using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication2.Controllers
{
    public class ClassEController : Controller
    {
        // GET: ClassE
        public ActionResult Index()
        {
            return View();
        }

        // GET: ClassE/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ClassE/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClassE/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ClassE/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ClassE/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ClassE/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ClassE/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

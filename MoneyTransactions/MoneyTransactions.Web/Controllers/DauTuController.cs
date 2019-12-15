using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MoneyTransactions.WEB.Controllers
{
    public class DauTuController : Controller
    {
        [HttpGet]
        public ActionResult DienDan()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Article1()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Article2()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Article3()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Article4()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Article5()
        {
            return View();
        }

        // GET: DauTu/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DauTu/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DauTu/Create
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

        // GET: DauTu/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DauTu/Edit/5
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

        // GET: DauTu/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DauTu/Delete/5
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

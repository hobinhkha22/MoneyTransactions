using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MoneyTransactions.WEB.Controllers
{
    public class TransasctionController : Controller
    {
        // GET: Transasction
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        // GET: Transasction/Details/5
        [HttpGet]
        public ActionResult SellDetails(string id)
        {
            return View();
        }

        [HttpGet]
        public ActionResult BuyDetails(string id)
        {
            return View();
        }

        // GET: Transasction/Create
        [HttpGet]
        public ActionResult CreateSell()
        {
            return View();
        }

        // POST: Transasction/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateSell(FormCollection collection)
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

        // GET: Transasction/Edit/5
        [HttpGet]
        public ActionResult CreateBuy(string id)
        {
            return View();
        }

        // POST: Transasction/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateBuy(string id, FormCollection collection)
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

        // GET: Transasction/Delete/5
        [HttpGet]
        public ActionResult Delete(string id)
        {
            return View();
        }

        // POST: Transasction/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string id, FormCollection collection)
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

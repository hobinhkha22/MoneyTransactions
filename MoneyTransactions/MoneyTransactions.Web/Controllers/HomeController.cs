using MoneyTransactions.BUS.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MoneyTransactions.WEB.Controllers
{
    public class HomeController : Controller
    {
        private OrderServices _orderServices = new OrderServices();
        private WalletServices _walletServices = new WalletServices();

        // GET: Home
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Index()
        {
            // This is login
            //ViewBag.ForAccount = "@Html.ActionLink('Đăng nhập / Đăng ký', 'Login', 'Account')";                       

            return View(_orderServices.ShowRecentTransaction().Take(5));
        }

        // GET: Home/Details/5
        [HttpGet]
        public ActionResult Details(string id)
        {
            return View();
        }

        // GET: Home/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Home/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
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

        // GET: Home/Edit/5
        [HttpGet]
        public ActionResult Edit(string id)
        {
            return View();
        }

        // POST: Home/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string id, FormCollection collection)
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

        // GET: Home/Delete/5
        [HttpGet]
        public ActionResult Delete(string id)
        {
            return View();
        }

        // POST: Home/Delete/5
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

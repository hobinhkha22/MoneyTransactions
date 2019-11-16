using MoneyTransactions.BUS.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MoneyTransactions.WEB.Controllers
{
    public class CryptoCurrencyController : Controller
    {
        private readonly AccountService accountService = new AccountService();
        private readonly WalletServices walletServices = new WalletServices();
        private readonly OrderServices orderServices = new OrderServices();
        private readonly CryptocurrencyStoreServices cryptocurrencyStoreServices = new CryptocurrencyStoreServices();

        // GET: CryptoCurrency
        public ActionResult Index()
        {
            return View();
        }

        // GET: CryptoCurrency/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        [HttpGet]
        public ActionResult UpdateMoney(string moneyType)
        {
            return Json(cryptocurrencyStoreServices.ShowFloorPrice(moneyType), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: CryptoCurrency/Create
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

        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CryptoCurrency/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
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

        [HttpGet]
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CryptoCurrency/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
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

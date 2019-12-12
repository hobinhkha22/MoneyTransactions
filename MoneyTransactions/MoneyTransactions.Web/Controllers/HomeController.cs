﻿using MoneyTransactions.BUS.Services;
using MoneyTransactions.Common;
using MoneyTransactions.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using PagedList;
using System.Web.Script.Serialization;

namespace MoneyTransactions.WEB.Controllers
{
    public class HomeController : Controller
    {
        private readonly AccountService accountService = new AccountService();
        private OrderServices _orderServices = new OrderServices();
        private WalletServices _walletServices = new WalletServices();
        private readonly CryptocurrencyStoreServices cryptocurrencyStoreServices = new CryptocurrencyStoreServices();

        // GET: Home      
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Index(int? pageSell, int? pageBuy)
        {
            if (pageSell != null)
            {
                int pageSize = 5;
                int pageIndex = 1;
                pageIndex = pageSell.HasValue ? Convert.ToInt32(pageSell) : 1;
                IPagedList<Order> o = null;

                o = _orderServices.ShowRecentTransaction().ToPagedList(pageIndex, pageSize);
                return View(o);
            }

            if (pageBuy != null)
            {
                int pageSize = 5;
                int pageIndex = 1;
                pageIndex = pageBuy.HasValue ? Convert.ToInt32(pageBuy) : 1;
                IPagedList<Order> o = null;

                o = _orderServices.ShowRecentTransaction().ToPagedList(pageIndex, pageSize);
                return View(o);
            }

            IPagedList<Order> i = _orderServices.ShowRecentTransaction().ToPagedList(1, 5);

            return View(i);
        }

        [HttpGet]
        public PartialViewResult ForSellIndex(int? pageSell)
        {
            int pageSize = 10;
            int pageIndex = 1;
            pageIndex = pageSell.HasValue ? Convert.ToInt32(pageSell) : 1;
            IPagedList<Order> o = null;

            o = _orderServices.ShowRecentTransaction().ToPagedList(pageIndex, pageSize);

            return PartialView(o);
        }

        [HttpGet]
        public PartialViewResult ForBuyIndex(int? pageBuy)
        {
            int pageSize = 10;
            int pageIndex = 1;
            pageIndex = pageBuy.HasValue ? Convert.ToInt32(pageBuy) : 1;
            IPagedList<Order> o = null;

            o = _orderServices.ShowRecentTransaction().ToPagedList(pageIndex, pageSize);

            return PartialView(o);
        }

        [HttpGet]
        public ActionResult UpdateMoney(string moneyType)
        {
            return Json(cryptocurrencyStoreServices.ShowFloorPrice(moneyType), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult FindWallet(string moneyType)
        {
            if (Session["AccountLogged"] != null)
            {
                var getUser = accountService.FindUserByUserName(Session["AccountLogged"].ToString());
                if (getUser != null)
                {
                    var WalletByTwoConditions = _walletServices.FindWalletByAccountIdAndMoneyType(getUser.AccountID, moneyType);
                    return Json(WalletByTwoConditions.WalletAddress, JsonRequestBehavior.AllowGet);
                }

            }

            return Json("", JsonRequestBehavior.AllowGet);
        }

        // GET: Home/Details/5
        [HttpGet]
        public ActionResult Details(string id)
        {
            return View();
        }

        [HttpGet]
        public ActionResult QuickTrade()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GetListOrder(string amountSearch)
        {
            var regex = new Regex("^-?[0-9]*(\\.|\\,)?[0-9]+$");

            if (regex.IsMatch(amountSearch))
            {
                var changes = decimal.Parse(amountSearch);
                var changed = _orderServices.GetOrdersByAmount(changes);

                var json = "";
                json = JsonConvert.SerializeObject(changed);

                return Json(json, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("", JsonRequestBehavior.AllowGet);
            }
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


        [HttpGet]
        public ActionResult MyProfile()
        {
            if (Session["AccountLogged"] != null)
            {
                var getUser = accountService.FindUserByUserName(Session["AccountLogged"].ToString());
                if (getUser != null)
                {
                    //var getWallet = _walletServices.FindWalletByAccountIdAndMoneyType(getUser.AccountID, CryptoCurrencyCommon.Bitcoin.ToString());
                    var getListWallet = _walletServices.ListWalletByAccountID(getUser.AccountID);

                    ViewBag.YourBTC = getListWallet.FirstOrDefault(b => b.CryptocurrencyStore.MoneyType.ToLower() == CryptoCurrencyCommon.Bitcoin.ToLower().ToString()).BalanceAmount;
                    ViewBag.YourETH = getListWallet.FirstOrDefault(b => b.CryptocurrencyStore.MoneyType.ToLower() == CryptoCurrencyCommon.Ethereum.ToLower().ToString()).BalanceAmount;
                    ViewBag.YourXRP = getListWallet.FirstOrDefault(b => b.CryptocurrencyStore.MoneyType.ToLower() == CryptoCurrencyCommon.Ripple.ToLower().ToString()).BalanceAmount;

                    // Wallet Address
                    //ViewBag.WalletAddressBTC = getListWallet.FirstOrDefault(b => b.CryptocurrencyStore.MoneyType.ToLower() == CryptoCurrencyCommon.Bitcoin.ToLower().ToString()).WalletAddress;
                    //ViewBag.WalletAddressETH = getListWallet.FirstOrDefault(b => b.CryptocurrencyStore.MoneyType.ToLower() == CryptoCurrencyCommon.Ethereum.ToLower().ToString()).WalletAddress;                    
                    //ViewBag.WalletAddressXRP = getListWallet.FirstOrDefault(b => b.CryptocurrencyStore.MoneyType.ToLower() == CryptoCurrencyCommon.Ripple.ToLower().ToString()).WalletAddress;

                    // get username
                    ViewBag.UserName = getUser.UserName;
                    ViewBag.Email = getUser.Email;
                    ViewBag.Phone = getUser.Phone;
                }
            }

            return View();
        }

        [HttpGet]
        public ActionResult Setting()
        {
            return View();
        }

        [HttpGet]
        public ActionResult YourWallet()
        {
            if (Session["AccountLogged"] == null)
            {
                //FormsAuthentication.SignOut();
                Session.Abandon();
            }

            return View();
        }

        [HttpGet]
        public ActionResult CommingSoon()
        {
            return View();
        }
    }
}

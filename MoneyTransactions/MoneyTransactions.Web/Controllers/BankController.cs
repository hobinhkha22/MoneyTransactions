using MoneyTransactions.BUS.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MoneyTransactions.WEB.Controllers
{
    public class BankController : Controller
    {
        private BankServices bankServices = new BankServices();
        private AccountService accountService = new AccountService();
        private WalletServices walletService = new WalletServices();
        /// <summary>
        /// Website for bank simulator        
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(FormCollection collection)
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
        public ActionResult LogOut(int id)
        {
            return View();
        }

        [HttpGet]
        public ActionResult DepositFromBank(Guid walletID, string isType)
        {
            var getWall = walletService.FindWalletByAccountIdAndMoneyType(walletID, isType);
            if (getWall != null)
            {
                return View(getWall);
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DepositFromBank(FormCollection form)
        {
            // Guid accountID, string isType, string walletAddress, decimal luongTienNap
            if (form["diaChiVi"] != "")
            {
                var luongtienNap = decimal.Parse(form["luongTienNap"]);
                var findWallet = walletService.FindWalletByWalletAddress(form["diaChiVi"]);
                var accInside = accountService.FindUserById(Guid.Parse(form["NapTienAccountID"]));
                var result = bankServices.NapTien(accInside, findWallet, luongtienNap);

                if (result)
                {
                    ViewBag.YourColorNapTien = "green";
                    ViewBag.NapTienResult = "Nạp tiền thành công";
                }
            }

            ViewBag.YourColorNapTien = "red";
            ViewBag.NapTienResult = "Nạp tiền thất bại";

            return View();
        }


        [HttpGet]
        public ActionResult WithdrawToBank(Guid walletID)
        {
            var getWall = walletService.FindWalletByAccountId(walletID);
            if (getWall != null)
            {
                return View(getWall);
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult WithdrawToBank(FormCollection form)
        {
            // Guid accountID, string isType, string walletAddress, decimal luongTienNap
            if (form["diaChiVi"] != "")
            {
                var luongtienNap = decimal.Parse(form["luongTienNap"]);
                var findWallet = walletService.FindWalletByWalletAddress(form["diaChiVi"]);
                var accInside = accountService.FindUserById(Guid.Parse(form["NapTienAccountID"]));
                var result = bankServices.NapTien(accInside, findWallet, luongtienNap);

                if (result)
                {
                    ViewBag.YourColorNapTien = "green";
                    ViewBag.NapTienResult = "Nạp tiền thành công";
                }
            }

            ViewBag.YourColorNapTien = "red";
            ViewBag.NapTienResult = "Nạp tiền thất bại";


            return View();
        }

        [HttpGet]
        public ActionResult RutTien(Guid accountID, string isType, string moneyType, decimal luongTienNap)
        {
            if (isType == "RutTien")
            {
                var acc = accountService.FindUserById(accountID);
                var accBankDetail = bankServices.FindAccountBankDetailByAccountID(accountID);
                var findWallet = walletService.FindWalletByAccountIdAndMoneyType(acc.AccountID, moneyType);
                bankServices.NapTien(accBankDetail, findWallet, moneyType, luongTienNap);
            }
            return View();
        }
    }
}

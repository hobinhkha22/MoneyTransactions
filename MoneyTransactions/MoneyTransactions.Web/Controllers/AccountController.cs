using MoneyTransactions.BUS.Services;
using MoneyTransactions.DAL;
using MoneyTransactions.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MoneyTransactions.WEB.Controllers
{
    public class AccountController : Controller
    {
        private readonly AccountService accountService = new AccountService();
        private readonly WalletServices walletServices = new WalletServices();
        private readonly OrderServices orderServices = new OrderServices();

        // GET: Account
        [HttpGet]
        public ActionResult Index()
        {
            //orderServices.CreateTransaction(new Guid(), 0.5m, 0.3m);            
            return View(orderServices.ShowRecentTransaction());
        }

        // GET: Account/Details/5
        [HttpGet]
        public ActionResult Details(string walletID)
        {
            var getAcc = orderServices.FindOrderByWalletID(Guid.Parse(walletID));
            if (getAcc != null)
            {
                ViewBag.username = getAcc.Wallet.Account.UserName;
                return View(getAcc);
            }
            else
            {
                return View("Error");
            }
        }

        // GET: Account/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Account/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                string username = collection["Username"];
                string password = collection["Password"];
                string phone = collection["Phone"];
                string email = collection["Email"];
                string nickname = collection["Nickname"];

                accountService.CreateAccount(username, password, phone, email, nickname);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Account/Edit/5
        public ActionResult Edit(string id)
        {
            return View();
        }

        // POST: Account/Edit/5
        [HttpPost]
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

        // GET: Account/Delete/5
        public ActionResult Delete(string id)
        {
            return View();
        }

        // POST: Account/Delete/5
        [HttpPost]
        public ActionResult Delete(string id, FormCollection collection)
        {
            try
            {
                // TODO : DO SOMETHING

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Account userModel)
        {
            string username = userModel.UserName;
            var usermodel = accountService.FindUser(username, userModel.Password);

            if (usermodel == null)
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {
                if (usermodel.UserName.ToLower() == "admin" || usermodel.UserName.ToUpperInvariant() == "admin@gmail.com")
                {
                    Session["AccountLogged"] = usermodel.UserName;
                    return RedirectToAction("AdminPage", "Account");
                }

                Session["AccountLogged"] = usermodel.UserName;
                Session["getWalletID"] = usermodel.AccountID;
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpGet]
        public ActionResult AdminPage()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(FormCollection formCollection)
        {
            var username = formCollection["Username"];
            var password = formCollection["Password"];
            var confirmPassword = formCollection["ConfirmPassword"];

            if (password.ToString().ToLower() != confirmPassword.ToString().ToLower())
            {
                // wrong
                return RedirectToAction("Register", "Account");
            }

            // create account
            accountService.CreateAccount(username, password, confirmPassword);

            // Create wallet after account created
            var findCreatedAccount = accountService.FindUser(username, password);
            walletServices.CreateWallet(findCreatedAccount.AccountID);

            Session["AccountLogged"] = findCreatedAccount.UserName;

            return RedirectToAction("Index", "Account");
        }

        [HttpGet]
        public ActionResult WithdrawFromAddress()
        {
            return PartialView();
        }

        [HttpGet]
        public ActionResult DepositToAddress()
        {
            return PartialView();
        }

        [HttpGet]
        public ActionResult MustLogin()
        {
            if (Session["getWalletID"] == null)
            {
                return RedirectToAction("Login", "Account");
            }

            return View();
        }

        [HttpGet]
        [Obsolete]
        public ActionResult Buy(string sellerID, string buyerID, decimal amount)
        {
            orderServices.CreateBuyTransactionNoComplex(Guid.Parse(sellerID), Guid.Parse(buyerID), amount);

            return RedirectToAction("Index", "Home");
        }
    }
}

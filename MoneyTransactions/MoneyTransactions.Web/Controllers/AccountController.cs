using MoneyTransactions.BUS.Models;
using MoneyTransactions.BUS.Services;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MoneyTransactions.WEB.Controllers
{
    public class AccountController : Controller
    {
        private readonly AccountService accountService = new AccountService();
        private readonly WalletServices walletServices = new WalletServices();

        // GET: Account
        [HttpGet]
        public ActionResult Index()
        {            
            return View(accountService.GetAccounts());
        }

        // GET: Account/Details/5
        [HttpGet]
        public ActionResult Details(int id)
        {
            return View();
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
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Account/Edit/5
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

        [HttpGet]
        public ActionResult Detail(int id)
        {
            return View();
        }

        // GET: Account/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Account/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
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
        public ActionResult Login(UserModel userModel)
        {
            string username = userModel.Username;
            string password = userModel.Password;
            var usermodel = accountService.FindUser(username, password);

            if (usermodel == null)
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {
                if (usermodel.Username.ToLower() == "admin" || usermodel.Username.ToUpperInvariant() == "admin@gmail.com")
                {
                    return RedirectToAction("AdminPage", "Account");
                }

                if (usermodel.Username.ToLower() == "user1" || usermodel.Username.ToUpperInvariant() == "user1@gmail.com")
                {
                    return RedirectToAction("Index", "Home");
                }

                if (usermodel.Username.ToLower() == "user2" || usermodel.Username.ToUpperInvariant() == "user2@gmail.com")
                {
                    return RedirectToAction("Index", "Home");
                }
            }

            return RedirectToAction("Login", "Account");
        }

        [HttpGet]
        public ActionResult AdminPage()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Logout()
        {
            return View();
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
            walletServices.CreateWallet(findCreatedAccount.Id);
            ViewBag.ForAccount = findCreatedAccount.Username;

            return RedirectToAction("Index", "Account");
        }
    }
}

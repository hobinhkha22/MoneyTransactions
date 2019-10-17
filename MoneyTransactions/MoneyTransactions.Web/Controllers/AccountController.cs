using MoneyTransactions.BUS.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MoneyTransactions.WEB.Controllers
{
    public class AccountController : Controller
    {
        private readonly AccountService accountService = new AccountService();

        // GET: Account
        public ActionResult Index()
        {
            return View(accountService.GetAccounts());
        }

        // GET: Account/Details/5
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
        public ActionResult Login(FormCollection collection)
        {
            string username = collection["Username"];
            string password = collection["Password"];
            var usermodel = accountService.FindUser(username, password);

            if (usermodel == null)
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {
                if (usermodel.Username.ToLower() == "admin" || usermodel.Username.ToLower() == "admin@gmail.com")
                {
                    return RedirectToAction("AdminPage", "Account");
                }

                if (usermodel.Username.ToLower() == "user1" || usermodel.Username.ToLower() == "user1@gmail.com")
                {
                    return RedirectToAction("Index", "Home");
                }

                if (usermodel.Username.ToLower() == "user2" || usermodel.Username.ToLower() == "user2@gmail.com")
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

    }
}

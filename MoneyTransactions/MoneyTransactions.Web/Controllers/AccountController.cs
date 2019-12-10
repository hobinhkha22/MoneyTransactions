using MoneyTransactions.BUS.Services;
using MoneyTransactions.Common;
using MoneyTransactions.DAL;
using MoneyTransactions.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using PagedList;

namespace MoneyTransactions.WEB.Controllers
{
    public class AccountController : Controller
    {
        private readonly AccountService accountService = new AccountService();
        private readonly WalletServices walletServices = new WalletServices();
        private readonly OrderServices orderServices = new OrderServices();
        private readonly CryptocurrencyStoreServices cryptocurrencyStoreServices = new CryptocurrencyStoreServices();

        // GET: Account
        [HttpGet]
        public ActionResult Index()
        {
            if (Session["AccountLogged"] == null)
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {
                return View(orderServices.ShowRecentTransaction());
            }
        }

        [HttpGet]
        public ActionResult Index(int? page)
        {
            if (Session["AccountLogged"] == null)
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {
                int pageSize = 5;
                int pageIndex = 1;
                pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
                IPagedList<Order> o = null;

                o = orderServices.ShowRecentTransaction().ToPagedList(pageIndex, pageSize);
                return View(o);
            }
        }

        // GET: Account/Details/5
        [HttpGet]
        public ActionResult Details(string walletID, decimal amount)
        {
            if (Session["AccountLogged"] != null)
            {
                var getAcc = orderServices.FindOrderByWalletIDAndAmount(Guid.Parse(walletID), amount);
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

            return RedirectToAction("Login", "Account");
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
            var usermodel = accountService.FindUser(userModel.UserName, userModel.Password);

            if (usermodel == null)
            {
                TempData["Feedback"] = "The username or password does exist.";
                return RedirectToAction("Login", "Account");
            }
            else
            {
                var findUserWithRole = accountService.FindUerWithRole(usermodel.UserName, usermodel.Password, usermodel.Role.RoleName);
                if (findUserWithRole == null)
                {
                    TempData["Feedback"] = "The username or password does exist.";
                    return RedirectToAction("Login", "Account");
                }
                else
                {
                    if (findUserWithRole.Role.RoleName == AccountConstant.AdminRole)
                    {
                        // for admin
                        Session["AccountLogged"] = usermodel.UserName;
                        return RedirectToAction("AdminPage", "Account");
                    }
                }

                // for user 
                Session["AccountLogged"] = usermodel.UserName;
                Session["getWalletID"] = usermodel.AccountID;
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpGet]
        public ActionResult AdminPage()
        {
            if (Session["AccountLogged"] == null)
            {
                return RedirectToAction("Login", "Account");
            }

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

            return RedirectToAction("Index", "Home");
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
        public ActionResult CreateSellAd(string getMoneyType)
        {
            if (Session["AccountLogged"] != null)
            {
                var getUser = accountService.FindUserByUserName(Session["AccountLogged"].ToString());
                if (getUser != null)
                {
                    var getWalletByMoneyType = walletServices.FindWalletByAccountIdAndMoneyType(getUser.AccountID, getMoneyType);
                    ViewBag.GetDiaChiVi = getWalletByMoneyType.WalletAddress.ToString();
                }

                ViewBag.AccountTradeName = Session["AccountLogged"].ToString();
            }

            var getFloorPrice = cryptocurrencyStoreServices.ShowFloorPrice(getMoneyType);
            var moneyConverted = Convert.ToDecimal(getFloorPrice.ToString()).ToString("#,##");

            ViewBag.getMoney = moneyConverted;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateSellAd(FormCollection order)
        {
            if (Session["AccountLogged"] == null)
            {
                return RedirectToAction("Login", "Account");
            }

            var getUserWallet = walletServices.FindWalletByWalletAddress(order["diachivi"].ToString());
            if (getUserWallet != null)
            {
                // check dieu kien dang mua
                if (getUserWallet.BalanceAmount <= decimal.Parse(order["amount"].ToString()))
                {
                    ViewBag.errorMessage = "Tài khoản không đủ lượng coin giao dịch.";

                    // fix the accountname
                    ViewBag.AccountTradeName = getUserWallet.Account.UserName;

                    // fix walletaddress
                    ViewBag.GetDiaChiVi = getUserWallet.WalletAddress;

                    // fix the selected coin
                    if (order["selected_bitcoin"].ToString() == CryptoCurrencyCommon.Bitcoin.ToLower()) // for bitcoin
                    {
                        ViewBag.isSelected = "selected";
                    }

                    if (order["selected_bitcoin"].ToString() == CryptoCurrencyCommon.Ethereum.ToLower()) // for ethereum
                    {
                        ViewBag.isSelected = "selected";
                    }

                    if (order["selected_bitcoin"].ToString() == CryptoCurrencyCommon.Ripple.ToLower()) // for ripple
                    {
                        ViewBag.isSelected = "selected";
                    }

                    // fix the value money changed
                    ViewBag.getMoney = Convert.ToDecimal(getUserWallet.CryptocurrencyStore.FloorPrice.ToString()).ToString("#,##");

                    return View();
                }
            }

            var orderDb = new Order();
            if (order != null)
            {
                orderDb.Price = decimal.Parse(order["giatriquydoi"].ToString());
                orderDb.Amount = decimal.Parse(order["amount"].ToString());


                var getWallet = walletServices.FindWalletByWalletAddress(order["diachivi"].ToString());
                // handle order sell
                orderDb.OrderID = Guid.NewGuid();
                orderDb.CreatedDate = DateTime.Now;
                orderDb.ModifiedDate = DateTime.Now;
                orderDb.OrderType = OrderCommon.OrderSell;
                orderDb.OrderDetails = new List<OrderDetail>() { new OrderDetail() { OrderDetailID = Guid.NewGuid(), OrderID = orderDb.OrderID, WalletID = getWallet.WalletID, Amount = orderDb.Amount, CreatedDate = orderDb.CreatedDate } };
                orderDb.WalletID = getWallet.WalletID;

                // tru phan tien da dang ban
                getWallet.BalanceAmount = getWallet.BalanceAmount - orderDb.Amount;
                orderDb.Price = orderDb.Amount; // luong sell/buy se save tai price

                orderServices.CreateOrderTransaction(orderDb); // dang order

                return RedirectToAction("Index", "Home");
            }

            ViewBag.errorMessage = "Không thể tạo được giao dịch. Vui lòng thử lại";
            return View();
        }

        [HttpGet]
        public ActionResult CreateBuyAd(string getMoneyType)
        {
            if (Session["AccountLogged"] != null)
            {
                ViewBag.AccountTradeNameBuy = Session["AccountLogged"].ToString();

                var getUser = accountService.FindUserByUserName(Session["AccountLogged"].ToString());
                if (getUser != null)
                {
                    var getWalletByMoneyType = walletServices.FindWalletByAccountIdAndMoneyType(getUser.AccountID, getMoneyType);
                    ViewBag.GetDiaChiViMua = getWalletByMoneyType.WalletAddress.ToString();
                }
            }

            var getFloorPrice = cryptocurrencyStoreServices.ShowFloorPrice(getMoneyType);
            var moneyConverted = Convert.ToDecimal(getFloorPrice.ToString()).ToString("#,##");

            ViewBag.getMoney = moneyConverted;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateBuyAd(FormCollection order)
        {
            if (Session["AccountLogged"] == null)
            {
                return RedirectToAction("Login", "Account");
            }

            var getUserWallet = walletServices.FindWalletByWalletAddress(order["diachivi"].ToString());
            if (getUserWallet != null)
            {
                // check dieu kien dang mua
                if (getUserWallet.BalanceAmount <= decimal.Parse(order["amount"].ToString()))
                {
                    ViewBag.errorMessage = "Tài khoản không đủ lượng coin giao dịch.";

                    // fix the accountname
                    ViewBag.AccountTradeNameBuy = getUserWallet.Account.UserName;

                    // fix walletaddress
                    ViewBag.GetDiaChiViMua = getUserWallet.WalletAddress;

                    // fix the selected tag

                    // fix the selected coin
                    if (order["selected_bitcoin"].ToString() == CryptoCurrencyCommon.Bitcoin.ToLower()) // for bitcoin
                    {
                        ViewBag.isSelected = "selected";
                    }

                    if (order["selected_bitcoin"].ToString() == CryptoCurrencyCommon.Ethereum.ToLower()) // for ethereum
                    {
                        ViewBag.isSelected = "selected";
                    }

                    if (order["selected_bitcoin"].ToString() == CryptoCurrencyCommon.Ripple.ToLower().ToString()) // for ripple
                    {
                        ViewBag.isSelected = "selected";
                    }

                    // fix the value money changed
                    ViewBag.getMoney = Convert.ToDecimal(getUserWallet.CryptocurrencyStore.FloorPrice.ToString()).ToString("#,##");

                    return View();
                }
            }

            var orderDb = new Order();

            if (order != null)
            {

                orderDb.Price = decimal.Parse(order["giatriquydoi"].ToString());
                orderDb.Amount = decimal.Parse(order["amount"].ToString());

                var getWallet = walletServices.FindWalletByWalletAddress(order["diachivi"].ToString());
                // handle order sell
                orderDb.OrderID = Guid.NewGuid();
                orderDb.CreatedDate = DateTime.Now;
                orderDb.ModifiedDate = DateTime.Now;
                orderDb.OrderType = OrderCommon.OrderBuy;
                orderDb.OrderDetails = new List<OrderDetail>() { new OrderDetail() { OrderDetailID = Guid.NewGuid(), OrderID = orderDb.OrderID, WalletID = getWallet.WalletID, Amount = orderDb.Amount, CreatedDate = orderDb.CreatedDate } };
                orderDb.WalletID = getWallet.WalletID;

                // tru phan tien da dang ban
                getWallet.BalanceAmount -= orderDb.Amount;
                orderDb.Price = orderDb.Amount; // luong sell/buy se save tai price

                orderServices.CreateOrderTransaction(orderDb); // dang order


                return RedirectToAction("Index", "Home");
            }

            ViewBag.errorMessage = "Không thể tạo được giao dịch. Vui lòng thử lại";
            return View();
        }

        [HttpGet]
        [Obsolete]
        public ActionResult Buy(string sellerID, string buyerID, decimal amount)
        {
            var getOrder = orderServices.FindOrderByAccountIDAndAmount(Guid.Parse(sellerID), amount);
            if (getOrder != null)
            {
                if (getOrder.Wallet.AccountID == Guid.Parse(buyerID))
                {
                    ViewBag.DuplicateOrderBuyer = "Không thể mua Order của chính mình.";
                    ViewBag.username = getOrder.Wallet.Account.UserName;
                    return View("Details", getOrder);
                }

                orderServices.HandleTransaction(Guid.Parse(sellerID), Guid.Parse(buyerID), amount, getOrder);
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [Obsolete]
        public ActionResult Sell(string sellerID, string buyerID, decimal amount)
        {
            var getOrder = orderServices.FindOrderByAccountIDAndAmount(Guid.Parse(sellerID), amount);
            if (getOrder != null)
            {
                if (getOrder.Wallet.AccountID == Guid.Parse(sellerID))
                {
                    ViewBag.DuplicateOrderSeller = "Không thể bán Order cho chính mình.";
                    ViewBag.username = getOrder.Wallet.Account.UserName;
                    return View("Details", getOrder);
                }
                orderServices.HandleTransaction(Guid.Parse(sellerID), Guid.Parse(buyerID), amount, getOrder);
            }

            return RedirectToAction("Index", "Home");
        }
    }
}

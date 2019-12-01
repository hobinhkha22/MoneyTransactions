using MoneyTransactions.BUS.Services;
using MoneyTransactions.Common;
using MoneyTransactions.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
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
        public ActionResult Index()
        {
            // This is login
            //ViewBag.ForAccount = "@Html.ActionLink('Đăng nhập / Đăng ký', 'Login', 'Account')";

            // wallet for vnd
            // 2
            var walletVNDAddress = CreateAddress();
            Wallet walletvND = new Wallet
            {
                WalletID = Guid.NewGuid(),
                CryptocurrencyStoreID = Guid.Parse("31d1891a-aa22-4d8d-aa31-07c2ad4c771a"),
                AccountID = Guid.Parse("F0A61699-C1A4-4D8D-935F-257B2B58915A"),
                WalletAddress = walletVNDAddress.Values.ElementAt(0),
                PrivateKey = walletVNDAddress.Keys.ElementAt(0),
                BalanceAmount = 0,
                BalanceAmountTransaction = 0
            };

            // 3
            var walletVNDAddress3 = CreateAddress();
            Wallet walletvND3 = new Wallet
            {
                WalletID = Guid.NewGuid(),
                CryptocurrencyStoreID = Guid.Parse("31d1891a-aa22-4d8d-aa31-07c2ad4c771a"),
                AccountID = Guid.Parse("086DD5F3-7BCF-4342-BD80-2EF2A667F6FE"),
                WalletAddress = walletVNDAddress3.Values.ElementAt(0),
                PrivateKey = walletVNDAddress3.Keys.ElementAt(0),
                BalanceAmount = 0,
                BalanceAmountTransaction = 0
            };

            // 4            
            var walletVNDAddress4 = CreateAddress();
            Wallet walletvND4 = new Wallet
            {
                WalletID = Guid.NewGuid(),
                CryptocurrencyStoreID = Guid.Parse("31d1891a-aa22-4d8d-aa31-07c2ad4c771a"),
                AccountID = Guid.Parse("C098FFD7-E70A-48B8-9D40-46949789C048"),
                WalletAddress = walletVNDAddress4.Values.ElementAt(0),
                PrivateKey = walletVNDAddress4.Keys.ElementAt(0),
                BalanceAmount = 0,
                BalanceAmountTransaction = 0
            };

            // 5
            var walletVNDAddress5 = CreateAddress();
            Wallet walletvND5 = new Wallet
            {
                WalletID = Guid.NewGuid(),
                CryptocurrencyStoreID = Guid.Parse("31d1891a-aa22-4d8d-aa31-07c2ad4c771a"),
                AccountID = Guid.Parse("0CBBD18F-80C6-4E53-A6A2-47A1E0170DD4"),
                WalletAddress = walletVNDAddress5.Values.ElementAt(0),
                PrivateKey = walletVNDAddress5.Keys.ElementAt(0),
                BalanceAmount = 0,
                BalanceAmountTransaction = 0
            };

            // 6
            var walletVNDAddress6 = CreateAddress();
            Wallet walletvND6 = new Wallet
            {
                WalletID = Guid.NewGuid(),
                CryptocurrencyStoreID = Guid.Parse("31d1891a-aa22-4d8d-aa31-07c2ad4c771a"),
                AccountID = Guid.Parse("2BE034A9-F0E2-4ACF-9F0A-548927344715"),
                WalletAddress = walletVNDAddress6.Values.ElementAt(0),
                PrivateKey = walletVNDAddress6.Keys.ElementAt(0),
                BalanceAmount = 0,
                BalanceAmountTransaction = 0
            };
            // 7
            var walletVNDAddress7 = CreateAddress();
            Wallet walletvND7 = new Wallet
            {
                WalletID = Guid.NewGuid(),
                CryptocurrencyStoreID = Guid.Parse("31d1891a-aa22-4d8d-aa31-07c2ad4c771a"),
                AccountID = Guid.Parse("64D579CE-827D-44DB-9E54-C06B068D5ED9"),
                WalletAddress = walletVNDAddress7.Values.ElementAt(0),
                PrivateKey = walletVNDAddress7.Keys.ElementAt(0),
                BalanceAmount = 0,
                BalanceAmountTransaction = 0
            };
            // 8
            var walletVNDAddress8 = CreateAddress();
            Wallet walletvND8 = new Wallet
            {
                WalletID = Guid.NewGuid(),
                CryptocurrencyStoreID = Guid.Parse("31d1891a-aa22-4d8d-aa31-07c2ad4c771a"),
                AccountID = Guid.Parse("30534FE7-594C-416C-8F77-DA87044595FA"),
                WalletAddress = walletVNDAddress8.Values.ElementAt(0),
                PrivateKey = walletVNDAddress8.Keys.ElementAt(0),
                BalanceAmount = 0,
                BalanceAmountTransaction = 0
            };
            // 9
            var walletVNDAddress9 = CreateAddress();
            Wallet walletvND9 = new Wallet
            {
                WalletID = Guid.NewGuid(),
                CryptocurrencyStoreID = Guid.Parse("31d1891a-aa22-4d8d-aa31-07c2ad4c771a"),
                AccountID = Guid.Parse("E3163D28-9FFB-48E2-BCFB-FCE1303575F7"),
                WalletAddress = walletVNDAddress9.Values.ElementAt(0),
                PrivateKey = walletVNDAddress9.Keys.ElementAt(0),
                BalanceAmount = 0,
                BalanceAmountTransaction = 0
            };
            // 10
            var walletVNDAddress10 = CreateAddress();
            Wallet walletvND10 = new Wallet
            {
                WalletID = Guid.NewGuid(),
                CryptocurrencyStoreID = Guid.Parse("31d1891a-aa22-4d8d-aa31-07c2ad4c771a"),
                AccountID = Guid.Parse("7617F09B-6ED4-40ED-8BB1-FEC58D866233"),
                WalletAddress = walletVNDAddress10.Values.ElementAt(0),
                PrivateKey = walletVNDAddress10.Keys.ElementAt(0),
                BalanceAmount = 0,
                BalanceAmountTransaction = 0
            };

            Console.ReadKey();


            //if (Session["AccountLogged"] == null)
            //{
            //    //FormsAuthentication.SignOut();
            //    Session.Abandon();
            //}

            return View(_orderServices.ShowRecentTransaction());
        }

        public Dictionary<string, string> CreateAddress()
        {
            var dic = new Dictionary<string, string>();

            NBitcoin.Key privateKey = new NBitcoin.Key(); // generate a random private key
            //BitcoinSecret mainNetPrivateKey = privateKey.GetBitcoinSecret(Network.Main); // bitcoin secret
            NBitcoin.PubKey publicKey = privateKey.PubKey;

            var address = publicKey.GetAddress(NBitcoin.ScriptPubKeyType.Legacy, NBitcoin.Network.Main);

            dic.Add(privateKey.ToString(NBitcoin.Network.Main), address.ToString());

            return dic;
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

                var json = JsonConvert.SerializeObject(changed);

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
    }
}

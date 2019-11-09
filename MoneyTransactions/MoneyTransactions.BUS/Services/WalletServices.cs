using MoneyTransactions.BUS.Interface;
using MoneyTransactions.Common;
using MoneyTransactions.DAL;
using NBitcoin;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyTransactions.BUS.Services
{
    public class WalletServices : IWallet
    {
        private readonly MoneyTransactionsDataContext db;

        public WalletServices()
        {
            db = new MoneyTransactionsDataContext();
        }

        public void CreateWallet(Guid AccountId)
        {
            // wallet for btc
            var walletBTCAddress = CreateAddress();
            Wallet walletBtc = new Wallet
            {
                WalletID = Guid.NewGuid(),
                AccountID = AccountId,
                WalletAddress = walletBTCAddress.Values.ElementAt(0),
                PrivateKey = walletBTCAddress.Keys.ElementAt(0),
                BalanceAmount = 0,
                BalanceAmountTransaction = 0
            };
            walletBtc.CryptocurrencyStores = new System.Data.Linq.EntitySet<CryptocurrencyStore>()
            {
                new CryptocurrencyStore()
                {
                    CryptocurrencyStoreID = Guid.NewGuid(),
                    Description = CryptoCurrencyCommon.BitcointDescription,
                    MoneyType = CryptoCurrencyCommon.Bitcoin,
                     WalletID = walletBtc.WalletID
                }
            };

            // wallet for ripple
            var walletRippleAddress = CreateAddress();
            Wallet walletRipple = new Wallet
            {
                WalletID = Guid.NewGuid(),
                AccountID = AccountId,
                WalletAddress = walletRippleAddress.Values.ElementAt(0),
                PrivateKey = walletRippleAddress.Keys.ElementAt(0),
                BalanceAmount = 0,
                BalanceAmountTransaction = 0
            };
            walletRipple.CryptocurrencyStores = new System.Data.Linq.EntitySet<CryptocurrencyStore>()
            {
                new CryptocurrencyStore()
                {
                    CryptocurrencyStoreID = Guid.NewGuid(),
                    Description = CryptoCurrencyCommon.RippleDescription,
                    MoneyType = CryptoCurrencyCommon.Ripple
                }
            };

            // wallet for eth
            var walletEthAddress = CreateAddress();
            Wallet walletEth = new Wallet
            {
                WalletID = Guid.NewGuid(),
                AccountID = AccountId,
                WalletAddress = walletEthAddress.Values.ElementAt(0),
                PrivateKey = walletEthAddress.Keys.ElementAt(0),
                BalanceAmount = 0,
                BalanceAmountTransaction = 0
            };
            walletEth.CryptocurrencyStores = new System.Data.Linq.EntitySet<CryptocurrencyStore>()
            {
                new CryptocurrencyStore()
                {
                    CryptocurrencyStoreID = Guid.NewGuid(),
                    Description = CryptoCurrencyCommon.EthereumDescription,
                    MoneyType = CryptoCurrencyCommon.Ethereum,
                    WalletID = walletEth.WalletID
                }
            };

            // wallet for vnd
            var walletVndAddress = CreateAddress();
            Wallet walletVnd = new Wallet
            {
                WalletID = Guid.NewGuid(),
                AccountID = AccountId,
                WalletAddress = walletVndAddress.Values.ElementAt(0),
                PrivateKey = walletVndAddress.Keys.ElementAt(0),
                BalanceAmount = 0,
                BalanceAmountTransaction = 0
            };
            walletVnd.CryptocurrencyStores = new System.Data.Linq.EntitySet<CryptocurrencyStore>()
            {
                new CryptocurrencyStore() {
                     CryptocurrencyStoreID = Guid.NewGuid(),
                     Description = CryptoCurrencyCommon.VietNamDongDescription,
                     MoneyType = CryptoCurrencyCommon.VietnamDong,
                     WalletID = walletVnd.WalletID
                }
            };

            db.Wallets.InsertOnSubmit(walletBtc);
            db.Wallets.InsertOnSubmit(walletRipple);
            db.Wallets.InsertOnSubmit(walletEth);
            db.Wallets.InsertOnSubmit(walletVnd);

            db.SubmitChanges();
        }

        /// <summary>
        /// Dictionary<string1, string2>
        /// 
        /// string1: private key
        /// string2: bitcoin address
        /// </summary>        
        /// <returns></returns>
        public Dictionary<string, string> CreateAddress()
        {
            var dic = new Dictionary<string, string>();

            Key privateKey = new Key(); // generate a random private key
            BitcoinSecret mainNetPrivateKey = privateKey.GetBitcoinSecret(Network.Main); // bitcoin secret
            PubKey publicKey = privateKey.PubKey;

            var address = publicKey.GetAddress(ScriptPubKeyType.Legacy, Network.Main);

            dic.Add(privateKey.ToString(Network.Main), address.ToString());

            return dic;
        }

        public bool UpdateWallet()
        {
            throw new NotImplementedException();
        }
    }
}

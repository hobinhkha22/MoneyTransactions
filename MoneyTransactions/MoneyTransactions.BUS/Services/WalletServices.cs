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
            // Get info crypto money
            List<CryptocurrencyStore> cryptocurrencyStore = db.CryptocurrencyStores.ToList();
            var walletBTCAddress = CreateAddress();
            // wallet for btc
            Wallet walletBtc = new Wallet();
            walletBtc.WalletID = Guid.NewGuid();
            walletBtc.AccountID = AccountId;
            walletBtc.WalletAddress = walletBTCAddress.Values.ElementAt(0);
            walletBtc.PrivateKey = walletBTCAddress.Keys.ElementAt(0);            


            var walletRippleAddress = CreateAddress();
            // wallet for ripple
            Wallet walletRipple = new Wallet
            {
                WalletID = Guid.NewGuid(),
                AccountID = AccountId,
                WalletAddress = walletRippleAddress.Values.ElementAt(0),
                PrivateKey = walletRippleAddress.Keys.ElementAt(0),                
            };

            var walletEthAddress = CreateAddress();
            // wallet for eth
            Wallet walletEth = new Wallet
            {
                WalletID = Guid.NewGuid(),
                AccountID = AccountId,
                WalletAddress = walletEthAddress.Values.ElementAt(0),
                PrivateKey = walletEthAddress.Keys.ElementAt(0),                
            };

            db.Wallets.InsertOnSubmit(walletBtc);
            db.Wallets.InsertOnSubmit(walletRipple);
            db.Wallets.InsertOnSubmit(walletEth);

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

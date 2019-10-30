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

            // wallet for btc
            Wallet walletBtc = new Wallet();
            walletBtc.WalletID = Guid.NewGuid();
            walletBtc.AccountID = AccountId;
            walletBtc.WalletAddress = CreateAddress();
            walletBtc.CryptocurrencyStoreID = cryptocurrencyStore.FirstOrDefault(x => x.MoneyType.ToLower() 
            == CryptoCurrencyCommon.Bitcoin.ToLower()).CryptocurrencyStoreID;
            

            // wallet for ripple
            Wallet walletRipple = new Wallet
            {
                WalletID = Guid.NewGuid(),
                AccountID = AccountId,
                WalletAddress = CreateAddress(),
                CryptocurrencyStoreID = cryptocurrencyStore.FirstOrDefault(x => x.MoneyType.ToLower() == CryptoCurrencyCommon.Ripple.ToLower()).CryptocurrencyStoreID
            };

            // wallet for eth
            Wallet walletEth = new Wallet
            {
                WalletID = Guid.NewGuid(),
                AccountID = AccountId,
                WalletAddress = CreateAddress(),
                CryptocurrencyStoreID = cryptocurrencyStore.FirstOrDefault(x => x.MoneyType.ToLower() == CryptoCurrencyCommon.Ethereum.ToLower()).CryptocurrencyStoreID
            };

            db.Wallets.InsertOnSubmit(walletBtc);
            db.Wallets.InsertOnSubmit(walletRipple);
            db.Wallets.InsertOnSubmit(walletEth);

            db.SubmitChanges();
        }

        private string CreateAddress()
        {
            Key privateKey = new Key(); // generate a random private key
            BitcoinSecret mainNetPrivateKey = privateKey.GetBitcoinSecret(Network.Main);
            PubKey publicKey = privateKey.PubKey;

            var address = publicKey.GetAddress(Network.Main);

            return address.ToString();
        }

        public bool UpdateWallet()
        {
            throw new NotImplementedException();
        }
    }
}

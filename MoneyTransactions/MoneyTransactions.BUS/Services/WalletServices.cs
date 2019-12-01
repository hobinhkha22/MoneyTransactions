using MoneyTransactions.Common;
using MoneyTransactions.DAL;
using MoneyTransactions.DAL.Implement;
using MoneyTransactions.Entities;
using NBitcoin;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyTransactions.BUS.Services
{
    public class WalletServices
    {
        private readonly WalletDataAccess walletDataAccess;
        private readonly CryptocurrencyStoreDataAccess cryptocurrencyStoreDataAccess;

        public WalletServices()
        {
            walletDataAccess = new WalletDataAccess();
            cryptocurrencyStoreDataAccess = new CryptocurrencyStoreDataAccess();
        }

        public void CreateWallet(Guid AccountId)
        {
            List<Wallet> wallets = new List<Wallet>();

            // wallet for vnd
            var walletVNDAddress = CreateAddress();
            Wallet walletvND = new Wallet
            {
                WalletID = Guid.NewGuid(),
                CryptocurrencyStoreID = cryptocurrencyStoreDataAccess.GetCryptocurrencyStoreByMoneyType(CryptoCurrencyCommon.VietnamDong).CryptocurrencyStoreID,
                AccountID = AccountId,
                WalletAddress = walletVNDAddress.Values.ElementAt(0),
                PrivateKey = walletVNDAddress.Keys.ElementAt(0),
                BalanceAmount = 0,
                BalanceAmountTransaction = 0
            };
            wallets.Add(walletvND);


            // wallet for btc
            var walletBTCAddress = CreateAddress();
            Wallet walletBtc = new Wallet
            {
                WalletID = Guid.NewGuid(),
                CryptocurrencyStoreID = cryptocurrencyStoreDataAccess.GetCryptocurrencyStoreByMoneyType(CryptoCurrencyCommon.Bitcoin).CryptocurrencyStoreID,
                AccountID = AccountId,
                WalletAddress = walletBTCAddress.Values.ElementAt(0),
                PrivateKey = walletBTCAddress.Keys.ElementAt(0),
                BalanceAmount = 0,
                BalanceAmountTransaction = 0
            };
            wallets.Add(walletBtc);

            // wallet for ripple
            var walletRippleAddress = CreateAddress();
            Wallet walletRipple = new Wallet
            {
                WalletID = Guid.NewGuid(),
                CryptocurrencyStoreID = cryptocurrencyStoreDataAccess.GetCryptocurrencyStoreByMoneyType(CryptoCurrencyCommon.Ripple).CryptocurrencyStoreID,
                AccountID = AccountId,
                WalletAddress = walletRippleAddress.Values.ElementAt(0),
                PrivateKey = walletRippleAddress.Keys.ElementAt(0),
                BalanceAmount = 0,
                BalanceAmountTransaction = 0
            };

            wallets.Add(walletRipple);
            // wallet for eth
            var walletEthAddress = CreateAddress();
            Wallet walletEth = new Wallet
            {
                WalletID = Guid.NewGuid(),
                CryptocurrencyStoreID = cryptocurrencyStoreDataAccess.GetCryptocurrencyStoreByMoneyType(CryptoCurrencyCommon.Ethereum).CryptocurrencyStoreID,
                AccountID = AccountId,
                WalletAddress = walletEthAddress.Values.ElementAt(0),
                PrivateKey = walletEthAddress.Keys.ElementAt(0),
                BalanceAmount = 0,
                BalanceAmountTransaction = 0
            };

            wallets.Add(walletEth);
            // wallet for vnd
            var walletVndAddress = CreateAddress();
            Wallet walletVnd = new Wallet
            {
                WalletID = Guid.NewGuid(),
                CryptocurrencyStoreID = cryptocurrencyStoreDataAccess.GetCryptocurrencyStoreByMoneyType(CryptoCurrencyCommon.VietnamDong).CryptocurrencyStoreID,
                AccountID = AccountId,
                WalletAddress = walletVndAddress.Values.ElementAt(0),
                PrivateKey = walletVndAddress.Keys.ElementAt(0),
                BalanceAmount = 0,
                BalanceAmountTransaction = 0
            };

            wallets.Add(walletVnd);
            walletDataAccess.CreateWalletForAllCrypto(wallets);
        }

        public Wallet FindWalletByWalletAddress(string walletAddress)
        {
            return walletDataAccess.FindWalletByWalletAddress(walletAddress);
        }

        public Wallet FindWalletById(Guid accountID)
        {
            return walletDataAccess.FindWalletByAccountID(accountID);
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
            //BitcoinSecret mainNetPrivateKey = privateKey.GetBitcoinSecret(Network.Main); // bitcoin secret
            PubKey publicKey = privateKey.PubKey;

            var address = publicKey.GetAddress(ScriptPubKeyType.Legacy, Network.Main);

            dic.Add(privateKey.ToString(Network.Main), address.ToString());

            return dic;
        }

        public Wallet FindWalletByAccountIdAndMoneyType(Guid accountID, string moneyType)
        {
            return walletDataAccess.FindWalletByAccountAndMoneyType(accountID, moneyType);
        }

        public bool UpdateWallet()
        {
            throw new NotImplementedException();
        }

        public List<Wallet> ListWalletByAccountID(Guid accountID)
        {
            return walletDataAccess.GetListWalletByAccountID(accountID);
        }
    }
}

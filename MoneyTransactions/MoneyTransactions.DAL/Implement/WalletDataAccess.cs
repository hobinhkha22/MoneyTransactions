using MoneyTransactions.Common;
using MoneyTransactions.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyTransactions.DAL.Implement
{
    public class WalletDataAccess
    {
        MoneyTransactionsContext db;
        public WalletDataAccess()
        {
            db = MoneyTransactionsContextFactory.Instance.GetOrCreateContext();
        }

        public Wallet FindWalletByPrivateKey(string privateKey)
        {
            return db.Wallets.FirstOrDefault(x => x.PrivateKey == privateKey);
        }

        public Wallet FindWalletByWalletAddress(string walletAddress)
        {
            return db.Wallets.FirstOrDefault(w => w.WalletAddress == walletAddress);
        }

        public Wallet FindWalletByAccountAndMoneyType(Guid AccountID, string moneyType)
        {
            var get = new Wallet();

            // bitcoin
            if (moneyType.ToLower() == CryptoCurrencyCommon.Bitcoin.ToLower())
            {
                get = db.Wallets.FirstOrDefault(w => w.AccountID == AccountID && w.CryptocurrencyStore.MoneyType.ToLower() == moneyType.ToLower());
            }

            if (moneyType.ToLower() == CryptoCurrencyCommon.BitcointDescription.ToLower())
            {
                var change = CryptoCurrencyCommon.Bitcoin.ToLower();
                get = db.Wallets.FirstOrDefault(w => w.AccountID == AccountID && w.CryptocurrencyStore.MoneyType.ToLower() == change);
            }

            // ethereum
            if (moneyType.ToLower() == CryptoCurrencyCommon.Ethereum.ToLower())
            {
                get = db.Wallets.FirstOrDefault(w => w.AccountID == AccountID && w.CryptocurrencyStore.MoneyType.ToLower() == moneyType.ToLower());
            }

            if (moneyType.ToLower() == CryptoCurrencyCommon.EthereumDescription.ToLower())
            {
                var change = CryptoCurrencyCommon.Ethereum.ToLower();
                get = db.Wallets.FirstOrDefault(w => w.AccountID == AccountID && w.CryptocurrencyStore.MoneyType.ToLower() == change);
            }

            // ripple
            if (moneyType.ToLower() == CryptoCurrencyCommon.Ripple.ToLower())
            {
                get = db.Wallets.FirstOrDefault(w => w.AccountID == AccountID && w.CryptocurrencyStore.MoneyType.ToLower() == moneyType.ToLower());
            }

            if (moneyType.ToLower() == CryptoCurrencyCommon.RippleDescription.ToLower())
            {
                var change = CryptoCurrencyCommon.Ripple.ToLower();
                get = db.Wallets.FirstOrDefault(w => w.AccountID == AccountID && w.CryptocurrencyStore.MoneyType.ToLower() == change);
            }

            return get;
        }

        public Wallet FindWalletByAccountID(Guid accountID)
        {
            return db.Wallets.FirstOrDefault(x => x.AccountID == accountID);
        }

        public bool CreateWalletTransaction(Wallet seller, Wallet buyer)
        {
            using (DbContextTransaction transaction = db.Database.BeginTransaction())
            {
                try
                {
                    var walletSeller = db.Wallets.Find(seller.WalletID);
                    var walletBuyer = db.Wallets.Find(buyer.WalletID);

                    if (walletBuyer == null || walletSeller == null)
                    {
                        transaction.Commit();
                        return false;
                    }

                    walletSeller.BalanceAmount = seller.BalanceAmount;
                    walletSeller.BalanceAmountTransaction = seller.BalanceAmountTransaction;

                    walletBuyer.BalanceAmount = buyer.BalanceAmount;

                    db.SaveChanges();
                    transaction.Commit();
                    return true;
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    return false;
                }
            }
        }

        public bool CreateWalletForAllCrypto(List<Wallet> wallets)
        {
            try
            {
                db.Wallets.AddRange(wallets);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Wallet> GetListWalletByAccountID(Guid AccountID)
        {
            return db.Wallets.Where(w => w.AccountID == AccountID).ToList();
        }
    }
}

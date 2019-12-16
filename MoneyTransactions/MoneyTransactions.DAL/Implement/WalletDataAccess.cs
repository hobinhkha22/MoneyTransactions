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
            var g = db.Wallets.FirstOrDefault(x => x.AccountID == AccountID && x.CryptocurrencyStore.MoneyType.ToLower() == moneyType.ToLower());
            return db.Wallets.FirstOrDefault(x => x.AccountID == AccountID && x.CryptocurrencyStore.MoneyType.ToLower() == moneyType.ToLower());
        }

        public Wallet FindWalletByAccountID(Guid accountID)
        {
            return db.Wallets.FirstOrDefault(x => x.AccountID == accountID);
        }

        public Wallet FindWalletByWalletID(Guid WalletID)
        {
            return db.Wallets.FirstOrDefault(x => x.WalletID == WalletID);
        }

        public Wallet FindWalletByMoneyType(Guid accountID, string crypto)
        {
            return db.Wallets.FirstOrDefault(x => x.AccountID == accountID && x.CryptocurrencyStore.MoneyType.ToLower() == crypto.ToLower());
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

        public WalletOutside FindWalletOutSideByWalletOutSideID(Guid wOutsideID)
        {
            return db.WalletOutsides.FirstOrDefault(x => x.WalletOutsideID == wOutsideID);
        }

        public WalletOutside FindWalletOutSideByAccountID(Guid AccountID)
        {
            return db.WalletOutsides.FirstOrDefault(x => x.AccountID == AccountID);
        }

        public WalletOutside FindWalletOutSideByWalletOutSideIDAndAccountID(Guid wOutsideID, Guid AccountID)
        {
            return db.WalletOutsides.FirstOrDefault(x => x.WalletOutsideID == wOutsideID && x.AccountID == AccountID);
        }
    }
}

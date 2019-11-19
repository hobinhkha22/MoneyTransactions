﻿using MoneyTransactions.Entities;
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
                    db.SaveChanges();

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
    }
}
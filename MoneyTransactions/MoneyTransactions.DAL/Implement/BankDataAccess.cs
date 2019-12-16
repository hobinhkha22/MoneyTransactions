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
    public class BankDataAccess
    {
        MoneyTransactionsContext db;
        public BankDataAccess()
        {
            db = MoneyTransactionsContextFactory.Instance.GetOrCreateContext();
        }

        public bool AddBank(Bank bank)
        {
            try
            {
                db.Banks.Add(bank);
                db.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }


        public Bank FindBankByBankID(Guid BankID)
        {
            return db.Banks.FirstOrDefault(x => x.BankID == BankID);
        }

        public bool NapTien(Wallet wallet)
        {
            using (DbContextTransaction transaction = db.Database.BeginTransaction())
            {
                try
                {
                    var walletBank = db.Wallets.Find(wallet.WalletID);

                    if (walletBank == null)
                    {
                        transaction.Commit();
                        return false;
                    }

                    db.SaveChanges();
                    transaction.Commit();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public bool RutTien(WalletOutside walletOutside, Wallet walletInside, string moneyType)
        {

            using (DbContextTransaction transaction = db.Database.BeginTransaction())
            {
                try
                {
                    var wOutside = db.WalletOutsides.Find(walletOutside.WalletOutsideID);
                    var wInside = db.Wallets.Find(walletInside.WalletID);

                    if (wOutside == null || wInside == null)
                    {
                        transaction.Commit();
                        return false;
                    }

                    db.SaveChanges();
                    transaction.Commit();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public bool RutTienVND(Wallet wallet, Bank bank)
        {
            using (DbContextTransaction transaction = db.Database.BeginTransaction())
            {
                try
                {
                    var wInside = db.Wallets.Find(wallet.WalletID);
                    var bOutside = db.Banks.Find(bank.BankID);

                    if (wInside == null || bOutside == null)
                    {
                        transaction.Commit();
                        return false;
                    }

                    db.SaveChanges();
                    transaction.Commit();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }


        public AccountBankDetail FindAccountBankDetailByAccountID(Guid accountID)
        {
            return db.AccountBankDetails.FirstOrDefault(x => x.AccountID == accountID);
        }
    }
}

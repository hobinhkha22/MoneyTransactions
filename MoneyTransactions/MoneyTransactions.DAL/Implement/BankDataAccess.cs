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

        public Bank FindBankOutside(Guid bankID)
        {
            return db.Banks.FirstOrDefault(x => x.BankID == bankID);
        }

        public bool NapTien(AccountBankDetail accountBankDetail, Wallet wallet, decimal luongNapTien)
        {
            using (DbContextTransaction transaction = db.Database.BeginTransaction())
            {
                try
                {
                    var accbank = db.AccountBankDetails.Find(accountBankDetail);
                    var walletBank = db.Wallets.Find(wallet);
                    
                    if (accbank == null || walletBank == null)
                    {
                        transaction.Commit();
                        return false;
                    }

                    accbank.Bank.VietNamDong = luongNapTien;
                    walletBank.BalanceAmount = luongNapTien;

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

        public bool RutTien(AccountBankDetail accountBankDetail, Wallet wallet, decimal luongRutTien)
        {
            using (DbContextTransaction transaction = db.Database.BeginTransaction())
            {
                try
                {
                    var accbank = db.AccountBankDetails.Find(accountBankDetail);
                    var walletBank = db.Wallets.Find(wallet);

                    if (accbank == null || walletBank == null)
                    {
                        transaction.Commit();
                        return false;
                    }

                    accbank.Bank.VietNamDong = luongRutTien;
                    walletBank.BalanceAmount = luongRutTien;

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

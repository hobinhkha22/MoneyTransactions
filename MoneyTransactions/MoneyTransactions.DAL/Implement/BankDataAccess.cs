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

        public bool NapTien(Account account, Wallet wallet, decimal luongNapTien)
        {
            using (DbContextTransaction transaction = db.Database.BeginTransaction())
            {
                try
                {
                    var accbank = db.AccountBankDetails.Find(account.AccountID);
                    var walletBank = db.Wallets.Find(wallet.WalletID);

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

        public bool RutTien(Account account, Wallet wallet, decimal luongNapTien)
        {

            using (DbContextTransaction transaction = db.Database.BeginTransaction())
            {
                try
                {
                    var accbank = db.AccountBankDetails.Find(account.AccountID);
                    var walletBank = db.Wallets.Find(wallet.WalletID);

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

        public AccountBankDetail FindAccountBankDetailByAccountID(Guid accountID)
        {
            return db.AccountBankDetails.FirstOrDefault(x => x.AccountID == accountID);
        }
    }
}

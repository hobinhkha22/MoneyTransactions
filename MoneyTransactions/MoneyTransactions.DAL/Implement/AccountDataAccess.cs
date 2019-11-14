using MoneyTransactions.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyTransactions.DAL.Implement
{
    public class AccountDataAccess
    {
        MoneyTransactionsContext db;
        public AccountDataAccess()
        {
            db = MoneyTransactionsContextFactory.Instance.GetOrCreateContext();
        }

        public Account FindUserByUserName(string userName)
        {
            return db.Accounts.FirstOrDefault(x => x.UserName == userName);
        }

        public Account FindUserById(Guid id)
        {
            return db.Accounts.FirstOrDefault(x => x.AccountID == id);
        }

        public bool UpdatePassword(Guid accountID, string newPassword)
        {
            try
            {
                var account = db.Accounts.Find(accountID);
                if (account != null)
                {
                    account.Password = newPassword;
                    db.SaveChanges();
                    return true;

                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool CreateAccount(Account account)
        {
            try
            {
                db.Accounts.Add(account);
                db.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Account> GetAccounts()
        {
            return db.Accounts.ToList();
        }

        public bool UpdateAccount(Guid accountID, Account accountUpdate)
        {
            try
            {
                var account = db.Accounts.Find(accountID);
                if (account != null)
                {
                    account.Email = accountUpdate.Email;
                    account.NickName = accountUpdate.NickName;
                    account.Phone = accountUpdate.Phone;

                    db.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}

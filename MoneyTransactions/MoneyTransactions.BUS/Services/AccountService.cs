using MoneyTransactions.BUS.Interface;
using MoneyTransactions.BUS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoneyTransactions.DAL;
using MoneyTransactions.Common;

namespace MoneyTransactions.BUS.Services
{
    public class AccountService : IAccountService
    {
        private readonly MoneyTransactionsDataContext db;

        public AccountService()
        {
            db = new MoneyTransactionsDataContext();
        }

        public void ChangePassword(string existedUsername, string oldPassword, string newPassword)
        {
            try
            {
                var existedPassword = db.Accounts.FirstOrDefault(x => x.Username == existedUsername && x.Password == oldPassword);
                if (existedPassword == null)
                {
                    throw new Exception(ExceptionMessageConstant.USERNOTEXIST);
                }
                else
                {
                    existedPassword.Password = newPassword;

                    db.SubmitChanges();
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public void CreateAccount(string username, string password, string confirmPassword)
        {
            try
            {
                Account account = new Account
                {
                    AccountID = Guid.NewGuid(),
                    Username = username,
                    Password = password,
                    Phone = string.Empty,
                    Email = string.Empty,
                    Nickname = username
                };

                db.Accounts.InsertOnSubmit(account);
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void CreateAccount(string username, string password, string phone = null, string email = null, string nickname = null)
        {
            try
            {
                Account account = new Account();
                account.AccountID = Guid.NewGuid();
                account.Username = username;
                account.Password = password;
                account.Phone = phone;
                account.Email = email;
                account.Nickname = nickname;

                db.Accounts.InsertOnSubmit(account);
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Account> GetAccounts()
        {
            try
            {
                var listAccount = db.Accounts.Select(x => new Account()
                {
                    Email = x.Email,
                    Nickname = x.Nickname,
                    Password = x.Password,
                    Username = x.Username,
                    Phone = x.Phone
                }).ToList();

                return listAccount;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void UpdateAccount(string usernameExisted, string newPhone, string newEmail, string newNickname)
        {
            try
            {
                var existedAccount = db.Accounts.FirstOrDefault(x => x.Username == usernameExisted);

                if (existedAccount == null)
                {
                    throw new Exception(ExceptionMessageConstant.USERNOTEXIST);
                }
                else
                {
                    existedAccount.Username = newPhone;
                    existedAccount.Email = newEmail;
                    existedAccount.Nickname = newNickname;

                    db.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Account FindUser(string username, string password)
        {
            var findUser = db.Accounts.FirstOrDefault(u => u.Username.ToLower() == username.ToLower() && u.Password.ToLower() == password.ToLower());

            if (findUser == null)
            {
                return null;
            }
            
            return findUser;
        }
    }
}

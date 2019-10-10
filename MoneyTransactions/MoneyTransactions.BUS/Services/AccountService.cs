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

        public void CreateAccount(string username, string password, string phone, string email, string nickname)
        {
            try
            {
                Account account = new Account();
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

        public List<UserModel> GetAccounts()
        {
            try
            {
                var listUserModel = db.Accounts.Select(x => new UserModel() { }).ToList();

                return listUserModel;
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
    }
}

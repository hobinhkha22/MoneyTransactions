using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoneyTransactions.DAL;
using MoneyTransactions.Common;
using MoneyTransactions.Entities;
using MoneyTransactions.DAL.Implement;

namespace MoneyTransactions.BUS.Services
{
    public class AccountService
    {
        private readonly AccountDataAccess accountDataAccess;

        public AccountService()
        {
            accountDataAccess = new AccountDataAccess();
        }

        public void ChangePassword(string existedUsername, string oldPassword, string newPassword)
        {
            try
            {
                var existedPassword = accountDataAccess.FindUserByUserName(existedUsername);

                if (existedPassword == null)
                {
                    throw new Exception(ExceptionMessageConstant.USERNOTEXIST);
                }
                else
                {
                    if (existedPassword.Password != oldPassword)
                    {
                        throw new Exception(ExceptionMessageConstant.PASSWORDNOTEXIST);
                    }
                    accountDataAccess.UpdatePassword(existedPassword.AccountID, newPassword);
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
                    UserName = username,
                    Password = password,
                    Phone = string.Empty,
                    Email = string.Empty,
                    NickName = username
                };
                accountDataAccess.CreateAccount(account);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void CreateAccount(string username, string password, string phone = "", string email = "", string nickname = "")
        {
            try
            {
                Account account = new Account
                {
                    AccountID = Guid.NewGuid(),
                    UserName = username,
                    Password = password,
                    Phone = phone,
                    Email = email,
                    NickName = nickname
                };
                accountDataAccess.CreateAccount(account);
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
                return accountDataAccess.GetAccounts();
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
                var existedAccount = accountDataAccess.FindUserByUserName(usernameExisted);

                if (existedAccount == null)
                {
                    throw new Exception(ExceptionMessageConstant.USERNOTEXIST);
                }
                else
                {
                    existedAccount.Phone = newPhone;
                    existedAccount.Email = newEmail;
                    existedAccount.NickName = newNickname;
                    accountDataAccess.UpdateAccount(existedAccount.AccountID, existedAccount);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Account FindUser(string username, string passWord)
        {
            return accountDataAccess.FindUser(username, passWord);
        }

        public Account FindUerWithRole(string username, string password, string role)
        {
            return accountDataAccess.FindUerWithRole(username, password, role);
        }


        public Account FindUserByUserName(string username)
        {
            return accountDataAccess.FindUserByUserName(username);
        }

        public Account FindUserById(Guid id)
        {
            return accountDataAccess.FindUserById(id);
        }
    }
}

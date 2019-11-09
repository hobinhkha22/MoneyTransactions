using MoneyTransactions.BUS.Models;
using MoneyTransactions.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyTransactions.BUS.Interface
{
    public interface IAccountService
    {
        void CreateAccount(string username, string password, string confirmPassword);

        void CreateAccount(string username, string password, string phone = null, string email = null, string nickname = null);

        void UpdateAccount(string usernameExisted, string newPhone, string newEmail, string newNickname);

        void ChangePassword(string username, string oldPassword, string newPassword);

        Account FindUser(string username, string password);

        List<Account> GetAccounts();
    }
}

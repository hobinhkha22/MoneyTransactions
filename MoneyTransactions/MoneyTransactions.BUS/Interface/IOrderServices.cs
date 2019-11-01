using MoneyTransactions.BUS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyTransactions.BUS.Interface
{
    public interface IOrderServices
    {
        void CreateTransaction(UserModel userModel, decimal amount, decimal amountBought);
        List<DAL.Order> ShowRecentTransaction();
    }
}

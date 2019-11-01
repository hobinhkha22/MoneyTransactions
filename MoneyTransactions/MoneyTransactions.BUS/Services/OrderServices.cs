using MoneyTransactions.BUS.Interface;
using MoneyTransactions.BUS.Models;
using MoneyTransactions.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyTransactions.BUS.Services
{
    public class OrderServices : IOrderServices
    {
        private readonly MoneyTransactionsDataContext db;

        public OrderServices()
        {
            db = new MoneyTransactionsDataContext();
        }

        public void CreateTransaction(UserModel userModel, decimal amount, decimal amountBought)
        {
            throw new NotImplementedException();
        }

        public List<DAL.Order> ShowRecentTransaction()
        {
            return db.Orders.ToList();
        }
    }
}

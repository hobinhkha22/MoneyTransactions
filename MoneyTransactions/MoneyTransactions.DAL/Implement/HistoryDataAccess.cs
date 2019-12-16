using MoneyTransactions.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyTransactions.DAL.Implement
{
    public class HistoryDataAccess
    {
        MoneyTransactionsContext db;

        public HistoryDataAccess()
        {
            db = MoneyTransactionsContextFactory.Instance.GetOrCreateContext();
        }

        public bool AddOrderHisto(OrderHistory orderHistory)
        {
            try
            {
                db.OrderHistories.Add(orderHistory);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


    }
}

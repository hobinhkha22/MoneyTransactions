using MoneyTransactions.DAL.Implement;
using MoneyTransactions.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyTransactions.BUS.Services
{
    public class HistoryServices
    {
        private HistoryDataAccess historyDataAccess;

        public HistoryServices()
        {
            historyDataAccess = new HistoryDataAccess();
        }

        public bool AddOrderHisto(OrderHistory orderHistory)
        {
            return historyDataAccess.AddOrderHisto(orderHistory);
        }

        public bool AddHistoryByMultipleParam()
        {
            return false;
        }
    }
}

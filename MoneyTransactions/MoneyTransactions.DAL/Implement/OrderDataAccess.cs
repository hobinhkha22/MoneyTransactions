using MoneyTransactions.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyTransactions.DAL.Implement
{
    public class OrderDataAccess
    {
        MoneyTransactionsContext db;
        public OrderDataAccess()
        {
            db = MoneyTransactionsContextFactory.Instance.GetOrCreateContext();
        }

        public bool CreateOrder(Order order)
        {
            try
            {
                db.Orders.Add(order);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException.Message);
                return false;
            }
        }

        public List<Order> GetOrders()
        {
            return db.Orders.ToList();
        }

        public Order FindOrderByWalletID(Guid walletID)
        {
            return db.Orders.FirstOrDefault(x => x.WalletID == walletID);
        }

        public void RemoveOrder(Order order)
        {
            try
            {
                db.Orders.Remove(order);
                db.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Order> GetOrdersByAmount(decimal amountSearch)
        {
            var ds = db.Orders.Where(w => w.Amount <= amountSearch).ToList();
            return db.Orders.Where(w => w.Amount <= amountSearch).ToList();
        }

        public List<Order> GetListOrder()
        {
            return db.Orders.ToList();
        }
    }
}

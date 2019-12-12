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

        public Order FindOrderByWalletIDAndAmount(Guid walletID, decimal amount)
        {
            return db.Orders.FirstOrDefault(x => x.WalletID == walletID && x.Amount == amount);
        }

        public Order FindOrderByAccountIDAndAmount(Guid accountID, decimal amount)
        {
            return db.Orders.FirstOrDefault(x => x.Wallet.AccountID == accountID && x.Amount == amount);
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
            //List<Order> ds = null;
            //ds = db.Orders.Include("Wallet").Include("Wallet.Account").Include("OrderDetails").Where(w => w.Amount <= amountSearch).ToList();

            return db.Orders.Where(w => w.Amount <= amountSearch).ToList();
        }

        public List<Order> GetListOrder()
        {
            return db.Orders.ToList();
        }
    }
}

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
        void CreateSellTransaction(Guid accountID, string privateKeySeller, decimal amountWantToSell);
        
        void CreateBuyTransaction(Guid Seller, Guid Buyer, decimal amountWantToBuy);
        
        List<DAL.Order> ShowRecentTransaction();
    }
}

using MoneyTransactions.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyTransactions.DAL.Implement
{
    public class CryptocurrencyStoreDataAccess
    {
        MoneyTransactionsContext db;
        public CryptocurrencyStoreDataAccess()
        {
            db = MoneyTransactionsContextFactory.Instance.GetOrCreateContext();
        }

        public List<CryptocurrencyStore> GetCryptocurrencyStores()
        {
            return db.CryptocurrencyStores.ToList();
        }

        public CryptocurrencyStore GetCryptocurrencyStoreByMoneyType(string moneyType)
        {
            return db.CryptocurrencyStores.FirstOrDefault(x => x.MoneyType.ToLower() == moneyType.ToLower());
        }
    }
}

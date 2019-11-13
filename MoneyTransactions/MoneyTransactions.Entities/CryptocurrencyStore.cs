using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyTransactions.Entities
{
    public class CryptocurrencyStore
    {
        public Guid CryptocurrencyStoreID { get; set; }
        public string MoneyType { get; set; }
        public decimal FloorPrice { get; set; }
        public string Description { get; set; }
    }
}

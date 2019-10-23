using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyTransactions.BUS.Models
{
    public class CryptocurrencyStore
    {
        public Guid CryptocurrencyStoreId { get; set; }
        public string MoneyType { get; set; }
        public string Description { get; set; }

        public List<WalletModel> WalletModels { get; set; }
    }
}

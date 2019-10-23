using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyTransactions.BUS.Models
{
    public class WalletModel
    {
        public Guid WalletID { get; set; }
        public string WalletAddress { get; set; }
        public double BalanceAmount { get; set; }
        public double BalanceAmountTransaction { get; set; }

        public Guid Id { get; set; }
        public UserModel UserModel { get; set; }

        // CryptocurrencyStore table
        public Guid CryptocurrencyStoreId { get; set; }
        public CryptocurrencyStore CryptocurrencyStore { get; set; }

        // 
    }
}

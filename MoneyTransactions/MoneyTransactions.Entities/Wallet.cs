using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyTransactions.Entities
{
    public class Wallet
    {
        public Guid WalletID { get; set; }
        public string WalletAddress { get; set; }
        public decimal BalanceAmount { get; set; }
        public decimal BalanceAmountTransaction { get; set; }
        public Guid CryptocurrencyStoreID { get; set; }
        public Guid AccountID { get; set; }
    }
}

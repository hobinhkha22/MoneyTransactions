using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyTransactions.Entities
{
    public class Wallet
    {
        [Key]
        public Guid WalletID { get; set; }
        [StringLength(200)]
        public string WalletAddress { get; set; }
        [Required]
        public decimal BalanceAmount { get; set; }
        [Required]
        public decimal BalanceAmountTransaction { get; set; }
        [Required]
        public Guid CryptocurrencyStoreID { get; set; }
        [StringLength(200)]
        public string PrivateKey { get; set; }
        [Required]
        public Guid AccountID { get; set; }

        public virtual CryptocurrencyStore CryptocurrencyStore { get; set; }

        public virtual Account Account { get; set; }

        public virtual List<Order> Orders { get; set; }
        public virtual List<OrderDetail> OrderDetails { get; set; }

    }
}

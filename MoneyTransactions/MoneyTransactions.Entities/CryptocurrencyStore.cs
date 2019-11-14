using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyTransactions.Entities
{
    public class CryptocurrencyStore
    {
        [Key]
        public Guid CryptocurrencyStoreID { get; set; }
        [Required]
        [StringLength(200)]
        public string MoneyType { get; set; }
        [Required]
        public decimal FloorPrice { get; set; }
        [StringLength(200)]
        public string Description { get; set; }

        public virtual List<Wallet> Wallets { get; set; }
    }
}

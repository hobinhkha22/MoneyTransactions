using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyTransactions.Entities
{
   public class Order
    {
        [Key]
        public Guid OrderID { get; set; }
        [Required]
        public decimal Amount { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        [Required]
        public Guid WalletID { get; set; }

        public string OrderType { get; set; }

        public virtual Wallet Wallet { get; set; }

        public virtual List<OrderDetail> OrderDetails { get; set; }
    }
}

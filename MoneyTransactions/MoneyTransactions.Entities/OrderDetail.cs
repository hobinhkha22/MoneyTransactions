using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyTransactions.Entities
{
    public class OrderDetail
    {
        [Key]
        public Guid OrderDetailID { get; set; }
        [Required]
        public Guid OrderID { get; set; }
        [Required]
        public Guid WalletID { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
        [Required]
        public decimal Amount { get; set; }

        public virtual Order Order { get; set; }

        public virtual Wallet Wallet { get; set; }
    }
}

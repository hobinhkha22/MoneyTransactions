using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyTransactions.Entities
{
    public class History
    {
        [Key]
        public Guid HistoryID { get; set; }

        public string OrderType { get; set; }

        public decimal Amount { get; set; }

        public decimal Price { get; set; }

        public bool IsDoneYet { get; set; }

        public DateTime Time { get; set; }
        [Required]
        public Guid AccountID { get; set; }

        public Account Account { get; set; }

        public Guid Seller { get; set; }
        
        public Guid Buyer { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyTransactions.Entities
{
    public class OrderDetail
    {
        public Guid OrderDetailID { get; set; }
        public Guid OrderID { get; set; }
        public Guid WalletID { get; set; }
        public DateTime CreatedDate { get; set; }
        public decimal Amount { get; set; }
    }
}

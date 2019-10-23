using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyTransactions.BUS.Models
{
    public class OrderDetail : BaseOrder
    {
        public Guid OrderDetailId { get; set; }
        public string MoneyType { get; set; }
        public DateTimeOffset CreateDate { get; set; }
        public double Amount { get; set; }

        // Order table
        public Order Order { get; set; }
    }
}

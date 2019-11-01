using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyTransactions.BUS.Models
{
    public class Order : BaseOrder
    {
        public string Amount { get; set; }
        public string AmountBought { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset ModifiedDate { get; set; }

        // UserModel - Account model
        public Guid Id { get; set; }
        public UserModel UserModel { get; set; }

        // OrderDetail table
        public List<OrderDetail> OrderDetails { get; set; }

    }
}

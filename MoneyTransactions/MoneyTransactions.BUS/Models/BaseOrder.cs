using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyTransactions.BUS.Models
{
   public class BaseOrder
    {
        public Guid OrderId { get; set; }
        public Guid BuyerId { get; set; }
        public Guid SalerId { get; set; }
    }
}

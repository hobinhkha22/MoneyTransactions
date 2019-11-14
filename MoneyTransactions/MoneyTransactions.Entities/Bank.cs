using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyTransactions.Entities
{
    public class Bank
    {
        [Key]
        public Guid BankID { get; set; }
        [StringLength(20)]
        public string BankName { get; set; }

        public virtual List<AccountBankDetail> AccountBankDetails { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyTransactions.Entities
{
    public class AccountBankDetail
    {
        [StringLength(200)]
        public string AccountNumber { get; set; }
        [StringLength(40)]
        public string CardNumber { get; set; }
        public DateTime ExpiredDate { get; set; }
        [Required]
        public Guid BankID { get; set; }
        [Required]
        public Guid AccountID { get; set; }
        [Key]
        public Guid AccountBankDetailID { get; set; }

        public virtual Bank Bank { get; set; }

        public virtual Account Account { get; set; }
    }
}

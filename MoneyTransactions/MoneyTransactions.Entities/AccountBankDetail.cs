using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyTransactions.Entities
{
    public class AccountBankDetail
    {
        public string AccountNumber { get; set; }
        public string CardNumber { get; set; }
        public DateTime ExpiredDate { get; set; }
        public Guid BankID { get; set; }
        public Guid AccountID { get; set; }
        public Guid AccountBankDetailID { get; set; }

    }
}

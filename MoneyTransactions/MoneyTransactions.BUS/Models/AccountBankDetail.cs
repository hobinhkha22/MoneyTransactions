using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyTransactions.BUS.Models
{
    public class AccountBankDetail
    {
        public Guid AccountBankDetailId { get; set; }
        public string CardNumber { get; set; }
        public DateTimeOffset ExpiredDate { get; set; }

        // Bank table
        public Guid BankId { get; set; }
        public Bank Banks { get; set; }

        // Account table
        public Guid Id { get; set; }
        public UserModel UserModel { get; set; }
    }
}

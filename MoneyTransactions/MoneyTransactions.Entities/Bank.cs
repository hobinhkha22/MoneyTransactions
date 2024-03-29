﻿using System;
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

        public string Email { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public decimal VietNamDong { get; set; }

        public virtual List<AccountBankDetail> AccountBankDetails { get; set; }
    }
}

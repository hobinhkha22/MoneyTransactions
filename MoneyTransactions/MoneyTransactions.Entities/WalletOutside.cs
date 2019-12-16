using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyTransactions.Entities
{
    public class WalletOutside
    {
        [Key]
        public int WalletOutsideID { get; set; }

        public string Email { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public decimal VietNamDong { get; set; }
    }
}

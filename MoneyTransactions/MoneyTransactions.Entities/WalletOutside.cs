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
        public Guid WalletOutsideID { get; set; }

        public string Email { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public decimal BTC { get; set; }

        public decimal ETH { get; set; }

        public decimal XRP { get; set; }

        public decimal VND { get; set; }

        public string BTCAddress { get; set; }
        
        public string ETHAddress { get; set; }
        
        public string XRPAddress { get; set; }
        
        public string VNDAddress { get; set; }

        public Guid AccountID { get; set; }

        public Account Account { get; set; }
    }
}

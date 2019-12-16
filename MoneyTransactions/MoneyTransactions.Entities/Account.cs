using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyTransactions.Entities
{
    public class Account
    {
        [Key]
        public Guid AccountID { get; set; }
        [Required]
        [StringLength(30)]
        [Index(IsUnique = true)]
        public string UserName { get; set; }
        [Required]
        [StringLength(30)]
        public string Password { get; set; }
        [StringLength(30)]
        public string Email { get; set; }
        [Required]
        [StringLength(30)]
        public string NickName { get; set; }
        [StringLength(30)]
        public string Phone { get; set; }
        [Required]
        public Guid RoleID { get; set; }

        public virtual Role Role { get; set; }

        public virtual List<AccountBankDetail> AccountBankDetails { get; set; }

        public virtual List<Wallet> Wallets { get; set; }
        public virtual List<WalletOutside> WalletOutsides { get; set; }

        public virtual List<History> Histories { get; set; }

    }
}

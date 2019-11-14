using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyTransactions.Entities
{
    public class Role
    {
        [Key]
        public Guid RoleID { get; set; }
        [Required]
        [StringLength(200)]
        public String RoleName { get; set; }
        [StringLength(200)]
        public string Description { get; set; }

        public virtual List<Account> Accounts { get; set; }
    }
}

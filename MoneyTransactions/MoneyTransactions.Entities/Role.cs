using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyTransactions.Entities
{
    public enum RoleName
    {
        //Admin='admin',
    }
    public class Role
    {
        public Guid RoleID { get; set; }
        public String RoleName { get; set; }
        public string Description { get; set; }
    }
}

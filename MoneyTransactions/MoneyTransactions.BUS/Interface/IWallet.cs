using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyTransactions.BUS.Interface
{
    public interface IWallet
    {
        void CreateWallet(Guid Id);

        bool UpdateWallet();

        
    }
}

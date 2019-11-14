using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyTransactions.DAL
{
   public class MoneyTransactionsContextFactory
    {
        private static volatile MoneyTransactionsContextFactory _dbContextFactory;
        private static readonly object SyncRoot = new Object();
        public MoneyTransactionsContext Context;

        public static MoneyTransactionsContextFactory Instance
        {
            get
            {
                if (_dbContextFactory == null)
                {
                    lock (SyncRoot)
                    {
                        if (_dbContextFactory == null)
                            _dbContextFactory = new MoneyTransactionsContextFactory();
                    }
                }
                return _dbContextFactory;
            }
        }

        public MoneyTransactionsContext GetOrCreateContext()
        {
            if (this.Context == null)
            {
                this.Context = new MoneyTransactionsContext(ConfigurationManager.ConnectionStrings["MoneyTransactionConnectionString"].ConnectionString);
            }
            return Context;
        }
    }

}

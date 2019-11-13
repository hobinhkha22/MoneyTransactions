using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyTransactions.DAL
{
    public class MoneyTransactionsDBInitializer : DropCreateDatabaseIfModelChanges<MoneyTransactionsContext>
    {
        protected override void Seed(MoneyTransactionsContext context)
        {
            base.Seed(context);

        }

    }
}

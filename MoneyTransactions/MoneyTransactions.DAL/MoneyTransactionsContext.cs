using MoneyTransactions.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyTransactions.DAL
{
    public class MoneyTransactionsContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<AccountBankDetail> AccountBankDetails { get; set; }
        public DbSet<Bank> Banks { get; set; }
        public DbSet<CryptocurrencyStore> CryptocurrencyStores { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Wallet> Wallets { get; set; }

        public MoneyTransactionsContext(string connectionString):base(connectionString)
        {
            Database.Connection.ConnectionString = connectionString;
            Database.SetInitializer(new MoneyTransactionsDBInitializer());
            Database.Initialize(false);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}

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

        public MoneyTransactionsContext(string connectionString) : base(connectionString)
        {
            Database.Connection.ConnectionString = connectionString;
            Database.SetInitializer(new MoneyTransactionsDBInitializer());
            Database.Initialize(false);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);            

            // Create Relationship between class
            // Account - Role
            modelBuilder.Entity<Account>()
                .HasRequired<Role>(r => r.Role)
                .WithMany(e => e.Accounts)
                .HasForeignKey<Guid>(r => r.RoleID);

            // Bank - Account Bank Detail
            modelBuilder.Entity<AccountBankDetail>()
                .HasRequired<Bank>(r => r.Bank)
                .WithMany(e => e.AccountBankDetails)
                .HasForeignKey<Guid>(r => r.BankID);

            // Account -  Account Bank Detail
            modelBuilder.Entity<AccountBankDetail>()
                .HasRequired<Account>(r => r.Account)
                .WithMany(e => e.AccountBankDetails)
                .HasForeignKey<Guid>(r => r.AccountID);

            // Account - Wallet
            modelBuilder.Entity<Wallet>()
                .HasRequired<Account>(r => r.Account)
                .WithMany(e => e.Wallets)
                .HasForeignKey<Guid>(r => r.AccountID);

            // Wallet - Order
            modelBuilder.Entity<Order>()
                .HasRequired<Wallet>(r => r.Wallet)
                .WithMany(e => e.Orders)
                .HasForeignKey<Guid>(r => r.WalletID)
                    .WillCascadeOnDelete(false);

            // Order - Order Detail
            modelBuilder.Entity<OrderDetail>()
                .HasRequired<Order>(r => r.Order)
                .WithMany(e => e.OrderDetails)
                .HasForeignKey<Guid>(r => r.OrderID);

            // Order Detail - Wallet
            modelBuilder.Entity<OrderDetail>()
                .HasRequired<Wallet>(r => r.Wallet)
                .WithMany(e => e.OrderDetails)
                .HasForeignKey<Guid>(r => r.WalletID)
                    .WillCascadeOnDelete(false);

            modelBuilder.Entity<Order>().Property(x => x.Amount).HasPrecision(18, 5);
            modelBuilder.Entity<Order>().Property(x => x.Price).HasPrecision(18, 5);
            modelBuilder.Entity<OrderDetail>().Property(x => x.Amount).HasPrecision(18, 5);

            // Cryptocurrency Store -  Wallet
            modelBuilder.Entity<Wallet>()
                .HasRequired<CryptocurrencyStore>(r => r.CryptocurrencyStore)
                .WithMany(e => e.Wallets)
                .HasForeignKey<Guid>(r => r.CryptocurrencyStoreID);            

        }
    }
}

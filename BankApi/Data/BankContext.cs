using BankAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankAPI.Data
{
    public class BankContext : DbContext
    {
        public BankContext(DbContextOptions<BankContext> potions) : base(potions)
        {

        }

        public DbSet<Account> Account { get; set; }
        public DbSet<BillPay> BillPay { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Login> Login { get; set; }
        public DbSet<Payee> Payee { get; set; }
        public DbSet<Transaction> Transaction { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Login>().HasCheckConstraint("CH_Login_LoginID", "len(LoginID) = 8").
                HasCheckConstraint("CH_Login_PasswordHash", "len(PasswordHash) = 64");

            builder.Entity<Account>().HasCheckConstraint("CH_Account_Balance", "Balance >= 0");

            builder.Entity<Transaction>().
                HasOne(x => x.Account).WithMany(x => x.Transactions).HasForeignKey(x => x.AccountNumber);

            builder.Entity<Transaction>().HasCheckConstraint("CH_Transaction_Amount", "Amount > 0");

            builder.Entity<Customer>()
                .HasMany(x => x.Accounts).WithOne(x => x.Customer).HasForeignKey(x => x.CustomerID);

            builder.Entity<Login>()
                .HasOne(x => x.Customer);

            builder.Entity<BillPay>()
                .HasOne(x => x.Account).WithMany(x => x.BillPay).HasForeignKey(x => x.AccountNumber);

            builder.Entity<BillPay>()
                .HasOne(x => x.Payee).WithMany(x => x.BillPays).HasForeignKey(x => x.PayeeID);

        }
    }
}

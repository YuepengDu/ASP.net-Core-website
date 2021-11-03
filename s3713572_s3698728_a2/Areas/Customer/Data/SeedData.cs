using System;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using s3713572_s3698728_a2.Models;
using static s3713572_s3698728_a2.Models.Transaction;
using System.Globalization;

namespace s3713572_s3698728_a2.Data
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<BankContext>();

            // Look for customers.
            if (context.Customer.Any())
                return; // DB has already been seeded.

            context.Customer.AddRange(
                new Customer
                {
                    CustomerID = 2100,
                    CustomerName = "Matthew Bolger",
                    Address = "123 Fake Street",
                    City = "Melbourne",
                    PostCode = "3000",
                    Phone = "+61 1234 5678"
                },
                new Customer
                {
                    CustomerID = 2200,
                    CustomerName = "Rodney Cocker",
                    Address = "456 Real Road",
                    City = "Melbourne",
                    PostCode = "3005",
                    Phone = "+61 1111 2222"
                },
                new Customer
                {
                    CustomerID = 2300,
                    CustomerName = "Shekhar Kalra",
                    Phone = "+61 2222 3333"
                });

            context.Login.AddRange(
                new Login
                {
                    LoginID = "12345678",
                    CustomerID = 2100,
                    PasswordHash = "YBNbEL4Lk8yMEWxiKkGBeoILHTU7WZ9n8jJSy8TNx0DAzNEFVsIVNRktiQV+I8d2"
                },
                new Login
                {
                    LoginID = "38074569",
                    CustomerID = 2200,
                    PasswordHash = "EehwB3qMkWImf/fQPlhcka6pBMZBLlPWyiDW6NLkAh4ZFu2KNDQKONxElNsg7V04"
                },
                new Login
                {
                    LoginID = "17963428",
                    CustomerID = 2300,
                    PasswordHash = "LuiVJWbY4A3y1SilhMU5P00K54cGEvClx5Y+xWHq7VpyIUe5fe7m+WeI0iwid7GE"
                });

            context.Account.AddRange(
                new Account
                {
                    AccountNumber = 4100,
                    AccountType = AccountType.Saving,
                    CustomerID = 2100,
                    Balance = 500
                },
                new Account
                {
                    AccountNumber = 4101,
                    AccountType = AccountType.Checking,
                    CustomerID = 2100,
                    Balance = 500
                },
                new Account
                {
                    AccountNumber = 4200,
                    AccountType = AccountType.Saving,
                    CustomerID = 2200,
                    Balance = 500.95m
                },
                new Account
                {
                    AccountNumber = 4300,
                    AccountType = AccountType.Checking,
                    CustomerID = 2300,
                    Balance = 1250.50m
                });

            const string initialDeposit = "Initial deposit";
            const string format = "dd/MM/yyyy hh:mm:ss tt";

            context.Transaction.AddRange(
                new Transaction
                {
                    transactionType = TransactionType.Deposit,
                    AccountNumber = 4100,
                    Amount = 100,
                    Comment = initialDeposit,
                    ModifyDate = DateTime.ParseExact("08/06/2020 08:00:00 PM", format, CultureInfo.InvariantCulture)
                },
                new Transaction
                {
                    transactionType = TransactionType.Deposit,
                    AccountNumber = 4100,
                    Amount = 100,
                    Comment = initialDeposit,
                    ModifyDate = DateTime.ParseExact("09/06/2020 09:00:00 AM", format, CultureInfo.InvariantCulture)
                },
                new Transaction
                {
                    transactionType = TransactionType.Deposit,
                    AccountNumber = 4100,
                    Amount = 100,
                    Comment = initialDeposit,
                    ModifyDate = DateTime.ParseExact("09/06/2020 01:00:00 PM", format, CultureInfo.InvariantCulture)
                },
                new Transaction
                {
                    transactionType = TransactionType.Deposit,
                    AccountNumber = 4100,
                    Amount = 100,
                    Comment = initialDeposit,
                    ModifyDate = DateTime.ParseExact("09/06/2020 03:00:00 PM", format, CultureInfo.InvariantCulture)
                },
                new Transaction
                {
                    transactionType = TransactionType.Deposit,
                    AccountNumber = 4100,
                    Amount = 100,
                    Comment = initialDeposit,
                    ModifyDate = DateTime.ParseExact("10/06/2020 11:00:00 AM", format, CultureInfo.InvariantCulture)
                },
                new Transaction
                {
                    transactionType = TransactionType.Deposit,
                    AccountNumber = 4101,
                    Amount = 500,
                    Comment = initialDeposit,
                    ModifyDate = DateTime.ParseExact("08/06/2020 08:30:00 PM", format, CultureInfo.InvariantCulture)
                },
                new Transaction
                {
                    transactionType = TransactionType.Deposit,
                    AccountNumber = 4200,
                    Amount = 500,
                    Comment = initialDeposit,
                    ModifyDate = DateTime.ParseExact("08/06/2020 09:00:00 PM", format, CultureInfo.InvariantCulture)
                },
                new Transaction
                {
                    transactionType = TransactionType.Deposit,
                    AccountNumber = 4200,
                    Amount = 0.95m,
                    Comment = initialDeposit,
                    ModifyDate = DateTime.ParseExact("08/06/2020 09:00:00 PM", format, CultureInfo.InvariantCulture)
                },
                new Transaction
                {
                    transactionType = TransactionType.Deposit,
                    AccountNumber = 4300,
                    Amount = 1250.50m,
                    Comment = initialDeposit,
                    ModifyDate = DateTime.ParseExact("08/06/2020 10:00:00 PM", format, CultureInfo.InvariantCulture)
                });

            context.Payee.AddRange(
                new Payee
                {
                    PayeeName = "Rmit",
                    Address = "123 la trobe street",
                    City = "Melbourne",
                    State = "VIC",
                    PostCode = "3000",
                    Phone = "+61 1234 4567"
                },
                new Payee
                {
                    PayeeName = "Telstra",
                    Address = "123 Collins street",
                    City = "Melbourne",
                    State = "VIC",
                    PostCode = "3000",
                    Phone = "+61 1111 2222"
                },
                new Payee
                {
                    PayeeName = "Winnconnect",
                    Address = "123 Lonesdale street",
                    City = "Melbourne",
                    State = "VIC",
                    PostCode = "3000",
                    Phone = "+61 7777 9999"
                });
            context.SaveChanges();
        }
    }
}

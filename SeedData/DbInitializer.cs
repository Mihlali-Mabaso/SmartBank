using Microsoft.EntityFrameworkCore;
using SmartBank.Data;
using SmartBank.Models.Entities;

namespace SmartBank.SeedData
{
    public class DbInitializer
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            //step 1: Get the database context from the application services
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<BankDbContext>();

                //step 2: Apply any pending migrations to the database( create database if it doesnt exist)
                if (context.Database.GetPendingMigrations().Any())
                {
                    context.Database.Migrate();
                }

                //Chech if the database already has data(if it does, skip seeding)
                if (context.AccountTypes.Any())
                {
                    return; //DB has been seeded
                }

                // ==step 4: seed account types==
                var accountTypes = new AccountType[]
                {
                    new AccountType
                    {
                        TypeName = "Savings Account",
                        Description = "High interest savings account with no monthly fees",
                        MonthlyFee = 0,
                        WithdrawalFee = 0,
                        TransferFee = 5.00m,
                        MinimumBalance = 0,
                        InterestRate = 0.035m,  // 3.5%
                        OverdraftLimit = 0
                    },
                    new AccountType
                    {
                        TypeName = "Cheque Account",
                        Description = "Everyday transaction account",
                        MonthlyFee = 25.00m,
                        WithdrawalFee = 2.00m,
                        TransferFee = 0,
                        MinimumBalance = 500m,
                        InterestRate = 0,
                        OverdraftLimit = 1000m
                    },
                    new AccountType
                    {
                        TypeName = "Premium Account",
                        Description = "Premium account with exclusive benefits",
                        MonthlyFee = 100.00m,
                        WithdrawalFee = 0,
                        TransferFee = 0,
                        MinimumBalance = 5000m,
                        InterestRate = 0.05m,  // 5%
                        OverdraftLimit = 5000m
                    }
                };
                context.AccountTypes.AddRange(accountTypes);
                context.SaveChanges();

                // ========== STEP 5: SEED CATEGORIES ==========
                var categories = new Category[]
                {
                    new Category { CategoryName = "Groceries", Icon = "🛒", Color = "#4CAF50", IsSystemCategory = true },
                    new Category { CategoryName = "Transport", Icon = "🚗", Color = "#2196F3", IsSystemCategory = true },
                    new Category { CategoryName = "Entertainment", Icon = "🎬", Color = "#9C27B0", IsSystemCategory = true },
                    new Category { CategoryName = "Dining Out", Icon = "🍔", Color = "#FF9800", IsSystemCategory = true },
                    new Category { CategoryName = "Shopping", Icon = "🛍️", Color = "#E91E63", IsSystemCategory = true },
                    new Category { CategoryName = "Utilities", Icon = "💡", Color = "#607D8B", IsSystemCategory = true },
                    new Category { CategoryName = "Healthcare", Icon = "🏥", Color = "#00BCD4", IsSystemCategory = true },
                    new Category { CategoryName = "Education", Icon = "📚", Color = "#3F51B5", IsSystemCategory = true },
                    new Category { CategoryName = "Income", Icon = "💰", Color = "#4CAF50", IsSystemCategory = true },
                    new Category { CategoryName = "Transfer", Icon = "🔄", Color = "#FF5722", IsSystemCategory = true }
                };
                context.Categories.AddRange(categories);
                context.SaveChanges();

                // ========== STEP 6: SEED TEST CUSTOMER ==========
                var customer = new Customer
                {
                    FirstName = "John",
                    LastName = "Doe",
                    Email = "john.doe@example.com",
                    PhoneNumber = "0821234567",
                    IDNumber = "8001015009087",
                    DateJoined = DateTime.Now,
                    IsActive = true
                };
                context.Customers.Add(customer);
                context.SaveChanges();

                // ========== STEP 7: SEED TEST ACCOUNT ==========
                var savingsType = context.AccountTypes.First(at => at.TypeName == "Savings Account");
                var account = new Account
                {
                    AccountNumber = "1000000001",
                    AccountName = "Main Savings",
                    Balance = 10000.00m,
                    AvailableBalance = 10000.00m,
                    DateOpened = DateTime.Now,
                    IsActive = true,
                    IsPrimary = true,
                    CustomerID = customer.CustomerID,
                    AccountTypeID = savingsType.AccountTypeId
                };
                context.Accounts.Add(account);
                context.SaveChanges();

                // ========== STEP 8: SEED SAMPLE TRANSACTIONS ==========
                var groceryCat = context.Categories.First(c => c.CategoryName == "Groceries");
                var transportCat = context.Categories.First(c => c.CategoryName == "Transport");
                var entertainmentCat = context.Categories.First(c => c.CategoryName == "Entertainment");
                var incomeCat = context.Categories.First(c => c.CategoryName == "Income");

                var transactions = new Transaction[]
                {
                    new Transaction
                    {
                        AccountID = account.AccountID,
                        Amount = 5000.00m,
                        Description = "Monthly salary deposit",
                        MerchantName = "Employer Pty Ltd",
                        BalanceAfter = 5000.00m,
                        TransactionType = "Deposit",
                        CategoryID = incomeCat.CategoryID,
                        TransactionDate = DateTime.Now.AddDays(-30)
                    },
                    new Transaction
                    {
                        AccountID = account.AccountID,
                        Amount = -850.30m,
                        Description = "Grocery shopping",
                        MerchantName = "Checkers",
                        BalanceAfter = 4149.70m,
                        TransactionType = "Withdrawal",
                        CategoryID = groceryCat.CategoryID,
                        TransactionDate = DateTime.Now.AddDays(-25)
                    },
                    new Transaction
                    {
                        AccountID = account.AccountID,
                        Amount = -250.00m,
                        Description = "Uber rides",
                        MerchantName = "Uber",
                        BalanceAfter = 3899.70m,
                        TransactionType = "Withdrawal",
                        CategoryID = transportCat.CategoryID,
                        TransactionDate = DateTime.Now.AddDays(-20)
                    },
                    new Transaction
                    {
                        AccountID = account.AccountID,
                        Amount = -350.00m,
                        Description = "Movie and dinner",
                        MerchantName = "Ster Kinekor",
                        BalanceAfter = 3549.70m,
                        TransactionType = "Withdrawal",
                        CategoryID = entertainmentCat.CategoryID,
                        TransactionDate = DateTime.Now.AddDays(-15)
                    },
                    new Transaction
                    {
                        AccountID = account.AccountID,
                        Amount = 5000.00m,
                        Description = "Monthly salary deposit",
                        MerchantName = "Employer Pty Ltd",
                        BalanceAfter = 8549.70m,
                        TransactionType = "Deposit",
                        CategoryID = incomeCat.CategoryID,
                        TransactionDate = DateTime.Now.AddDays(-1)
                    }
                };
                context.Transactions.AddRange(transactions);
                context.SaveChanges();
            }
        
           }
        }
}
    
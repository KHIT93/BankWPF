namespace Bank.Data.Migrations
{
    using Bank.Data.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Bank.Data.Context.BankDatabaseContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Bank.Data.Context.BankDatabaseContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            context.Users.AddOrUpdate(
                u => u.Username,
                new User { Username = "admin", Password = "lU7OMILuKlg=", Name = "Administrator" },
                new User { Username = "kenneth", Password = "VQYM4B8ohd7BlurjDWql6g==", Name = "Kenneth Hansen" }
            );
            context.Customers.AddOrUpdate(
                c => c.FirstName,
                new Customer { FirstName = "Jens", LastName = "Jensen" },
                new Customer { FirstName = "Peter", LastName = "Larsen" },
                new Customer { FirstName = "Bill", LastName = "Jobs", CompanyName = "Microsoft Danmark"},
                new Customer { FirstName = "Egon", LastName = "Petsen", CompanyName = "Restaurant Grillhest ApS"}
            );
            context.SaveChanges();
            context.Accounts.AddOrUpdate(
                a => a.Name,
                new SalaryAccount { Customer = context.Customers.First(c => c.FirstName == "Jens" && c.LastName == "Jensen"), Name = "Lønkonto"},
                new SavingsAccount { Customer = context.Customers.First(c => c.FirstName == "Egon" && c.LastName == "Petsen"), Name = "Dårlige tider"},
                new Overdraft { Customer = context.Customers.First(c => c.FirstName == "Egon" && c.LastName == "Petsen"), Name = "Driftskonto Grillhest"},
                new SalaryAccount { Customer = context.Customers.First(c => c.FirstName == "Egon" && c.LastName == "Petsen"), Name = "Til mig"},
                new SavingsAccount { Customer = context.Customers.First(c => c.FirstName == "Peter" && c.LastName == "Larsen"), Name = "Opsparing"},
                new Overdraft { Customer = context.Customers.First(c => c.FirstName == "Bill" && c.LastName == "Jobs"), Name = "Microsoft"},
                new SalaryAccount { Customer = context.Customers.First(c => c.FirstName == "Bill" && c.LastName == "Jobs"), Name = "Lønkonto (Bill Jobs)"}
            );
            context.SaveChanges();
            context.Transactions.AddOrUpdate(
                t => t.Description,
                #region Transactions for Lønkonto Bill Jobs
                new Transaction(context.Accounts.First(a => a.Name == "Lønkonto (Bill Jobs)" && a.Customer.FirstName == "Bill" && a.Customer.LastName == "Jobs"), 15000, "Løn fra arbejde Juni 2017"),
                new Transaction(context.Accounts.First(a => a.Name == "Lønkonto (Bill Jobs)" && a.Customer.FirstName == "Bill" && a.Customer.LastName == "Jobs"), -3000, "Husleje Juni 2017"),
                new Transaction(context.Accounts.First(a => a.Name == "Lønkonto (Bill Jobs)" && a.Customer.FirstName == "Bill" && a.Customer.LastName == "Jobs"), -3000, "Forsikring 2017-2018"),
                new Transaction(context.Accounts.First(a => a.Name == "Lønkonto (Bill Jobs)" && a.Customer.FirstName == "Bill" && a.Customer.LastName == "Jobs"), 3000, "Depositum BoxIT"),
                new Transaction(context.Accounts.First(a => a.Name == "Lønkonto (Bill Jobs)" && a.Customer.FirstName == "Bill" && a.Customer.LastName == "Jobs"), -3000, "Afdrag AA12345"),
                #endregion
                #region Transactions for Lønkonto Jens Jensen
                new Transaction(context.Accounts.First(a => a.Name == "Lønkonto" && a.Customer.FirstName == "Jens" && a.Customer.LastName == "Jensen"), 30000, "Løn Maj 2017"),
                #endregion
                #region Transactions for Driftskonto Grillhest Egon Petsen
                new Transaction(context.Accounts.First(a => a.Name == "Driftskonto Grillhest" && a.Customer.FirstName == "Egon" && a.Customer.LastName == "Petsen"), 3000, "Start kapital"),
                new Transaction(context.Accounts.First(a => a.Name == "Driftskonto Grillhest" && a.Customer.FirstName == "Egon" && a.Customer.LastName == "Petsen"), -2500, "Hestekød"),
                new Transaction(context.Accounts.First(a => a.Name == "Driftskonto Grillhest" && a.Customer.FirstName == "Egon" && a.Customer.LastName == "Petsen"), 50000, "Anden etnisk tilskud"),
                new Transaction(context.Accounts.First(a => a.Name == "Driftskonto Grillhest" && a.Customer.FirstName == "Egon" && a.Customer.LastName == "Petsen"), 75000, "Banklån"),
                new Transaction(context.Accounts.First(a => a.Name == "Driftskonto Grillhest" && a.Customer.FirstName == "Egon" && a.Customer.LastName == "Petsen"), -60000, "Køb af nye borde og stole"),
                new Transaction(context.Accounts.First(a => a.Name == "Driftskonto Grillhest" && a.Customer.FirstName == "Egon" && a.Customer.LastName == "Petsen"), 500, "Omsætning fra Dankort 01062017"),
                new Transaction(context.Accounts.First(a => a.Name == "Driftskonto Grillhest" && a.Customer.FirstName == "Egon" && a.Customer.LastName == "Petsen"), -18000, "Løn til mig selv"),
                new Transaction(context.Accounts.First(a => a.Name == "Driftskonto Grillhest" && a.Customer.FirstName == "Egon" && a.Customer.LastName == "Petsen"), 3000, "Manuel indbetaling 01062017"),
                new Transaction(context.Accounts.First(a => a.Name == "Driftskonto Grillhest" && a.Customer.FirstName == "Egon" && a.Customer.LastName == "Petsen"), 4569, "Omsætning fra Dankort 05062017"),
                new Transaction(context.Accounts.First(a => a.Name == "Driftskonto Grillhest" && a.Customer.FirstName == "Egon" && a.Customer.LastName == "Petsen"), -3000, "Dankort gebyrer Maj 2017"),
                new Transaction(context.Accounts.First(a => a.Name == "Driftskonto Grillhest" && a.Customer.FirstName == "Egon" && a.Customer.LastName == "Petsen"), -3000, "Renter af overtræk Marts 2017"),
                #endregion
                #region Transactions for Til mig Egon Petsen
                new Transaction(context.Accounts.First(a => a.Name == "Til mig" && a.Customer.FirstName == "Egon" && a.Customer.LastName == "Petsen"), 18000, "Løn for hårdt arbejde"),
                new Transaction(context.Accounts.First(a => a.Name == "Til mig" && a.Customer.FirstName == "Egon" && a.Customer.LastName == "Petsen"), -2500, "Forsirking af min dyre bil")
                #endregion
            );
            context.SaveChanges();
            Bank.Data.Services.BankDataService.Instance.CalculateBalance();
        }
    }
}

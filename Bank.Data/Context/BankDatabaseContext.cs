using System;
using System.Data.Entity;
using System.Linq;
using Bank.Data.Models;

namespace Bank.Data.Context
{
    

    public class BankDatabaseContext : DbContext
    {
        // Your context has been configured to use a 'BankDatabaseContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'Bank.Data.Context.BankDatabaseContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'BankDatabaseContext' 
        // connection string in the application configuration file.
        public BankDatabaseContext()
            : base("name=BankDatabaseContext")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Transaction> Transactions { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}
using Bank.Data.Context;
using Bank.Data.Interfaces;
using Bank.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Data.Repositories
{
    public class AccountRepository : IRepository<Account>
    {
        public Account Create(Account entity, User user)
        {
            using (var context = new BankDatabaseContext())
            {
                Customer customer = context.Customers.Find(entity.Customer.Id);
                entity.Customer = customer;
                context.Accounts.Add(entity);
                int x = context.SaveChanges();
                return entity;
            }

        }

        public async Task<Account> CreateAsync(Account entity, User user)
        {
            using (var context = new BankDatabaseContext())
            {
                Customer customer = context.Customers.Find(entity.Customer.Id);
                entity.Customer = customer;
                context.Accounts.Add(entity);
                int x = await context.SaveChangesAsync();
                return entity;
            }
        }

        public bool Delete(int Id, User user)
        {
            bool success = false;
            using (var context = new BankDatabaseContext())
            {
                Account entity = context.Accounts.Find(Id);
                context.Transactions.RemoveRange(entity.Transactions);
                context.Accounts.Remove(entity);
                context.SaveChanges();
                success = true;
            }
            return success;
        }

        public async Task<bool> DeleteAsync(int Id, User user)
        {
            bool success = false;
            using (var context = new BankDatabaseContext())
            {
                Account entity = await context.Accounts.FindAsync(Id);
                context.Transactions.RemoveRange(entity.Transactions);
                context.Accounts.Remove(entity);
                int x = await context.SaveChangesAsync();
                success = (x > 0) ? true : false;
            }
            return success;
        }

        public Account Get(int Id, string include)
        {
            using (var context = new BankDatabaseContext())
            {
                return (include == null) ? context.Accounts.Find(Id) : context.Accounts.Where(a => a.AccountId == Id).Include(include).First();
            }
        }

        public Account GetWithAll(int Id)
        {
            using (var context = new BankDatabaseContext())
            {
                return context.Accounts.Where(a => a.AccountId == Id).Include("Customer").Include("Transactions").First();
            }
        }

        public async Task<Account> GetAsync(int Id, string include)
        {
            using (var context = new BankDatabaseContext())
            {
                return await ((include == null) ? context.Accounts.FindAsync(Id) : context.Accounts.Where(a => a.AccountId == Id).Include(include).FirstAsync());
            }
        }

        public async Task<Account> GetWithAllAsync(int Id)
        {
            using (var context = new BankDatabaseContext())
            {
                return await context.Accounts.Where(a => a.AccountId == Id).Include("Customer").Include("Transactions").FirstAsync();
            }
        }

        public ICollection<Account> GetAll()
        {
            using (var context = new BankDatabaseContext())
            {
                return context.Accounts.ToList();
            }
        }
        public async Task<ICollection<Account>> GetAllAsync()
        {
            return await new Task<ICollection<Account>>(() =>
            {
                using (var context = new BankDatabaseContext())
                {
                    return context.Accounts.ToList();
                }
            });
        }

        public Account Update(Account entity, User user)
        {
            using (var context = new BankDatabaseContext())
            {
                context.Entry(entity).State = EntityState.Modified;
                context.SaveChanges();
                return entity;
            }
        }

        public async Task<Account> UpdateAsync(Account entity, User user)
        {
            using (var context = new BankDatabaseContext())
            {
                context.Entry(entity).State = EntityState.Modified;
                int x = await context.SaveChangesAsync();
                return entity;
            }
        }

        public void CalculateBalanceForAccount(int accountId)
        {
            using (var context = new BankDatabaseContext())
            {
                Account entity = context.Accounts.Find(accountId);
                entity.CalculateBalance();
                context.Entry(entity).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}

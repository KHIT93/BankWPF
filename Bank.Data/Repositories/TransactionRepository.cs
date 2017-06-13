using Bank.Data.Context;
using Bank.Data.Interfaces;
using Bank.Data.Models;
using Bank.Data.Services;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Data.Repositories
{
    public class TransactionRepository : IRepository<Transaction>
    {
        public Transaction Create(Transaction entity)
        {
            using (var context = new BankDatabaseContext())
            {
                Account account = context.Accounts.Find(entity.Account.AccountId);
                entity.Account = account;
                context.Transactions.Add(entity);
                context.SaveChanges();
                return entity;
            }

        }

        public async Task<Transaction> CreateAsync(Transaction entity)
        {
            using (var context = new BankDatabaseContext())
            {
                Account account = context.Accounts.Find(entity.Account.AccountId);
                entity.Account = account;
                context.Transactions.Add(entity);
                int x = await context.SaveChangesAsync();

                return entity;
            }
        }

        public bool Delete(int Id)
        {
            bool success = false;
            using (var context = new BankDatabaseContext())
            {
                Transaction entity = context.Transactions.Find(Id);
                context.Transactions.Remove(entity);
                context.SaveChangesAsync();
                success = true;
            }
            return success;
        }

        public async Task<bool> DeleteAsync(int Id)
        {
            bool success = false;
            using (var context = new BankDatabaseContext())
            {
                Transaction entity = await context.Transactions.FindAsync(Id);
                context.Transactions.Remove(entity);
                int x = await context.SaveChangesAsync();
                success = (x > 0) ? true : false;
            }
            return success;
        }

        public Transaction Get(int Id, string include)
        {
            using (var context = new BankDatabaseContext())
            {
                return (include == null) ? context.Transactions.Find(Id) : context.Transactions.Where(t => t.Id == Id).Include(include).First();
            }
        }

        public Transaction GetWithAll(int Id)
        {
            using (var context = new BankDatabaseContext())
            {
                return context.Transactions.Where(t => t.Id == Id).Include("Account").First();
            }
        }

        public async Task<Transaction> GetAsync(int Id, string include)
        {
            using (var context = new BankDatabaseContext())
            {
                return await ((include == null) ? context.Transactions.FindAsync(Id) : context.Transactions.Where(t => t.Id == Id).FirstAsync());
            }
        }

        public async Task<Transaction> GetWithAllAsync(int Id)
        {
            using (var context = new BankDatabaseContext())
            {
                return await context.Transactions.Where(t => t.Id == Id).Include("Account").FirstAsync();
            }
        }

        public ICollection<Transaction> GetAll()
        {
            using (var context = new BankDatabaseContext())
            {
                return context.Transactions.ToList();
            }
        }
        public async Task<ICollection<Transaction>> GetAllAsync()
        {
            return await new Task<ICollection<Transaction>>(() =>
            {
                using (var context = new BankDatabaseContext())
                {
                    return context.Transactions.ToList();
                }
            });
        }

        public Transaction Update(Transaction entity)
        {
            using (var context = new BankDatabaseContext())
            {
                context.Entry(entity).State = EntityState.Modified;
                context.SaveChanges();
                return entity;
            }
        }

        public async Task<Transaction> UpdateAsync(Transaction entity)
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
            throw new NotImplementedException();
        }
    }
}

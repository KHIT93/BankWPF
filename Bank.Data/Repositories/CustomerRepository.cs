using Bank.Data.Context;
using Bank.Data.Interfaces;
using Bank.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Bank.Data.Repositories
{
    public class CustomerRepository : IRepository<Customer>
    {
        public Customer Create(Customer entity)
        {
            using (var context = new BankDatabaseContext())
            {
                context.Customers.Add(entity);
                int x = context.SaveChanges();
                return entity;
            }

        }

        public async Task<Customer> CreateAsync(Customer entity)
        {
            using (var context = new BankDatabaseContext())
            {
                context.Customers.Add(entity);
                int x = await context.SaveChangesAsync();
                return entity;
            }
        }

        public bool Delete(Customer entity)
        {
            bool success = false;
            using (var context = new BankDatabaseContext())
            {
                context.Customers.Remove(entity);
                context.SaveChangesAsync();
                success = true;
            }
            return success;
        }

        public async Task<bool> DeleteAsync(Customer entity)
        {
            bool success = false;
            using (var context = new BankDatabaseContext())
            {
                context.Customers.Remove(entity);
                int x = await context.SaveChangesAsync();
                success = (x > 0) ? true : false;
            }
            return success;
        }

        public Customer Get(int Id, string include)
        {
            using (var context = new BankDatabaseContext())
            {
                return (include == null) ? context.Customers.Find(Id) : context.Customers.Where(c => c.Id == Id).Include(include).First();
            }
        }

        public Customer GetWithAll(int Id)
        {
            using (var context = new BankDatabaseContext())
            {
                return context.Customers.Where(c => c.Id == Id).Include("Accounts").First();
            }
        }

        public async Task<Customer> GetAsync(int Id, string include)
        {
            using (var context = new BankDatabaseContext())
            {
                return await ((include == null) ? context.Customers.FindAsync(Id) : context.Customers.Where(c => c.Id == Id).Include(include).FirstAsync());
            }
        }

        public async Task<Customer> GetWithAllAsync(int Id)
        {
            using (var context = new BankDatabaseContext())
            {
                return await context.Customers.Where(c => c.Id == Id).Include("Transactions").FirstAsync();
            }
        }

        public ICollection<Customer> GetAll()
        {
            using (var context = new BankDatabaseContext())
            {
                return context.Customers.ToList();
            }
        }
        public async Task<ICollection<Customer>> GetAllAsync()
        {
            return await new Task<ICollection<Customer>>(() =>
             {
                 using (var context = new BankDatabaseContext())
                 {
                     return context.Customers.ToList();
                 }
             });
        }

        public Customer Update(Customer entity)
        {
            using (var context = new BankDatabaseContext())
            {
                context.Entry(entity).State = EntityState.Modified;
                context.SaveChanges();
                return entity;
            }
        }

        public async Task<Customer> UpdateAsync(Customer entity)
        {
            using (var context = new BankDatabaseContext())
            {
                context.Entry(entity).State = EntityState.Modified;
                int x = await context.SaveChangesAsync();
                return entity;
            }
        }
    }
}

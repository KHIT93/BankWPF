﻿using Bank.Data.Context;
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
    public class TransactionRepository : IRepository<Transaction>
    {
        public Transaction Create(Transaction entity)
        {
            using (var context = new BankDatabaseContext())
            {
                context.Transactions.Add(entity);
                int x = context.SaveChanges();
                return entity;
            }

        }

        public async Task<Transaction> CreateAsync(Transaction entity)
        {
            using (var context = new BankDatabaseContext())
            {
                context.Transactions.Add(entity);
                int x = await context.SaveChangesAsync();
                return entity;
            }
        }

        public bool Delete(Transaction entity)
        {
            bool success = false;
            using (var context = new BankDatabaseContext())
            {
                context.Transactions.Remove(entity);
                context.SaveChangesAsync();
                success = true;
            }
            return success;
        }

        public async Task<bool> DeleteAsync(Transaction entity)
        {
            bool success = false;
            using (var context = new BankDatabaseContext())
            {
                context.Transactions.Remove(entity);
                int x = await context.SaveChangesAsync();
                success = (x > 0) ? true : false;
            }
            return success;
        }

        public Transaction Get(int Id)
        {
            using (var context = new BankDatabaseContext())
            {
                return context.Transactions.Find(Id);
            }
        }

        public async Task<Transaction> GetAsync(int Id)
        {
            using (var context = new BankDatabaseContext())
            {
                return await context.Transactions.FindAsync(Id);
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
    }
}
using Bank.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Data.Interfaces
{
    public interface IRepository<T>
    {
        T Get(int Id, string include);
        Task<T> GetAsync(int Id, string include);
        T GetWithAll(int Id);
        Task<T> GetWithAllAsync(int Id);
        ICollection<T> GetAll();
        Task<ICollection<T>> GetAllAsync();
        T Create(T entity, User user);
        Task<T> CreateAsync(T entity, User user);
        T Update(T entity, User user);
        Task<T> UpdateAsync(T entity, User user);
        Boolean Delete(int Id, User user);
        Task<Boolean> DeleteAsync(int Id, User user);
        void CalculateBalanceForAccount(int accountId);
    }
}

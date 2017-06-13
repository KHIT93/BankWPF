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
        T Create(T entity);
        Task<T> CreateAsync(T entity);
        T Update(T entity);
        Task<T> UpdateAsync(T entity);
        Boolean Delete(int Id);
        Task<Boolean> DeleteAsync(int Id);
        void CalculateBalanceForAccount(int accountId);
    }
}

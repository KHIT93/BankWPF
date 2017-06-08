using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Data.Interfaces
{
    public interface IRepository<T>
    {
        T Get();
        ICollection<T> GetAll();
        T Create(T entity);
        T Update(T entity);
        Boolean Delete(T entity);

    }
}

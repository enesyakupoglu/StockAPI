using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockAPI.Repository
{
    public interface IRepository<T>
    {
        Task<T> Create(T _object);
        T GetById(int Id);
        Task<List<T>> GetAllListAsync();


    }
}

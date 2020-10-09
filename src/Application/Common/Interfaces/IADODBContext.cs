using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CleanApp.Application.Common.Interfaces
{
    public interface IADODBContext<T> where T : class
    {
        Task<long> AddAsync(T entity);
        Task DeleteAsync(long ID);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIDAsync(long ID);
        Task<IEnumerable<T>> QueryAsync(string where = null);
        Task<List<T>> ExecuteStoredProc(string spName, object parameters);
        Task UpdateAsync(T entity);
    }
}

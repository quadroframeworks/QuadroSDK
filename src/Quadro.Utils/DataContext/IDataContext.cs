using Quadro.Utils.Storage;
using System.Linq.Expressions;

namespace Quadro.Utils.DataContext
{
    public interface IDataContext
    {
        void Delete<T>(T item) where T:class, IStorable;
        Task DeleteAsync<T>(T item) where T : class, IStorable;
        T? Get<T>(string? id) where T : class, IStorable;
        Task<T?> GetAsync<T>(string? id) where T : class, IStorable;
        IEnumerable<T> GetAll<T>() where T : class, IStorable;
        Task<IEnumerable<T>> GetAllAsync<T>() where T : class, IStorable;
        T GetAndThrowIfNotFound<T>(string id) where T : class, IStorable;
        Task<T> GetAndThrowIfNotFoundAsync<T>(string id) where T : class, IStorable;
        IEnumerable<T> Query<T>(Expression<Func<T, bool>> filter) where T : class, IStorable;
        Task<IEnumerable<T>> QueryAsync<T>(Expression<Func<T, bool>> filter) where T : class, IStorable;
        void Update<T>(T item) where T : class, IStorable;
        Task UpdateAsync<T>(T item) where T : class, IStorable;

    }
}

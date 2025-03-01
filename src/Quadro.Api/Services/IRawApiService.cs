using Quadro.Utils.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quadro.Api.Services
{
    public interface IRawApiService
    {
        Task<IEnumerable<T>> GetAllRaw<T>() where T : IStorable;
        Task<T> CreateRaw<T>() where T : IStorable;
        Task<T> ReadRaw<T>(string id) where T : IStorable;
        Task<T> UpdateRaw<T>(T item) where T : IStorable;
        Task<T> DeleteRaw<T>(T item) where T : IStorable;
    }
}

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
        Task<IEnumerable<T>> GetAllRaw<T>(string? baseUri = null) where T : IStorable;
        Task<T> CreateRaw<T>(string? baseUri = null) where T : IStorable;
        Task<T> ReadRaw<T>(string id, string? baseUri = null) where T : IStorable;
        Task<T> UpdateRaw<T>(T item, string? baseUri = null) where T : IStorable;
        Task<T> DeleteRaw<T>(T item, string? baseUri = null) where T : IStorable;

    }
}

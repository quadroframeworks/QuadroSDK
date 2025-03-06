using Quadro.DataModel.Entities.Catalog;
using Quadro.DataModel.Entities.Customers;
using Quadro.DataModel.Entities.Projects;
using Quadro.Utils.Logging;
using Quadro.Utils.Storage;
using System.Net.Http.Json;

namespace Quadro.Api.Services.Default
{
    public class RawApiService : IRawApiService
    {

        private readonly ILog log;
        private IHttpClientProvider clientProvider;
        private HttpJsonFunctions jsonFunctions;
        public RawApiService(ILog log, IHttpClientProvider clientProvider, HttpJsonFunctions jsonFunctions)
        {
            this.log = log;
            this.clientProvider = clientProvider;
            this.jsonFunctions = jsonFunctions;
            baseUris.Add(typeof(CustomerDto), "CustomerV2");
            baseUris.Add(typeof(SupplierDto), "SupplierV2");
            baseUris.Add(typeof(CatalogItemDto), "CatalogItemV2");
            baseUris.Add(typeof(ProjectDto), "ProjectV2");
        }


        private Dictionary<Type, string> baseUris = new Dictionary<Type, string>();
        private string GetBaseUri(Type type)
        {
            var found = baseUris.TryGetValue(type, out var baseUri);
            if (!found)
                throw new Exception($"Base endpoint uri for type {type} not defined.");
            return baseUri!;
        }

        public async Task<IEnumerable<T>> GetAllRaw<T>(string? baseUri = null) where T : IStorable
        {
            if (baseUri == null)
                baseUri = GetBaseUri(typeof(T));
            var client = clientProvider.GetClient();
            HttpResponseMessage response = await client.GetAsync($"{baseUri}/GetAllRaw");
            return await jsonFunctions.ReadFromJsonAsync<IEnumerable<T>>(response);
        }

        public async Task<T> CreateRaw<T>(string? baseUri = null) where T : IStorable
        {
            if (baseUri == null)
                baseUri = GetBaseUri(typeof(T));
            var client = clientProvider.GetClient();
            HttpResponseMessage response = await client.GetAsync($"{baseUri}/CreateRaw");
            return await jsonFunctions.ReadFromJsonAsync<T>(response);
        }

        public async Task<T> ReadRaw<T>(string id, string? baseUri = null) where T : IStorable
        {
            if (baseUri == null)
                baseUri = GetBaseUri(typeof(T));
            var client = clientProvider.GetClient();
            HttpResponseMessage response = await client.GetAsync($"{baseUri}/ReadRaw?id={id}");
            return await jsonFunctions.ReadFromJsonAsync<T>(response);
        }

        public async Task<T> UpdateRaw<T>(T item, string? baseUri = null) where T : IStorable
        {
            if (baseUri == null)
                baseUri = GetBaseUri(typeof(T));
            var client = clientProvider.GetClient();
            HttpResponseMessage response = await client.PutAsJsonAsync($"{baseUri}/UpdateRaw", item, jsonFunctions.JsonOptions);
            return await jsonFunctions.ReadFromJsonAsync<T>(response);
        }

        public async Task<T> DeleteRaw<T>(T item, string? baseUri = null) where T : IStorable
        {
            if (baseUri == null)
                baseUri = GetBaseUri(typeof(T));
            var client = clientProvider.GetClient();
            HttpResponseMessage response = await client.PutAsJsonAsync($"{baseUri}/DeleteRaw", item, jsonFunctions.JsonOptions);
            return await jsonFunctions.ReadFromJsonAsync<T>(response);
        }
    }
}

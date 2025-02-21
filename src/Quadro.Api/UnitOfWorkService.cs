using Quadro.Documents;
using Quadro.Documents.Filtering;
using Quadro.Documents.Sdk;
using Quadro.Documents.UnitOfWork;
using Quadro.Utils.Logging;
using System.Net.Http.Json;

namespace Quadro.Api
{


    public class UnitOfWorkService : IUnitOfWorkService
    {

        private readonly ILog log;
        private IHttpClientProvider clientProvider;
        private HttpJsonFunctions jsonFunctions;
        public UnitOfWorkService(ILog log, IHttpClientProvider clientProvider, HttpJsonFunctions jsonFunctions)
        {
            this.log = log;
            this.clientProvider = clientProvider;
            this.jsonFunctions = jsonFunctions;
        }

        #region UnitOfWork generic

        public async Task<IEnumerable<SchemaInfo>> GetSchemaInfos()
        {
            var client = clientProvider.GetClient();
            HttpResponseMessage response = await client.GetAsync($"/Root/GetSchemaInfos");
            return await jsonFunctions.ReadFromJsonAsync<List<SchemaInfo>>(response);
        }

        public async Task<UnitOfWork> StartNew(string endpoint)
        {
            var client = clientProvider.GetClient();
            HttpResponseMessage response = await client.GetAsync($"{endpoint}");
            return await jsonFunctions.ReadFromJsonAsync<UnitOfWork>(response);
        }

        public async Task<UnitOfWork> Commit(string endpoint, UnitOfWork uow)
        {
            var client = clientProvider.GetClient();
            HttpResponseMessage response = await client.PutAsJsonAsync<UnitOfWork>($"{endpoint}", uow, jsonFunctions.JsonOptions);
            return await jsonFunctions.ReadFromJsonAsync<UnitOfWork>(response);
        }

        public async Task<UnitOfWork> Discard(string endpoint, UnitOfWork uow)
        {
            var client = clientProvider.GetClient();
            HttpResponseMessage response = await client.PutAsJsonAsync<UnitOfWork>($"{endpoint}", uow, jsonFunctions.JsonOptions);
            return await jsonFunctions.ReadFromJsonAsync<UnitOfWork>(response);
        }

        #endregion

        #region UnitOfWork per entity

        public async Task<DataTypeSchema> GetSchema(string endpoint)
        {
            var client = clientProvider.GetClient();
            HttpResponseMessage response = await client.GetAsync($"{endpoint}");
            return await jsonFunctions.ReadFromJsonAsync<DataTypeSchema>(response);
        }

        public async Task<UnitOfWork> Create(string endpoint, UnitOfWork uow, string actionId)
        {
            var client = clientProvider.GetClient();
            HttpResponseMessage response = await client.PutAsJsonAsync<UnitOfWork>($"{endpoint}?actionId={actionId}", uow, jsonFunctions.JsonOptions);
            return await jsonFunctions.ReadFromJsonAsync<UnitOfWork>(response);
        }

        public async Task<UnitOfWork> CreateOnProperty(string endpoint, UnitOfWork uow, string actionId, string dtoId)
        {
            var client = clientProvider.GetClient();
            HttpResponseMessage response = await client.PutAsJsonAsync<UnitOfWork>($"{endpoint}?actionId={actionId}&dtoId={dtoId}", uow, jsonFunctions.JsonOptions);
            return await jsonFunctions.ReadFromJsonAsync<UnitOfWork>(response);
        }

        public async Task<UnitOfWork> Read(string endpoint, UnitOfWork uow, string actionId, string dtoId)
        {
            var client = clientProvider.GetClient();
            HttpResponseMessage response = await client.PutAsJsonAsync<UnitOfWork>($"{endpoint}?actionId={actionId}&dtoId={dtoId}", uow, jsonFunctions.JsonOptions);
            return await jsonFunctions.ReadFromJsonAsync<UnitOfWork>(response);
        }

        public async Task<UnitOfWork> ReadOnProperty(string endpoint, UnitOfWork uow, string actionId, string dtoId)
        {
            var client = clientProvider.GetClient();
            HttpResponseMessage response = await client.PutAsJsonAsync<UnitOfWork>($"{endpoint}?actionId={actionId}&dtoId={dtoId}", uow, jsonFunctions.JsonOptions);
            return await jsonFunctions.ReadFromJsonAsync<UnitOfWork>(response);
        }

        public async Task<UnitOfWork> Update(string endpoint, UnitOfWorkUpdate update)
        {
            var client = clientProvider.GetClient();
            HttpResponseMessage response = await client.PutAsJsonAsync<UnitOfWorkUpdate>($"{endpoint}", update, jsonFunctions.JsonOptions);
            return await jsonFunctions.ReadFromJsonAsync<UnitOfWork>(response);
        }

        public async Task<UnitOfWork> UpdateProperty(string endpoint, UnitOfWork uow, string dtoId, string propertyName, string? value)
        {
            var client = clientProvider.GetClient();
            HttpResponseMessage response = await client.PutAsJsonAsync<UnitOfWork>($"{endpoint}?dtoId={dtoId}&propertyName={propertyName}&value={value}", uow, jsonFunctions.JsonOptions);
            return await jsonFunctions.ReadFromJsonAsync<UnitOfWork>(response);
        }

        public async Task<UnitOfWork> Delete(string endpoint, UnitOfWork uow, string actionId, string dtoId)
        {
            var client = clientProvider.GetClient();
            HttpResponseMessage response = await client.PutAsJsonAsync<UnitOfWork>($"{endpoint}?actionId={actionId}&dtoId={dtoId}", uow, jsonFunctions.JsonOptions);
            return await jsonFunctions.ReadFromJsonAsync<UnitOfWork>(response);
        }

        public async Task<UnitOfWork> Add(string endpoint, UnitOfWork uow, string actionId, string dtoId)
        {
            var client = clientProvider.GetClient();
            HttpResponseMessage response = await client.PutAsJsonAsync<UnitOfWork>($"{endpoint}?actionId={actionId}&dtoId={dtoId}", uow, jsonFunctions.JsonOptions);
            return await jsonFunctions.ReadFromJsonAsync<UnitOfWork>(response);
        }

        public async Task<UnitOfWork> Remove(string endpoint, UnitOfWork uow, string actionId, string dtoId)
        {
            var client = clientProvider.GetClient();
            HttpResponseMessage response = await client.PutAsJsonAsync<UnitOfWork>($"{endpoint}?actionId={actionId}&dtoId={dtoId}", uow, jsonFunctions.JsonOptions);
            return await jsonFunctions.ReadFromJsonAsync<UnitOfWork>(response);
        }

        public async Task<UnitOfWork> DoAction(string endpoint, UnitOfWork uow, string actionId, string dtoId)
        {
            var client = clientProvider.GetClient();
            HttpResponseMessage response = await client.PutAsJsonAsync<UnitOfWork>($"{endpoint}?actionId={actionId}&dtoId={dtoId}", uow, jsonFunctions.JsonOptions);
            return await jsonFunctions.ReadFromJsonAsync<UnitOfWork>(response);
        }

        public async Task<UnitOfWork> DoCustomAction(string endpoint, CustomActionArgument customArg, string actionId, string dtoId)
        {
            var client = clientProvider.GetClient();
            HttpResponseMessage response = await client.PutAsJsonAsync<CustomActionArgument>($"{endpoint}?actionId={actionId}&dtoId={dtoId}", customArg, jsonFunctions.JsonOptions);
            return await jsonFunctions.ReadFromJsonAsync<UnitOfWork>(response);
        }

        public async Task<UnitOfWork> DoSchemaAction(string endpoint, CustomActionArgument customArg, string actionId)
        {
            var client = clientProvider.GetClient();
            HttpResponseMessage response = await client.PutAsJsonAsync<CustomActionArgument>($"{endpoint}?actionId={actionId}", customArg, jsonFunctions.JsonOptions);
            return await jsonFunctions.ReadFromJsonAsync<UnitOfWork>(response);
        }


        #endregion

        #region Collection calls

        public async Task<EntitySummary> GetItem(string endpoint, string dtoId)
        {
            var client = clientProvider.GetClient();
            HttpResponseMessage response = await client.GetAsync($"{endpoint}?dtoId={dtoId}");
            return await jsonFunctions.ReadFromJsonAsync<EntitySummary>(response);
        }

        public async Task<EntityCollection> GetItems(string endpoint, string? filter)
        {
            var client = clientProvider.GetClient();
            HttpResponseMessage response = await client.GetAsync($"{endpoint}?filter={filter}");
            return await jsonFunctions.ReadFromJsonAsync<EntityCollection>(response);
        }

        public async Task<FilterTree> GetFilterTree(string endpoint)
        {
            var client = clientProvider.GetClient();
            HttpResponseMessage response = await client.GetAsync($"{endpoint}");
            return await jsonFunctions.ReadFromJsonAsync<FilterTree>(response);
        }

        public async Task<SelectableValueCollection> GetSelectableValues(string endpoint, UnitOfWork uow, string dtoId, string propertyName)
        {
            var client = clientProvider.GetClient();
            HttpResponseMessage response = await client.PutAsJsonAsync<UnitOfWork>($"{endpoint}?dtoId={dtoId}&propertyName={propertyName}", uow, jsonFunctions.JsonOptions);
            return await jsonFunctions.ReadFromJsonAsync<SelectableValueCollection>(response);
        }

        #endregion
    }
}

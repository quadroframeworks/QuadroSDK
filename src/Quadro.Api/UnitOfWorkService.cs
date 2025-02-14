using Quadro.Documents;
using Quadro.Documents.Sdk;
using Quadro.Documents.UnitOfWork;
using Quadro.Globalization;
using Quadro.Utils.Logging;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Quadro.Api
{


    public class UnitOfWorkService : IUnitOfWorkService
    {

        private readonly ILog log;
        private readonly IApiConfig config;
        public UnitOfWorkService(ILog log, IApiConfig config)
        {
            this.log = log;
            this.config = config;

            jsonoptions = new JsonSerializerOptions(JsonSerializerDefaults.Web);
            jsonoptions.NumberHandling = JsonNumberHandling.AllowNamedFloatingPointLiterals;
            jsonoptions.Converters.Add(new UnitOfWorkConverter(new EntityTypeProvider()));
        }

        private JsonSerializerOptions jsonoptions;
        private string? bearertoken = null;

        #region Http

        private HttpClient? currentClient;
        private HttpClient GetClient()
        {
            if (currentClient == null)
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                currentClient = new HttpClient();
                currentClient.BaseAddress = new Uri(config.BaseUri);
                currentClient.Timeout = TimeSpan.FromSeconds(900);
                currentClient.DefaultRequestHeaders.Accept.Clear();
                currentClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            }

            currentClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", bearertoken);
            return currentClient;
        }

        private async Task<T> ReadFromJsonAsync<T>(HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<T>(jsonoptions);
                if (result != null)
                    return result;
            }
            else if (response.StatusCode == HttpStatusCode.Forbidden)
            {
                throw new ErrorResultException("Forbidden", "Geen toegang");
            }
            else if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                var contentresult = await response.Content.ReadAsStringAsync();
                var errorresult = await response.Content.ReadFromJsonAsync<ErrorResult>();
                if (errorresult != null)
                    throw new ErrorResultException(errorresult);
            }

            var errorcontent = await response.Content.ReadAsStringAsync();
            throw new Exception(("Error Code" + response.StatusCode + " : Message - " + response.ReasonPhrase + " : Content - " + errorcontent));

        }

        private async Task<string> ReadAsStringAsync(HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                if (result != null)
                    return result;
            }

            var content = await response.Content.ReadAsStringAsync();
            throw new Exception(("Error Code" + response.StatusCode + " : Message - " + response.ReasonPhrase + " : Content - " + content));

        }

        private async Task<byte[]> ReadAsByteArrayAsync(HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsByteArrayAsync();
                if (result != null)
                    return result;
            }

            var content = await response.Content.ReadAsStringAsync();
            throw new Exception(("Error Code" + response.StatusCode + " : Message - " + response.ReasonPhrase + " : Content - " + content));

        }



        #endregion

        #region UnitOfWork general
        public async Task<UnitOfWork> StartNew(string endpoint)
        {
            var client = GetClient();
            HttpResponseMessage response = await client.GetAsync($"{endpoint}");
            return await ReadFromJsonAsync<UnitOfWork>(response);
        }

        public async Task<UnitOfWork> Commit(string endpoint, UnitOfWork uow)
        {
            var client = GetClient();
            HttpResponseMessage response = await client.PutAsJsonAsync<UnitOfWork>($"{endpoint}", uow, jsonoptions);
            return await ReadFromJsonAsync<UnitOfWork>(response);
        }

        public async Task<UnitOfWork> Discard(string endpoint, UnitOfWork uow)
        {
            var client = GetClient();
            HttpResponseMessage response = await client.PutAsJsonAsync<UnitOfWork>($"{endpoint}", uow, jsonoptions);
            return await ReadFromJsonAsync<UnitOfWork>(response);
        }

        #endregion


        #region UnitOfWork per entity

        public async Task<DataTypeSchema> GetSchema(string endpoint)
        {
            var client = GetClient();
            HttpResponseMessage response = await client.GetAsync($"{endpoint}");
            return await ReadFromJsonAsync<DataTypeSchema>(response);
        }

        public async Task<UnitOfWork> Create(string endpoint, UnitOfWork uow, string actionId, string? dtoId = null)
        {
            var client = GetClient();
            HttpResponseMessage response = await client.PutAsJsonAsync<UnitOfWork>($"{endpoint}?actionId={actionId}&dtoId={dtoId}", uow, jsonoptions);
            return await ReadFromJsonAsync<UnitOfWork>(response);
        }

        public async Task<UnitOfWork> Read(string endpoint, UnitOfWork uow, string? actionId, string dtoId)
        {
            var client = GetClient();
            HttpResponseMessage response = await client.PutAsJsonAsync<UnitOfWork>($"{endpoint}?actionId={actionId}&dtoId={dtoId}", uow, jsonoptions);
            return await ReadFromJsonAsync<UnitOfWork>(response);
        }

        public async Task<UnitOfWork> Update(string endpoint, UnitOfWorkUpdate update)
        {
            var client = GetClient();
            HttpResponseMessage response = await client.PutAsJsonAsync<UnitOfWorkUpdate>($"{endpoint}", update, jsonoptions);
            return await ReadFromJsonAsync<UnitOfWork>(response);
        }

        public async Task<UnitOfWork> UpdateProperty(string endpoint, UnitOfWork uow, string dtoId, string propertyName, string? value)
        {
            var client = GetClient();
            HttpResponseMessage response = await client.PutAsJsonAsync<UnitOfWork>($"{endpoint}?dtoId={dtoId}&propertyName={propertyName}&value={value}", uow, jsonoptions);
            return await ReadFromJsonAsync<UnitOfWork>(response);
        }

        public async Task<UnitOfWork> Delete(string endpoint, UnitOfWork uow, string? actionId, string dtoId)
        {
            var client = GetClient();
            HttpResponseMessage response = await client.PutAsJsonAsync<UnitOfWork>($"{endpoint}?actionId={actionId}&dtoId={dtoId}", uow, jsonoptions);
            return await ReadFromJsonAsync<UnitOfWork>(response);
        }

        public async Task<UnitOfWork> DoAction(string endpoint, UnitOfWork uow, string actionId, string dtoId)
        {
            var client = GetClient();
            HttpResponseMessage response = await client.PutAsJsonAsync<UnitOfWork>($"{endpoint}?actionId={actionId}&dtoId={dtoId}", uow, jsonoptions);
            return await ReadFromJsonAsync<UnitOfWork>(response);
        }

        #endregion

        #region Collection calls

        public async Task<EntityCollection> GetItems(string endpoint, string? filter)
        {
            var client = GetClient();
            HttpResponseMessage response = await client.GetAsync($"{endpoint}?filter={filter}");
            return await ReadFromJsonAsync<EntityCollection>(response);
        }

        public async Task<SelectableValueCollection> GetSelectableValues(string endpoint, UnitOfWork uow, string dtoId, string propertyName)
        {
            var client = GetClient();
            HttpResponseMessage response = await client.PutAsJsonAsync<UnitOfWork>($"{endpoint}?dtoId={dtoId}&propertyName={propertyName}", uow, jsonoptions);
            return await ReadFromJsonAsync<SelectableValueCollection>(response);
        }

        #endregion
    }
}

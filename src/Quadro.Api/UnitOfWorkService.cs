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
    public class UnitOfWorkService:IUnitOfWorkService
    {

        private readonly ILog log;
        private readonly IApiConfig config;
        public UnitOfWorkService(ILog log, IApiConfig config)
        {
            this.log = log;
            this.config = config;

            jsonoptions = new JsonSerializerOptions(JsonSerializerDefaults.Web);
            jsonoptions.NumberHandling = JsonNumberHandling.AllowNamedFloatingPointLiterals;
            jsonoptions.PropertyNameCaseInsensitive = true;
            jsonoptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
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

        public async Task<UnitOfWork> Create(string endpoint, UnitOfWork uow, string actionId)
        {
            var client = GetClient();
            HttpResponseMessage response = await client.PutAsJsonAsync<UnitOfWork>($"{endpoint}?actionId={actionId}", uow);
            return await ReadFromJsonAsync<UnitOfWork>(response);
        }

        public Task<UnitOfWork> Read(string endpoint, UnitOfWork uow, string entityId)
        {
            throw new NotImplementedException();
        }

        public Task<UnitOfWork> Update(string endpoint, UnitOfWorkUpdate update)
        {
            throw new NotImplementedException();
        }

        public Task<UnitOfWork> Delete(string endpoint, UnitOfWork uow, string entityId)
        {
            throw new NotImplementedException();
        }

        public Task<UnitOfWork> DoAction(string endpoint, UnitOfWork uow, string entityId, string actionId)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}

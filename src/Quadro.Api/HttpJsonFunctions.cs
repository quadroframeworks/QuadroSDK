using Quadro.Globalization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace Quadro.Api
{
    public class HttpJsonFunctions
    {
        public HttpJsonFunctions() 
        {
            jsonoptions = new JsonSerializerOptions(JsonSerializerDefaults.Web);
            jsonoptions.NumberHandling = JsonNumberHandling.AllowNamedFloatingPointLiterals;
            jsonoptions.Converters.Add(new UnitOfWorkConverter(new EntityTypeProvider()));

        }

        public JsonSerializerOptions JsonOptions => jsonoptions;
        private JsonSerializerOptions jsonoptions;

        public async Task<T> ReadFromJsonAsync<T>(HttpResponseMessage response)
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

        public async Task<string> ReadAsStringAsync(HttpResponseMessage response)
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

        public async Task<byte[]> ReadAsByteArrayAsync(HttpResponseMessage response)
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
    }
}

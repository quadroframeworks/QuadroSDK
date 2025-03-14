using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Quadro.Api
{
    public class HttpClientProvider:IHttpClientProvider
    {

        private readonly IApiConfig config;

        public HttpClientProvider(IApiConfig config)
        {
            this.config = config;
        }

        public HttpClient GetClient()
        {
            if (currentClient == null)
            {
                //ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                currentClient = new HttpClient();
                currentClient.BaseAddress = new Uri(config.BaseUri);
                currentClient.Timeout = TimeSpan.FromSeconds(900);
                currentClient.DefaultRequestHeaders.Accept.Clear();
                currentClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            }

            currentClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", BearerToken);
            return currentClient;
        }

        private HttpClient? currentClient;


        public string? BearerToken { get; set; }
        public string? RefreshToken { get; set; }
    }
}

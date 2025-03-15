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
        private readonly IQuadroAccessTokenProvider accessTokenProvider;
        public HttpClientProvider(IApiConfig config, IQuadroAccessTokenProvider accessTokenProvider)
        {
            this.config = config;
            this.accessTokenProvider = accessTokenProvider;
        }

        public async Task<HttpClient> GetClient()
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

            var token = await accessTokenProvider.GetAccessToken();
            currentClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            return currentClient;
        }

        private HttpClient? currentClient;


    }
}

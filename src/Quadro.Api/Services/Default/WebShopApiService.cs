using Quadro.Documents.UnitOfWork;
using Quadro.Utils.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Quadro.Api.Services.Default
{
    public class WebShopApiService : IWebShopApiService
    {
        private readonly ILog log;
        private IHttpClientProvider clientProvider;
        private HttpJsonFunctions jsonFunctions;
        public WebShopApiService(ILog log, IHttpClientProvider clientProvider, HttpJsonFunctions jsonFunctions)
        {
            this.log = log;
            this.clientProvider = clientProvider;
            this.jsonFunctions = jsonFunctions;
        }

        private string webOrderEndpoint = "WebOrderV2";
        private string webFrameEndpoint = "WebFrameV2";

        public async Task<UnitOfWork> GetShoppingCart()
        {
            var client = await clientProvider.GetClient();
            HttpResponseMessage response = await client.GetAsync($"{webOrderEndpoint}/GetShoppingCart");
            return await jsonFunctions.ReadFromJsonAsync<UnitOfWork>(response);
        }

        public async Task<List<WebShopModelMetaData>> GetWebShopModels()
        {
            var client = await clientProvider.GetClient();
            HttpResponseMessage response = await client.GetAsync($"{webOrderEndpoint}/GetWebShopModels");
            return await jsonFunctions.ReadFromJsonAsync<List<WebShopModelMetaData>>(response);
        }
    }
}

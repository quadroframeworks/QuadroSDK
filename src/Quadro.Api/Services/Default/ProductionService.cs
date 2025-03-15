using Quadro.DataModel.Drawing;
using Quadro.DataModel.Entities.Projects;
using Quadro.DataModel.Model;
using Quadro.DataModel.Production;
using Quadro.ToolSet;
using Quadro.Utils.Logging;

namespace Quadro.Api.Services.Default
{
    public class ProductionService : IProductionService
    {


        private readonly ILog log;
        private readonly IHttpClientProvider clientProvider;
        private readonly HttpJsonFunctions jsonFunctions;


        private string baseUriProjects = "ProjectV2";

        public ProductionService(ILog log, IHttpClientProvider clientProvider, HttpJsonFunctions jsonFunctions)
        {
            this.log = log;
            this.clientProvider = clientProvider;
            this.jsonFunctions = jsonFunctions;
        }


        public async Task<OrderLineBomModelDto> GetOrderLineBomModel(string bomId)
        {
            var url = $"{baseUriProjects}/GetOrderLineBomModel?bomId={bomId}";
            var client = await clientProvider.GetClient();
            var response = await client.GetAsync(url);
            return await jsonFunctions.ReadFromJsonAsync<OrderLineBomModelDto>(response);
        }



        public async Task<string> GetBmhProductionOrder(string projectId, string manufacturingOrderId)
        {
            var url = $"{baseUriProjects}/CreateBosProductionOrder?projectId={projectId}&manufacturingOrderId={manufacturingOrderId}";
            var client = await clientProvider.GetClient();
            var response = await client.GetAsync(url);
            return await jsonFunctions.ReadAsStringAsync(response);
        }

        public async Task<WorkbookDto> GetWorkBook(string projectId, string manufacturingOrderId)
        {
            var url = $"{baseUriProjects}/GetWorkBook?projectId={projectId}&manufacturingOrderId={manufacturingOrderId}";
            var client = await clientProvider.GetClient();
            var response = await client.GetAsync(url);
            return await jsonFunctions.ReadFromJsonAsync<WorkbookDto>(response);
        }




        public async Task<IEnumerable<ProductionFrameDto>> GetProductionFrames(string manufacturingOrderId)
        {
            var url = $"{baseUriProjects}/GetProductionFrames?manufacturingOrderId={manufacturingOrderId}";
            var client = await clientProvider.GetClient();
            var response = await client.GetAsync(url);
            return await jsonFunctions.ReadFromJsonAsync<IEnumerable<ProductionFrameDto>>(response);
        }

        public async Task<ProductionPartModelDto> GetProductionPartModel(string productionPartId, string routeStationId)
        {
            var url = $"{baseUriProjects}/GetProductionPartModel?productionPartId={productionPartId}&routeStationId={routeStationId}";
            var client = await clientProvider.GetClient();
            var response = await client.GetAsync(url);
            return await jsonFunctions.ReadFromJsonAsync<ProductionPartModelDto>(response);
        }

        public async Task<MainAssemblyModelDto> GetProductionFrameModel(string productionFrameId, string routeStationId)
        {
            var url = $"{baseUriProjects}/GetProductionFrameModel?productionFrameId={productionFrameId}&routeStationId={routeStationId}";
            var client = await clientProvider.GetClient();
            var response = await client.GetAsync(url);
            return await jsonFunctions.ReadFromJsonAsync<MainAssemblyModelDto>(response);
        }

        public async Task<HeaderedDescription> GetProductionFrameDescription(string productionFrameId)
        {
            var url = $"{baseUriProjects}/GetProductionFrameDescription?productionFrameId={productionFrameId}";
            var client = await clientProvider.GetClient();
            var response = await client.GetAsync(url);
            return await jsonFunctions.ReadFromJsonAsync<HeaderedDescription>(response);
        }




    }
}

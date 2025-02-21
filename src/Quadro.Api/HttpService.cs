using Quadro.DataModel.Bom;
using Quadro.DataModel.Drawing;
using Quadro.DataModel.Entities.Projects;
using Quadro.DataModel.Entities.Web;
using Quadro.DataModel.Geometrics;
using Quadro.DataModel.Model;
using Quadro.DataModel.Model.Programs;
using Quadro.DataModel.Model.Tools;
using Quadro.DataModel.Production;
using Quadro.Documents;
using Quadro.Documents.UnitOfWork;
using Quadro.ToolSet;
using Quadro.Utils.Logging;
using System.Net.Http.Json;

namespace Quadro.Api
{
    public class HttpService : IApiService
    {

        private readonly ILog log;
        private readonly IHttpClientProvider clientProvider;
        private readonly HttpJsonFunctions jsonFunctions;

        public HttpService(ILog log, IHttpClientProvider clientProvider, HttpJsonFunctions jsonFunctions, IAuthService authService, IUnitOfWorkService uowService)
        {
            this.log = log;
            this.clientProvider = clientProvider;
            this.jsonFunctions = jsonFunctions;
            this.Auth = authService;
            this.UnitOfWork = uowService;
        }


        public IAuthService Auth { get; }

        public IUnitOfWorkService UnitOfWork { get; }
		

		#region Models
		public async Task<MainAssemblyModelDto> GetAssemblyModel(string endpoint, UnitOfWork uow, string dtoId)
        {
            var url = $"{endpoint}/GetDataModel?dtoId={dtoId}";
            var client = clientProvider.GetClient();
            var response = await client.PutAsJsonAsync<UnitOfWork>(url, uow, jsonFunctions.JsonOptions);
            return await jsonFunctions.ReadFromJsonAsync<MainAssemblyModelDto>(response);
        }

        public async Task<ToolModelDto> GetToolModel(string endpoint, DataDocument document)
        {
            var url = $"{endpoint}/GetToolModel?toolIndex=0";
            var client = clientProvider.GetClient();
            var response = await client.PutAsJsonAsync<DataDocument>(url, document, jsonFunctions.JsonOptions);
            return await jsonFunctions.ReadFromJsonAsync<ToolModelDto>(response);
        }

        public async Task<ProfileProgramModelDto> GetProfileProgramModel(string endpoint, string programId)
        {
            var url = $"{endpoint}/GetProgramModelById?programId={programId}";
            var client = clientProvider.GetClient();
            var response = await client.GetAsync(url);
            return await jsonFunctions.ReadFromJsonAsync<ProfileProgramModelDto>(response);
        }

        public async Task<ProfileProgramModelDto> GetProfileProgramModel(string endpoint, DataDocument document)
        {
            var url = $"{endpoint}/GetProgramModel";
            var client = clientProvider.GetClient();
            var response = await client.PutAsJsonAsync<DataDocument>(url, document, jsonFunctions.JsonOptions);
            return await jsonFunctions.ReadFromJsonAsync<ProfileProgramModelDto>(response);
        }

        public async Task<DowelProgramModelDto> GetDowelProgramModel(string endpoint, DataDocument document)
        {
            var url = $"{endpoint}/GetProgramModel";
            var client = clientProvider.GetClient();
            var response = await client.PutAsJsonAsync<DataDocument>(url, document, jsonFunctions.JsonOptions);
            return await jsonFunctions.ReadFromJsonAsync<DowelProgramModelDto>(response);
        }

        public async Task<RabbetSwitchEditorProgramModelDto> GetRabbbetSwitchProgramModel(string endpoint, DataDocument document)
        {
            var url = $"{endpoint}/GetProgramModel";
            var client = clientProvider.GetClient();
            var response = await client.PutAsJsonAsync<DataDocument>(url, document, jsonFunctions.JsonOptions);
            return await jsonFunctions.ReadFromJsonAsync<RabbetSwitchEditorProgramModelDto>(response);
        }

        public async Task<Drawing2DDto> GetModel2D(string endpoint, DataDocument document)
        {
            var url = $"{endpoint}/GetModel2D";
            var client = clientProvider.GetClient();
            var response = await client.PutAsJsonAsync<DataDocument>(url, document, jsonFunctions.JsonOptions);
            return await jsonFunctions.ReadFromJsonAsync<Drawing2DDto>(response);
        }

        public async Task<Drawing2DDto> GetCrossSection(string endpoint, DataDocument document, string partId)
        {
            var url = $"{endpoint}/GetCrossSection?partId={partId}";
            var client = clientProvider.GetClient();
            var response = await client.PutAsJsonAsync<DataDocument>(url, document, jsonFunctions.JsonOptions);
            return await jsonFunctions.ReadFromJsonAsync<Drawing2DDto>(response);
        }

        public async Task<Drawing2DDto> GetFrontViewDrawing(string endpoint, MainAssemblyModelDto model)
        {
            var url = $"{endpoint}/GetFrontView";
            var client = clientProvider.GetClient();
            var response = await client.PutAsJsonAsync<MainAssemblyModelDto>(url, model, jsonFunctions.JsonOptions);
            return await jsonFunctions.ReadFromJsonAsync<Drawing2DDto>(response);
        }

        public async Task<Drawing2DDto> GetSectionViewDrawing(string endpoint, MainAssemblyModelDto model, int sectionId)
        {
            var url = $"{endpoint}/GetSectionView?sectionId={sectionId}";
            var client = clientProvider.GetClient();
            var response = await client.PutAsJsonAsync<MainAssemblyModelDto>(url, model, jsonFunctions.JsonOptions);
            return await jsonFunctions.ReadFromJsonAsync<Drawing2DDto>(response);
        }

        public async Task<HeaderedDescription> GetFrameDescription(string endpoint, MainAssemblyModelDto model)
        {
            var url = $"{endpoint}/GetFrameDescription";
            var client = clientProvider.GetClient();
            var response = await client.PutAsJsonAsync<MainAssemblyModelDto>(url, model, jsonFunctions.JsonOptions);
            return await jsonFunctions.ReadFromJsonAsync<HeaderedDescription>(response);
        }


        public async Task<string> ConvertDrawingToDxf(string endpoint, Drawing2DDto drawing)
        {
            var url = $"{endpoint}/ConvertDrawingToDxf";
            var client = clientProvider.GetClient();
            var response = await client.PutAsJsonAsync<Drawing2DDto>(url, drawing, jsonFunctions.JsonOptions);
            return await jsonFunctions.ReadFromJsonAsync<string>(response);
        }

		public Task<OrderLineBomModelDto> GetOrderLineBomModel(string bomId)
		{
			throw new NotImplementedException();
		}

		#endregion

		#region Specifics
		public async Task<BomModelDto> GetBom(string endpoint, DataDocument document)
        {
            var url = $"{endpoint}";
            var client = clientProvider.GetClient();
            var response = await client.PutAsJsonAsync<DataDocument>(url, document, jsonFunctions.JsonOptions);
            return await jsonFunctions.ReadFromJsonAsync<BomModelDto>(response);
        }

        public async Task<DataDocument> PublishToErp(string endpoint, DataDocument document, string dtoid)
        {
            var url = $"{endpoint}?dtoid={dtoid}";
            var client = clientProvider.GetClient();
            var response = await client.PutAsJsonAsync<DataDocument>(url, document, jsonFunctions.JsonOptions);
            return await jsonFunctions.ReadFromJsonAsync<DataDocument>(response);
        }


        public async Task<bool> InitializeErp(string endpoint)
        {
                var url = $"{endpoint}";
                var client = clientProvider.GetClient();
                var response = await client.GetAsync(url);
                return await jsonFunctions.ReadFromJsonAsync<bool>(response);
        }

        public async Task<bool> SyncWithErp(string endpoint)
        {
                var url = $"{endpoint}";
                var client = clientProvider.GetClient();
                var response = await client.GetAsync(url);
                return await jsonFunctions.ReadFromJsonAsync<bool>(response);
        }

        public async Task<bool> PublishPurchaseOrder(string endpoint)
        {
            var url = $"{endpoint}";
            var client = clientProvider.GetClient();
            var response = await client.GetAsync(url);
            return await jsonFunctions.ReadFromJsonAsync<bool>(response);
        }

        public async Task<IEnumerable<DataDocument>> ImportBmhToolHolders(string endpoint, CustomActionArgument customarg)
        {
            var client = clientProvider.GetClient();
            var response = await client.PutAsJsonAsync<CustomActionArgument>(endpoint, customarg, jsonFunctions.JsonOptions);
            return await jsonFunctions.ReadFromJsonAsync<IEnumerable<DataDocument>>(response);
        }

        public async Task<IEnumerable<DataDocument>> ImportBmhFactory(string endpoint, CustomActionArgument customarg)
        {
            var client = clientProvider.GetClient();
            var response = await client.PutAsJsonAsync<CustomActionArgument>(endpoint, customarg, jsonFunctions.JsonOptions);
            return await jsonFunctions.ReadFromJsonAsync<IEnumerable<DataDocument>>(response);
        }

        public async Task<string> GetBmhProductionOrder(string endpoint, DataDocument document, string dtoid)
        {
            var url = $"{endpoint}?dtoid={dtoid}";
            var client = clientProvider.GetClient();
            var response = await client.PutAsJsonAsync<DataDocument>(url, document, jsonFunctions.JsonOptions);
            return await jsonFunctions.ReadAsStringAsync(response);
        }

        public async Task<WorkbookDto> GetWorkbook(string endpoint, DataDocument document, string dtoid)
        {
            var url = $"{endpoint}?dtoid={dtoid}";
            var client = clientProvider.GetClient();
            var response = await client.PutAsJsonAsync<DataDocument>(url, document, jsonFunctions.JsonOptions);
            return await jsonFunctions.ReadFromJsonAsync<WorkbookDto>(response);
        }

        public async Task<string> GetDxfDrawing(string endpoint, DataDocument document, string dtoid)
        {
            var url = $"{endpoint}?dtoid={dtoid}";
            var client = clientProvider.GetClient();
            var response = await client.PutAsJsonAsync<DataDocument>(url, document, jsonFunctions.JsonOptions);
            return await jsonFunctions.ReadFromJsonAsync<string>(response);
        }

		#endregion

		#region Production

		public async Task<IEnumerable<ProductionFrameDto>> GetProductionFrames(string endpoint, string manufacturingOrderId)
        {
            var url = $"{endpoint}?manufacturingOrderId={manufacturingOrderId}";
            var client = clientProvider.GetClient();
            var response = await client.GetAsync(url);
            return await jsonFunctions.ReadFromJsonAsync<IEnumerable<ProductionFrameDto>>(response);
        }

        public async Task<ProductionPartModelDto> GetProductionPartModel(string endpoint, string productionPartId, string routeStationId)
        {
            var url = $"{endpoint}?productionPartId={productionPartId}&routeStationId={routeStationId}";
            var client = clientProvider.GetClient();
            var response = await client.GetAsync(url);
            return await jsonFunctions.ReadFromJsonAsync<ProductionPartModelDto>(response);
        }

        public async Task<MainAssemblyModelDto> GetProductionFrameModel(string endpoint, string productionFrameId, string routeStationId)
        {
            var url = $"{endpoint}?productionFrameId={productionFrameId}&routeStationId={routeStationId}";
            var client = clientProvider.GetClient();
            var response = await client.GetAsync(url);
            return await jsonFunctions.ReadFromJsonAsync<MainAssemblyModelDto>(response);
        }

        public async Task<HeaderedDescription> GetProductionFrameDescription(string endpoint, string productionFrameId)
        {
            var url = $"{endpoint}?productionFrameId={productionFrameId}";
            var client = clientProvider.GetClient();
            var response = await client.GetAsync(url);
            return await jsonFunctions.ReadFromJsonAsync<HeaderedDescription>(response);
        }

      
        #endregion 

        #region Drawings

        public async Task<byte[]> ConvertWorkbookToDxf(WorkbookDto workbook)
        {
            var url = $"/Drawing/ConvertWorkbookToDxf";
            var client = clientProvider.GetClient();
            var response = await client.PutAsJsonAsync<WorkbookDto>(url, workbook, jsonFunctions.JsonOptions);
            return await jsonFunctions.ReadAsByteArrayAsync(response);
        }


        public async Task<byte[]> ConvertWorkbookToPdf(WorkbookDto workbook)
        {
            var url = $"/Drawing/ConvertWorkbookToPdf";
            var client = clientProvider.GetClient();
            var response = await client.PutAsJsonAsync<WorkbookDto>(url,workbook, jsonFunctions.JsonOptions);
            return await jsonFunctions.ReadAsByteArrayAsync(response);
        }

        public async Task<byte[]> ConvertWorkbookToSvg(WorkbookDto workbook)
        {
            var url = $"/Drawing/ConvertWorkbookToSvg";
            var client = clientProvider.GetClient();
            var response = await client.PutAsJsonAsync<WorkbookDto>(url, workbook, jsonFunctions.JsonOptions);
            return await jsonFunctions.ReadAsByteArrayAsync(response);
        }

		public Task<string> GetFrontViewDrawingSvg(string endpoint, MainAssemblyModelDto model)
		{
			throw new NotImplementedException();
		}

		public Task<string> GetSectionViewDrawingSvg(string endpoint, MainAssemblyModelDto model, int sectionId)
		{
			throw new NotImplementedException();
		}

		#region Web
		public async Task<WebFrameModelDto> GetWebFrontViewSvg(string endpoint, DataDocument document)
		{
			var url = $"{endpoint}/GetWebFrontViewSvg";
			var client = clientProvider.GetClient();
			var response = await client.PutAsJsonAsync<DataDocument>(url, document, jsonFunctions.JsonOptions);
			return await jsonFunctions.ReadFromJsonAsync<WebFrameModelDto>(response);
		}

		#endregion



		#endregion


	}
}

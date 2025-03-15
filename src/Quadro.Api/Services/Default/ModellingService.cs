using Quadro.DataModel.Bom;
using Quadro.DataModel.Entities.Web;
using Quadro.DataModel.Geometrics;
using Quadro.DataModel.Model;
using Quadro.DataModel.Model.Programs;
using Quadro.DataModel.Model.Tools;
using Quadro.Documents.UnitOfWork;
using Quadro.Utils.Logging;
using System.Net.Http.Json;

namespace Quadro.Api.Services.Default
{
    public class ModellingService : IModellingService
    {

        private readonly ILog log;
        private readonly IHttpClientProvider clientProvider;
        private readonly HttpJsonFunctions jsonFunctions;

        public ModellingService(ILog log, IHttpClientProvider clientProvider, HttpJsonFunctions jsonFunctions)
        {
            this.log = log;
            this.clientProvider = clientProvider;
            this.jsonFunctions = jsonFunctions;
        }

        private readonly string baseUriWeb = "WebFrameV2";
        private readonly string baseUriTools = "ToolHolderV2";
        private readonly string baseUriProfilePrograms = "ProfileProgramV2";
        private readonly string baseUriDowelPrograms = "DowelProgramV2";
        private readonly string baseUriRabbetSwitchPrograms = "RabbetSwitchProgramV2";

        //Models
        public async Task<MainAssemblyModelDto> GetAssemblyModel(string baseUri, UnitOfWork uow, string dtoId)
        {
            var url = $"{baseUri}/GetDataModel?dtoId={dtoId}";
            var client = await clientProvider.GetClient();
            var response = await client.PutAsJsonAsync(url, uow, jsonFunctions.JsonOptions);
            return await jsonFunctions.ReadFromJsonAsync<MainAssemblyModelDto>(response);
        }


        public async Task<WebFrameModelDto> GetWebFrontViewSvg(UnitOfWork uow, string dtoId)
        {
            var url = $"{baseUriWeb}/GetWebFrontViewSvg?dtoId={dtoId}";
            var client = await clientProvider.GetClient();
            var response = await client.PutAsJsonAsync(url, uow, jsonFunctions.JsonOptions);
            return await jsonFunctions.ReadFromJsonAsync<WebFrameModelDto>(response);
        }

        public async Task<BomModelDto> GetBom(string baseUri, UnitOfWork uow, string dtoId)
        {
            var url = $"{baseUri}/GetBom?dtoId={dtoId}";
            var client = await clientProvider.GetClient();
            var response = await client.PutAsJsonAsync(url, uow, jsonFunctions.JsonOptions);
            return await jsonFunctions.ReadFromJsonAsync<BomModelDto>(response);
        }

        //2D Models
        public async Task<Drawing2DDto> GetModel2D(string baseUri, string entityId)
        {
            var url = $"{baseUri}/GetModel2D?entityId={entityId}";
            var client = await clientProvider.GetClient();
            var response = await client.GetAsync(url);
            return await jsonFunctions.ReadFromJsonAsync<Drawing2DDto>(response);
        }

        public async Task<Drawing2DDto> GetModel2D(string baseUri, UnitOfWork uow, string dtoId)
        {
            var url = $"{baseUri}/GetModel2D?dtoId={dtoId}";
            var client = await clientProvider.GetClient();
            var response = await client.PutAsJsonAsync(url, uow, jsonFunctions.JsonOptions);
            return await jsonFunctions.ReadFromJsonAsync<Drawing2DDto>(response);
        }

        //Tools
        public async Task<ToolModelDto> GetToolModel(string toolId)
        {
            var url = $"{baseUriTools}/GetToolModelById?toolId={toolId}&toolIndex=0";
            var client = await clientProvider.GetClient();
            var response = await client.GetAsync(url);
            return await jsonFunctions.ReadFromJsonAsync<ToolModelDto>(response);
        }

        public async Task<ToolModelDto> GetToolModel(UnitOfWork uow, string dtoId)
        {
            var url = $"{baseUriTools}/GetToolModel?dtoId={dtoId}&toolIndex=0";
            var client = await clientProvider.GetClient();
            var response = await client.PutAsJsonAsync(url, uow, jsonFunctions.JsonOptions);
            return await jsonFunctions.ReadFromJsonAsync<ToolModelDto>(response);
        }

        //Profile programs
        public async Task<ProfileProgramModelDto> GetProfileProgramModel(string programId)
        {
            var url = $"{baseUriProfilePrograms}/GetProgramModelById?programId={programId}";
            var client = await clientProvider.GetClient();
            var response = await client.GetAsync(url);
            return await jsonFunctions.ReadFromJsonAsync<ProfileProgramModelDto>(response);
        }

        public async Task<ProfileProgramModelDto> GetProfileProgramModel(UnitOfWork uow, string dtoId)
        {
            var url = $"{baseUriProfilePrograms}/GetProgramModel?dtoId={dtoId}";
            var client = await clientProvider.GetClient();
            var response = await client.PutAsJsonAsync(url, uow, jsonFunctions.JsonOptions);
            return await jsonFunctions.ReadFromJsonAsync<ProfileProgramModelDto>(response);
        }

        //Dowel programs
        public async Task<DowelProgramModelDto> GetDowelProgramModel(string programId)
        {
            var url = $"{baseUriDowelPrograms}/GetProgramModelById?programId={programId}";
            var client = await clientProvider.GetClient();
            var response = await client.GetAsync(url);
            return await jsonFunctions.ReadFromJsonAsync<DowelProgramModelDto>(response);
        }

        public async Task<DowelProgramModelDto> GetDowelProgramModel(UnitOfWork uow, string dtoId)
        {
            var url = $"{baseUriDowelPrograms}/GetProgramModel?dtoId={dtoId}";
            var client = await clientProvider.GetClient();
            var response = await client.PutAsJsonAsync(url, uow, jsonFunctions.JsonOptions);
            return await jsonFunctions.ReadFromJsonAsync<DowelProgramModelDto>(response);
        }


        //Rabbet switch programs
        public async Task<RabbetSwitchEditorProgramModelDto> GetRabbetSwitchProgramModel(string programId)
        {
            var url = $"{baseUriRabbetSwitchPrograms}/GetProgramModelById?programId={programId}";
            var client = await clientProvider.GetClient();
            var response = await client.GetAsync(url);
            return await jsonFunctions.ReadFromJsonAsync<RabbetSwitchEditorProgramModelDto>(response);
        }

        public async Task<RabbetSwitchEditorProgramModelDto> GetRabbetSwitchProgramModel(UnitOfWork uow, string dtoId)
        {
            var url = $"{baseUriRabbetSwitchPrograms}/GetProgramModel?dtoId={dtoId}";
            var client = await clientProvider.GetClient();
            var response = await client.PutAsJsonAsync(url, uow, jsonFunctions.JsonOptions);
            return await jsonFunctions.ReadFromJsonAsync<RabbetSwitchEditorProgramModelDto>(response);
        }

    }
}

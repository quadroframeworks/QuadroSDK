using Quadro.DataModel.Authorization;
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
using Quadro.Documents.Filtering;
using Quadro.Globalization;
using Quadro.ToolSet;
using Quadro.Utils.Logging;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Reflection.Metadata;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Quadro.Api
{
	public class HttpService : IApiService
    {

        private readonly ILog log;
        private readonly IApiConfig config;
        public HttpService(ILog log, IApiConfig config)
        {
            this.log = log;
            this.config = config;

            jsonoptions = new JsonSerializerOptions(JsonSerializerDefaults.Web);
            jsonoptions.NumberHandling = JsonNumberHandling.AllowNamedFloatingPointLiterals;
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

		#region Authorization

		public async Task<UserSignInResult> SignIn(string email, string password)
		{
			var url = $"/Authorization/SignIn?email={email}&password={password}";
			var client = GetClient();
			var response = await client.GetAsync(url);
			var result = await ReadFromJsonAsync<UserSignInResult>(response);
			bearertoken = result.Bearer;
			return result;
		}

		public async Task<UserSignOutResult> SignOut()
		{
			var url = $"/Authorization/SignOut";
			var client = GetClient();
			var response = await client.GetAsync(url);
			var result = await ReadFromJsonAsync<UserSignOutResult>(response);
            bearertoken = null;
			return result;
		}

		public async Task<UserRoleInfo> GetUserRoleInfo()
		{
			var url = $"/Authorization/GetUserRoleInfo";
			var client = GetClient();
			var response = await client.GetAsync(url);
			var result = await ReadFromJsonAsync<UserRoleInfo>(response);
			return result;
		}

		public async Task<NewBusinessAccountResult> CreateBusinessAccount(BusinessAccountInfo accountInfo)
		{
			var url = $"/Authorization/CreateBusinessAccount";
			var client = GetClient();
			var response = await client.PutAsJsonAsync<BusinessAccountInfo>(url, accountInfo);
			return await ReadFromJsonAsync<NewBusinessAccountResult>(response);
		}


		public async Task<BusinessAccountInfo> ReadBusinessAccountInfo()
		{
			string url = $"/Authorization/ReadBusinessAccountInfo";
			var client = GetClient();
			HttpResponseMessage response = await client.GetAsync(url);
			return await ReadFromJsonAsync<BusinessAccountInfo>(response);
		}

		public async Task<BusinessAccountInfo> UpdateBusinessAccountInfo(BusinessAccountInfo accountInfo)
		{
			var url = $"/Authorization/UpdateBusinessAccountInfo";
			var client = GetClient();
			var response = await client.PutAsJsonAsync<BusinessAccountInfo>(url, accountInfo);
			return await ReadFromJsonAsync<BusinessAccountInfo>(response);
		}

		public async Task<DeleteBusinessAccountResult> DeleteBusinessAccount()
		{
			string url = $"/Authorization/DeleteBusinessAccount";
			var client = GetClient();
			HttpResponseMessage response = await client.GetAsync(url);
			return await ReadFromJsonAsync<DeleteBusinessAccountResult>(response);
		}

		public async Task<UserAccountInfo> CreateUserAccount(NewUserAccountInfo accountInfo)
		{
			var url = $"/Authorization/CreateUserAccount";
			var client = GetClient();
			var response = await client.PutAsJsonAsync<NewUserAccountInfo>(url, accountInfo);
			return await ReadFromJsonAsync<UserAccountInfo>(response);
		}


		public async Task<IEnumerable<UserAccountInfo>> ReadUserAccounts()
		{
			string url = $"/Authorization/ReadUserAccounts";
			var client = GetClient();
			HttpResponseMessage response = await client.GetAsync(url);
			return await ReadFromJsonAsync<IEnumerable<UserAccountInfo>>(response);
		}

		public async Task<UserAccountInfo> UpdateUserAccount(UserAccountInfo accountInfo)
		{
			var url = $"/Authorization/UpdateUserAccount";
			var client = GetClient();
			var response = await client.PutAsJsonAsync<UserAccountInfo>(url, accountInfo);
			return await ReadFromJsonAsync<UserAccountInfo>(response);
		}


		public async Task<DeleteUserAccountResult> DeleteUserAccount(string email)
		{
			string url = $"/Authorization/DeleteUserAccount?email={email}";
			var client = GetClient();
			HttpResponseMessage response = await client.GetAsync(url);
			return await ReadFromJsonAsync<DeleteUserAccountResult>(response);
		}


		public async Task<ChangePasswordResult> ResetPassword(string oldpassword, string newpassword)
		{
			var url = $"/Authorization/ChangePassword?oldpassword={oldpassword}&newpassword={newpassword}";
			var client = GetClient();
			var response = await client.GetAsync(url);
			var result = await ReadFromJsonAsync<ChangePasswordResult>(response);
			return result;
		}

		public async Task<IEnumerable<SelectableValue>> GetSelectableImages()
		{
			var url = $"/Authorization/GetSelectableImages";
			var client = GetClient();
			var response = await client.GetAsync(url);
			var result = await ReadFromJsonAsync<SelectableValueCollection>(response);
			return result.Values;
		}

		public async Task<IEnumerable<SelectableValue>> GetSelectableCustomers()
		{
			var url = $"/Authorization/GetSelectableCustomers";
			var client = GetClient();
			var response = await client.GetAsync(url);
			var result = await ReadFromJsonAsync<SelectableValueCollection>(response);
			return result.Values;
		}


		#endregion

		#region Documents
		public async Task<IEnumerable<SchemaInfo>> GetSchemaInfos()
        {
            string url = $"/Root/GetSchemaInfos";
            var client = GetClient();
            HttpResponseMessage response = await client.GetAsync(url);
            return await ReadFromJsonAsync<IEnumerable<SchemaInfo>>(response);
        }

        public async Task<IEnumerable<DataDocument>> GetItems(DataTypeSchema schema, RoughFilterType roughFilterType, string? filterString)
        {
            string url = $"{schema.GetItemsEndPoint}?roughFilterType={roughFilterType}&filterString={filterString}";
            var client = GetClient();
            HttpResponseMessage response = await client.GetAsync(url);
            return await ReadFromJsonAsync<IEnumerable<DataDocument>>(response);
        }

        public async Task<IEnumerable<DataDocument>> GetVariants(DataTypeSchema schema, DataDocument document)
        {
            string url = $"{schema.GetVariantsEndPoint}";
            var client = GetClient();
            var response = await client.PutAsJsonAsync<DataDocument>(url, document);
            return await ReadFromJsonAsync<IEnumerable<DataDocument>>(response);
        }


        public async Task<DataTypeSchema> GetSchema(string controller)
        {
            string url = $"/{controller}/GetSchema";
            var client = GetClient();
            HttpResponseMessage response = await client.GetAsync(url);
            return await ReadFromJsonAsync<DataTypeSchema>(response);
        }

        public async Task<IEnumerable<SelectableValue>> GetSelectableValues(string endpoint, DataDocument document, string dtoid, string propertyname)
        {
            var url = $"{endpoint}?dtoid={dtoid}&propertyname={propertyname}";
            var client = GetClient();
            var response = await client.PutAsJsonAsync<DataDocument>(url, document);
            var result = await ReadFromJsonAsync<SelectableValueCollection>(response);
            return result.Values;
        }

		public async Task<FilterTree> GetFilterTree(string endpoint)
		{
			string url = $"{endpoint}";
			var client = GetClient();
			HttpResponseMessage response = await client.GetAsync(url);
			return await ReadFromJsonAsync<FilterTree>(response);
		}

		public async Task<DataDocument> Create(string endpoint)
        {
            var client = GetClient();
            HttpResponseMessage response = await client.GetAsync(endpoint);
            return await ReadFromJsonAsync<DataDocument>(response);
        }


        public async Task<DataDocument> CreateAndAdd(string endpoint, DataDocument document, string dtoid)
        {
            var url = $"{endpoint}?dtoid={dtoid}";
            var client = GetClient();
            var response = await client.PutAsJsonAsync<DataDocument>(url, document);
            return await ReadFromJsonAsync<DataDocument>(response);
        }

        public async Task<DataDocument> CreateCopy(string endpoint, DataDocument document)
        {
            var url = $"{endpoint}";
            var client = GetClient();
            var response = await client.PutAsJsonAsync<DataDocument>(url, document);
            return await ReadFromJsonAsync<DataDocument>(response);
        }

        public async Task<DataDocument> CreateVariant(string endpoint, DataDocument document)
        {
            var url = $"{endpoint}";
            var client = GetClient();
            var response = await client.PutAsJsonAsync<DataDocument>(url, document);
            return await ReadFromJsonAsync<DataDocument>(response);
        }

        public async Task<DataDocument> Read(string endpoint, string dtoid)
        {
            var url = $"{endpoint}?dtoid={dtoid}";
            var client = GetClient();
            var response = await client.GetAsync(url);
            return await ReadFromJsonAsync<DataDocument>(response);
        }

        public async Task<DataDocument> Update(string endpoint, DataDocument document)
        {
            var client = GetClient();
            var response = await client.PutAsJsonAsync<DataDocument>(endpoint, document);
            return await ReadFromJsonAsync<DataDocument>(response);
        }

        public async Task<DataDocument> Delete(string endpoint, DataDocument document, string dtoid)
        {
            var url = $"{endpoint}?dtoid={dtoid}";
            var client = GetClient();
            var response = await client.PutAsJsonAsync<DataDocument>(url, document);
            return await ReadFromJsonAsync<DataDocument>(response);
        }

		public async Task<DataDocument> DoCustom(string endpoint)
		{
			var client = GetClient();
            var response = await client.GetAsync(endpoint);
			return await ReadFromJsonAsync<DataDocument>(response);
		}

		public async Task<DataDocument> DoCustom(string endpoint, DataDocument document)
        {
            var client = GetClient();
            var response = await client.PutAsJsonAsync<DataDocument>(endpoint, document);
            return await ReadFromJsonAsync<DataDocument>(response);
        }

        public async Task<DataDocument> DoCustom(string endpoint, CustomActionArgument customarg)
        {
            var client = GetClient();
            var response = await client.PutAsJsonAsync<CustomActionArgument>(endpoint, customarg);
            return await ReadFromJsonAsync<DataDocument>(response);

        }

		public async Task<DataDocument> DoCustom(string endpoint, DataDocument document, string dtoid)
		{
			var url = $"{endpoint}?dtoid={dtoid}";
			var client = GetClient();
			var response = await client.PutAsJsonAsync<DataDocument>(url, document);
			return await ReadFromJsonAsync<DataDocument>(response);
		}

		public async Task<DataDocument> Validate(string endpoint, DataDocument document)
        {
            var url = $"{endpoint}";
            var client = GetClient();
            var response = await client.PutAsJsonAsync<DataDocument>(url, document);
            return await ReadFromJsonAsync<DataDocument>(response);
        }

        public async Task<DataDocument> SetValue(string endpoint, DataDocument document, string dtoid, string propertyname, string? value)
        {
            var url = $"{endpoint}?dtoid={dtoid}&propertyname={propertyname}&value={value}";
            var client = GetClient();
            var response = await client.PutAsJsonAsync<DataDocument>(url, document);
            return await ReadFromJsonAsync<DataDocument>(response);
        }

		#endregion

		#region Models
		public async Task<MainAssemblyModelDto> GetAssemblyModel(string endpoint, DataDocument document)
        {
            var url = $"{endpoint}/GetDataModel";
            var client = GetClient();
            var response = await client.PutAsJsonAsync<DataDocument>(url, document);
            return await ReadFromJsonAsync<MainAssemblyModelDto>(response);
        }

        public async Task<ToolModelDto> GetToolModel(string endpoint, DataDocument document)
        {
            var url = $"{endpoint}/GetToolModel?toolIndex=0";
            var client = GetClient();
            var response = await client.PutAsJsonAsync<DataDocument>(url, document);
            return await ReadFromJsonAsync<ToolModelDto>(response);
        }

        public async Task<ProfileProgramModelDto> GetProfileProgramModel(string endpoint, string programId)
        {
            var url = $"{endpoint}/GetProgramModelById?programId={programId}";
            var client = GetClient();
            var response = await client.GetAsync(url);
            return await ReadFromJsonAsync<ProfileProgramModelDto>(response);
        }

        public async Task<ProfileProgramModelDto> GetProfileProgramModel(string endpoint, DataDocument document)
        {
            var url = $"{endpoint}/GetProgramModel";
            var client = GetClient();
            var response = await client.PutAsJsonAsync<DataDocument>(url, document);
            return await ReadFromJsonAsync<ProfileProgramModelDto>(response);
        }

        public async Task<DowelProgramModelDto> GetDowelProgramModel(string endpoint, DataDocument document)
        {
            var url = $"{endpoint}/GetProgramModel";
            var client = GetClient();
            var response = await client.PutAsJsonAsync<DataDocument>(url, document);
            return await ReadFromJsonAsync<DowelProgramModelDto>(response);
        }

        public async Task<RabbetSwitchEditorProgramModelDto> GetRabbbetSwitchProgramModel(string endpoint, DataDocument document)
        {
            var url = $"{endpoint}/GetProgramModel";
            var client = GetClient();
            var response = await client.PutAsJsonAsync<DataDocument>(url, document);
            return await ReadFromJsonAsync<RabbetSwitchEditorProgramModelDto>(response);
        }

        public async Task<Drawing2DDto> GetModel2D(string endpoint, DataDocument document)
        {
            var url = $"{endpoint}/GetModel2D";
            var client = GetClient();
            var response = await client.PutAsJsonAsync<DataDocument>(url, document);
            return await ReadFromJsonAsync<Drawing2DDto>(response);
        }

        public async Task<Drawing2DDto> GetCrossSection(string endpoint, DataDocument document, string partId)
        {
            var url = $"{endpoint}/GetCrossSection?partId={partId}";
            var client = GetClient();
            var response = await client.PutAsJsonAsync<DataDocument>(url, document);
            return await ReadFromJsonAsync<Drawing2DDto>(response);
        }

        public async Task<Drawing2DDto> GetFrontViewDrawing(string endpoint, MainAssemblyModelDto model)
        {
            var url = $"{endpoint}/GetFrontView";
            var client = GetClient();
            var response = await client.PutAsJsonAsync<MainAssemblyModelDto>(url, model);
            return await ReadFromJsonAsync<Drawing2DDto>(response);
        }

        public async Task<Drawing2DDto> GetSectionViewDrawing(string endpoint, MainAssemblyModelDto model, int sectionId)
        {
            var url = $"{endpoint}/GetSectionView?sectionId={sectionId}";
            var client = GetClient();
            var response = await client.PutAsJsonAsync<MainAssemblyModelDto>(url, model);
            return await ReadFromJsonAsync<Drawing2DDto>(response);
        }

        public async Task<HeaderedDescription> GetFrameDescription(string endpoint, MainAssemblyModelDto model)
        {
            var url = $"{endpoint}/GetFrameDescription";
            var client = GetClient();
            var response = await client.PutAsJsonAsync<MainAssemblyModelDto>(url, model);
            return await ReadFromJsonAsync<HeaderedDescription>(response);
        }


        public async Task<string> ConvertDrawingToDxf(string endpoint, Drawing2DDto drawing)
        {
            var url = $"{endpoint}/ConvertDrawingToDxf";
            var client = GetClient();
            var response = await client.PutAsJsonAsync<Drawing2DDto>(url, drawing);
            return await ReadFromJsonAsync<string>(response);
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
            var client = GetClient();
            var response = await client.PutAsJsonAsync<DataDocument>(url, document);
            return await ReadFromJsonAsync<BomModelDto>(response);
        }

        public async Task<DataDocument> PublishToErp(string endpoint, DataDocument document, string dtoid)
        {
            var url = $"{endpoint}?dtoid={dtoid}";
            var client = GetClient();
            var response = await client.PutAsJsonAsync<DataDocument>(url, document);
            return await ReadFromJsonAsync<DataDocument>(response);
        }


        public async Task<bool> InitializeErp(string endpoint)
        {
                var url = $"{endpoint}";
                var client = GetClient();
                var response = await client.GetAsync(url);
                return await ReadFromJsonAsync<bool>(response);
        }

        public async Task<bool> SyncWithErp(string endpoint)
        {
                var url = $"{endpoint}";
                var client = GetClient();
                var response = await client.GetAsync(url);
                return await ReadFromJsonAsync<bool>(response);
        }

        public async Task<bool> PublishPurchaseOrder(string endpoint)
        {
            var url = $"{endpoint}";
            var client = GetClient();
            var response = await client.GetAsync(url);
            return await ReadFromJsonAsync<bool>(response);
        }

        public async Task<IEnumerable<DataDocument>> ImportBmhToolHolders(string endpoint, CustomActionArgument customarg)
        {
            var client = GetClient();
            var response = await client.PutAsJsonAsync<CustomActionArgument>(endpoint, customarg);
            return await ReadFromJsonAsync<IEnumerable<DataDocument>>(response);
        }

        public async Task<IEnumerable<DataDocument>> ImportBmhFactory(string endpoint, CustomActionArgument customarg)
        {
            var client = GetClient();
            var response = await client.PutAsJsonAsync<CustomActionArgument>(endpoint, customarg);
            return await ReadFromJsonAsync<IEnumerable<DataDocument>>(response);
        }

        public async Task<string> GetBmhProductionOrder(string endpoint, DataDocument document, string dtoid)
        {
            var url = $"{endpoint}?dtoid={dtoid}";
            var client = GetClient();
            var response = await client.PutAsJsonAsync<DataDocument>(url, document);
            return await ReadAsStringAsync(response);
        }

        public async Task<WorkbookDto> GetWorkbook(string endpoint, DataDocument document, string dtoid)
        {
            var url = $"{endpoint}?dtoid={dtoid}";
            var client = GetClient();
            var response = await client.PutAsJsonAsync<DataDocument>(url, document);
            return await ReadFromJsonAsync<WorkbookDto>(response);
        }

        public async Task<string> GetDxfDrawing(string endpoint, DataDocument document, string dtoid)
        {
            var url = $"{endpoint}?dtoid={dtoid}";
            var client = GetClient();
            var response = await client.PutAsJsonAsync<DataDocument>(url, document);
            return await ReadFromJsonAsync<string>(response);
        }

		#endregion

		#region Production

		public async Task<IEnumerable<ProductionFrameDto>> GetProductionFrames(string endpoint, string manufacturingOrderId)
        {
            var url = $"{endpoint}?manufacturingOrderId={manufacturingOrderId}";
            var client = GetClient();
            var response = await client.GetAsync(url);
            return await ReadFromJsonAsync<IEnumerable<ProductionFrameDto>>(response);
        }

        public async Task<ProductionPartModelDto> GetProductionPartModel(string endpoint, string productionPartId, string routeStationId)
        {
            var url = $"{endpoint}?productionPartId={productionPartId}&routeStationId={routeStationId}";
            var client = GetClient();
            var response = await client.GetAsync(url);
            return await ReadFromJsonAsync<ProductionPartModelDto>(response);
        }

        public async Task<MainAssemblyModelDto> GetProductionFrameModel(string endpoint, string productionFrameId, string routeStationId)
        {
            var url = $"{endpoint}?productionFrameId={productionFrameId}&routeStationId={routeStationId}";
            var client = GetClient();
            var response = await client.GetAsync(url);
            return await ReadFromJsonAsync<MainAssemblyModelDto>(response);
        }

        public async Task<HeaderedDescription> GetProductionFrameDescription(string endpoint, string productionFrameId)
        {
            var url = $"{endpoint}?productionFrameId={productionFrameId}";
            var client = GetClient();
            var response = await client.GetAsync(url);
            return await ReadFromJsonAsync<HeaderedDescription>(response);
        }

      
        #endregion 

        #region Drawings

        public async Task<byte[]> ConvertWorkbookToDxf(WorkbookDto workbook)
        {
            var url = $"/Drawing/ConvertWorkbookToDxf";
            var client = GetClient();
            var response = await client.PutAsJsonAsync<WorkbookDto>(url, workbook);
            return await ReadAsByteArrayAsync(response);
        }


        public async Task<byte[]> ConvertWorkbookToPdf(WorkbookDto workbook)
        {
            var url = $"/Drawing/ConvertWorkbookToPdf";
            var client = GetClient();
            var response = await client.PutAsJsonAsync<WorkbookDto>(url,workbook);
            return await ReadAsByteArrayAsync(response);
        }

        public async Task<byte[]> ConvertWorkbookToSvg(WorkbookDto workbook)
        {
            var url = $"/Drawing/ConvertWorkbookToSvg";
            var client = GetClient();
            var response = await client.PutAsJsonAsync<WorkbookDto>(url, workbook);
            return await ReadAsByteArrayAsync(response);
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
			var client = GetClient();
			var response = await client.PutAsJsonAsync<DataDocument>(url, document);
			return await ReadFromJsonAsync<WebFrameModelDto>(response);
		}

		#endregion



		#endregion


	}
}

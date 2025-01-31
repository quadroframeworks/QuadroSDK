using Quadro.Documents.Filtering;
using Quadro.DataModel.Authorization;
using Quadro.DataModel.Bom;
using Quadro.DataModel.Drawing;
using Quadro.DataModel.Geometrics;
using Quadro.DataModel.Model;
using Quadro.DataModel.Model.Tools;
using Quadro.DataModel.Production;
using Quadro.ToolSet;
using Quadro.DataModel.Entities.Web;
using Quadro.DataModel.Entities.Projects;
using Quadro.DataModel.Model.Programs;
using Quadro.Documents;

namespace Quadro.Api
{
	public interface IApiService
    {
        //Documents
        Task<IEnumerable<SchemaInfo>> GetSchemaInfos();
        Task<DataTypeSchema> GetSchema(string endpoint);
        Task<IEnumerable<DataDocument>> GetItems(DataTypeSchema schema, RoughFilterType roughFilterType, string? filterString);
        Task<IEnumerable<DataDocument>> GetVariants(DataTypeSchema schema, DataDocument document);
        Task<IEnumerable<SelectableValue>> GetSelectableValues(string endpoint, DataDocument document, string dtoid, string propertyname);
		Task<FilterTree> GetFilterTree(string endpoint);
		Task<DataDocument> Create(string endpoint);
        Task<DataDocument> CreateAndAdd(string endpoint, DataDocument document, string dtoid);
        Task<DataDocument> CreateCopy(string endpoint, DataDocument document);
        Task<DataDocument> CreateVariant(string endpoint, DataDocument document);
        Task<DataDocument> Read(string endpoint, string id);
        Task<DataDocument> Update(string endpoint, DataDocument document);
        Task<DataDocument> Delete(string endpoint, DataDocument document, string dtoid);
		Task<DataDocument> DoCustom(string endpoint);
		Task<DataDocument> DoCustom(string endpoint, DataDocument document);
		Task<DataDocument> DoCustom(string endpoint, DataDocument document, string dtoid);
		Task<DataDocument> DoCustom(string endpoint, CustomActionArgument customarg);
        Task<DataDocument> Validate(string endpoint, DataDocument document);
        Task<DataDocument> SetValue(string endpoint, DataDocument document, string dtoid, string propertyname, string? value);
        Task<Drawing2DDto> GetModel2D(string endpoint, DataDocument document);
        Task<Drawing2DDto> GetCrossSection(string endpoint, DataDocument document, string partId);

        //Drawings
        Task<Drawing2DDto> GetFrontViewDrawing(string endpoint, MainAssemblyModelDto model);
        Task<Drawing2DDto> GetSectionViewDrawing(string endpoint, MainAssemblyModelDto model, int sectionId);
		Task<string> GetFrontViewDrawingSvg(string endpoint, MainAssemblyModelDto model);
		Task<string> GetSectionViewDrawingSvg(string endpoint, MainAssemblyModelDto model, int sectionId);
		Task<HeaderedDescription> GetFrameDescription(string endpoint, MainAssemblyModelDto model);
        Task<string> ConvertDrawingToDxf(string endpoint, Drawing2DDto drawing);
        
        //Models
        Task<MainAssemblyModelDto> GetAssemblyModel(string endpoint, DataDocument document);
        Task<OrderLineBomModelDto> GetOrderLineBomModel(string bomId);
        Task<ToolModelDto> GetToolModel(string endpoint, DataDocument document);
        Task<ProfileProgramModelDto> GetProfileProgramModel(string endpoint, DataDocument document);
        Task<ProfileProgramModelDto> GetProfileProgramModel(string endpoint, string programId);
        Task<DowelProgramModelDto> GetDowelProgramModel(string endpoint, DataDocument document);
        Task<RabbetSwitchEditorProgramModelDto> GetRabbbetSwitchProgramModel(string endpoint, DataDocument document);
       
        //Erp
        Task<DataDocument> PublishToErp(string endpoint, DataDocument document, string dtoid);
        Task<bool> PublishPurchaseOrder(string endpoint);
        Task<bool> SyncWithErp(string endpoint);

        //Specifics
        Task<BomModelDto> GetBom(string endpoint, DataDocument document);
        Task<IEnumerable<DataDocument>> ImportBmhToolHolders(string endpoint, CustomActionArgument customarg);
        Task<IEnumerable<DataDocument>> ImportBmhFactory(string endpoint, CustomActionArgument customarg);
        Task<string> GetBmhProductionOrder(string endpoint, DataDocument document, string dtoid);
        Task<WorkbookDto> GetWorkbook(string endpoint, DataDocument document, string dtoid);
        Task<string> GetDxfDrawing(string endpoint, DataDocument document, string dtoid);

		//Auth
		Task<UserAccountInfo> CreateUserAccount(NewUserAccountInfo accountInfo);
		Task<UserSignInResult> SignIn(string email, string password);
		Task<UserSignOutResult> SignOut();
        Task<UserRoleInfo> GetUserRoleInfo();

		//Auth users
		Task<UserAccountInfo> UpdateUserAccount(UserAccountInfo accountInfo);
		Task<DeleteUserAccountResult> DeleteUserAccount(string email);
		Task<ChangePasswordResult> ResetPassword(string oldpassword, string newpassword);

		//Auth business
		Task<NewBusinessAccountResult> CreateBusinessAccount(BusinessAccountInfo accountInfo);
        Task<BusinessAccountInfo> ReadBusinessAccountInfo();
        Task<BusinessAccountInfo> UpdateBusinessAccountInfo(BusinessAccountInfo accountInfo);
        Task<DeleteBusinessAccountResult> DeleteBusinessAccount();

        //Production
        Task<IEnumerable<ProductionFrameDto>> GetProductionFrames(string endpoint, string manufacturingorderId);
        Task<ProductionPartModelDto> GetProductionPartModel(string endpoint, string productionPartId, string routeStationId);
        Task<MainAssemblyModelDto> GetProductionFrameModel(string endpoint, string productionFrameId, string routeStationId);
        Task<HeaderedDescription> GetProductionFrameDescription(string endpoint, string productionFrameId);

        //Drawings
        Task<byte[]> ConvertWorkbookToDxf(WorkbookDto workbook);
        Task<byte[]> ConvertWorkbookToSvg(WorkbookDto workbook);
        Task<byte[]> ConvertWorkbookToPdf(WorkbookDto workbook);

		//Web
		Task<WebFrameModelDto> GetWebFrontViewSvg(string endpoint, DataDocument document);
	}
}

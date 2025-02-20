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
using Quadro.ToolSet;

namespace Quadro.Api
{
    public interface IApiService
    {

        IAuthService Auth { get; }
        IUnitOfWorkService UnitOfWork { get; }


        //Drawings
        Task<Drawing2DDto> GetFrontViewDrawing(string endpoint, MainAssemblyModelDto model);
        Task<Drawing2DDto> GetSectionViewDrawing(string endpoint, MainAssemblyModelDto model, int sectionId);
		Task<string> GetFrontViewDrawingSvg(string endpoint, MainAssemblyModelDto model);
		Task<string> GetSectionViewDrawingSvg(string endpoint, MainAssemblyModelDto model, int sectionId);
		Task<HeaderedDescription> GetFrameDescription(string endpoint, MainAssemblyModelDto model);
        Task<string> ConvertDrawingToDxf(string endpoint, Drawing2DDto drawing);

        //Models
        Task<Drawing2DDto> GetModel2D(string endpoint, DataDocument document);
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

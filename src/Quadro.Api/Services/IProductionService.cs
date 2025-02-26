using Quadro.DataModel.Drawing;
using Quadro.DataModel.Entities.Projects;
using Quadro.DataModel.Model;
using Quadro.DataModel.Production;
using Quadro.ToolSet;

namespace Quadro.Api.Services
{
    public interface IProductionService
    {

        Task<OrderLineBomModelDto> GetOrderLineBomModel(string bomId);
        Task<string> GetBmhProductionOrder(string projectId, string manufacturingOrderId);
        Task<WorkbookDto> GetWorkBook(string projectId, string manufacturingOrderId);


        Task<IEnumerable<ProductionFrameDto>> GetProductionFrames(string manufacturingorderId);
        Task<ProductionPartModelDto> GetProductionPartModel(string productionPartId, string routeStationId);
        Task<MainAssemblyModelDto> GetProductionFrameModel(string productionFrameId, string routeStationId);
        Task<HeaderedDescription> GetProductionFrameDescription(string productionFrameId);
    }
}

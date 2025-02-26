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

namespace Quadro.Api.Services
{
    public interface IApiService
    {

        IAuthService Auth { get; }
        IUnitOfWorkService UnitOfWork { get; }
        IModellingService Modelling { get; }
        IDrawingService Drawing { get; }
        IProductionService Production { get; }

    }
}

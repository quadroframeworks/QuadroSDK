using Quadro.DataModel.Bom;
using Quadro.DataModel.Entities.Web;
using Quadro.DataModel.Geometrics;
using Quadro.DataModel.Model;
using Quadro.DataModel.Model.Programs;
using Quadro.DataModel.Model.Tools;
using Quadro.Documents.UnitOfWork;

namespace Quadro.Api.Services
{
    public interface IModellingService
    {

        //Models
        Task<MainAssemblyModelDto> GetAssemblyModel(string baseUri, UnitOfWork uow, string dtoId);
        Task<WebFrameModelDto> GetWebFrontViewSvg(UnitOfWork uow, string dtoId);
        Task<BomModelDto> GetBom(string baseUri, UnitOfWork uow, string dtoId);

        //2D Drawings
        Task<Drawing2DDto> GetModel2D(string baseUri, UnitOfWork uow, string dtoId);
        Task<Drawing2DDto> GetModel2D(string baseUri, string entityId);

        //Tools
        Task<ToolModelDto> GetToolModel(UnitOfWork uow, string dtoId);
        Task<ToolModelDto> GetToolModel(string toolId);

        //Profiling programs
        Task<ProfileProgramModelDto> GetProfileProgramModel(UnitOfWork uow, string dtoId);
        Task<ProfileProgramModelDto> GetProfileProgramModel(string programId);

        //Dowel programs
        Task<DowelProgramModelDto> GetDowelProgramModel(UnitOfWork uow, string dtoId);
        Task<DowelProgramModelDto> GetDowelProgramModel(string programId);

        //Rabbet switch programs
        Task<RabbetSwitchEditorProgramModelDto> GetRabbetSwitchProgramModel(UnitOfWork uow, string dtoId);
        Task<RabbetSwitchEditorProgramModelDto> GetRabbetSwitchProgramModel(string programId);
    }
}

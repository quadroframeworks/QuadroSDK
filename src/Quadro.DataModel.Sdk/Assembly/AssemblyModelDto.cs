using Quadro.DataModel.Geometrics;
using Quadro.DataModel.Model.FrameCertificates;
using Quadro.Interface.Assemblies;
using Quadro.Interface.Enums;
using Quadro.Utils.Storage;

namespace Quadro.DataModel.Model
{
	public abstract class AssemblyModelDto:StorableGuid
    {
        public string? Name { get; set; }
        public string AssemblyDescriptionId { get; set; } = string.Empty;
        public AssemblyType AssemblyType { get; set; }
        public AssemblyContentType ContentType { get; set; }
        public List<FrameModelDto> SubFrames { get; set; } = new List<FrameModelDto>();
        public List<HingeAndLockSetModelDto> HingeAndLockSets { get; set; } = new List<HingeAndLockSetModelDto>();
        public List<GlassModelDto> GlassModels { get; set; } = new List<GlassModelDto>();
        public List<PlateModelDto> PlateModels { get; set; } = new List<PlateModelDto>();
        public List<FrameOperationSetModelDto> FrameOperationSets { get; set; } = new List<FrameOperationSetModelDto>();
        public List<FillingAssemblyModelDto> Fillings { get; set; } = new List<FillingAssemblyModelDto>();
        public Matrix3DDto AssemblyTransform { get; set; } = new Matrix3DDto();
    }


    public class MainAssemblyModelDto: AssemblyModelDto
    {
        public string? Tag { get; set; }
        public string? UserName { get; set; }
        public BorderAssemblyModelDto? Border { get; set; }
        public List<FrameWorkAssemblyModelDto> SubFrameWorks { get; set; } = new List<FrameWorkAssemblyModelDto>();
        public static MainAssemblyModelDto Empty => new MainAssemblyModelDto();
        public List<SectionDto> Sections { get; set; } = new List<SectionDto>();
        public List<FrameCertificateDto> Certificates { get; set; } = new List<FrameCertificateDto>();
        public List<FrameMessageDto> Messages { get; set; } = new List<FrameMessageDto>();
    }

    public class  FillingAssemblyModelDto:AssemblyModelDto
    {
        public FillingSide FillingSide { get; set; }
        public FillingTurnConfiguration TurnConfiguration { get; set; }
        public VentGrillModelDto? VentGrill { get; set; }
    }

    public class BorderAssemblyModelDto: AssemblyModelDto
    {

    }

    public class FrameWorkAssemblyModelDto: AssemblyModelDto
    {

    }
}

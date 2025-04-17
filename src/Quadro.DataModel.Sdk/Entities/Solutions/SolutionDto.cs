using Quadro.Documents.Attributes;
using Quadro.Globalization.Attributes;
using Quadro.Interface.Projects;
using System.Text.Json.Serialization;
using Quadro.Interface.Assemblies;
using Quadro.Interface.Solutions;
using Quadro.Interface.RawFrames;
using Quadro.Utils.Storage;
using Quadro.DataModel.CustomProperties;
using Quadro.DataModel.Entities.FrameCertificates;
using Quadro.DataModel.Entities.Web;
using Quadro.DataModel.Entities.Assemblies;

namespace Quadro.DataModel.Entities.Solutions
{

	public class TemplateSolutionDto : SolutionDto //Referenced by templates
	{
		[Header("Web released", Globalization.Language.en)]
		[Header("Web vrijgegeven", Globalization.Language.nl)]
		[Category("Web", Globalization.Language.en)]
		[Category("Web", Globalization.Language.nl)]
		[ColumnVisible(true)]
		public bool IsWebReleased { get; set; }

		[Header("Allow special sill", Globalization.Language.en)]
		[Header("Onderdorpel toestaan", Globalization.Language.nl)]
		[Category("Web", Globalization.Language.en)]
		[Category("Web", Globalization.Language.nl)]
		[ColumnVisible(false)]
		public bool AllowSpecialSill { get; set; }

		[Header("Allow border", Globalization.Language.en)]
		[Header("Spouwlatten toestaan", Globalization.Language.nl)]
		[Category("Web", Globalization.Language.en)]
		[Category("Web", Globalization.Language.nl)]
		[ColumnVisible(false)]
		public bool AllowBorder { get; set; }

        [ColumnVisible(false)]
        public string? ThumbnailId { get; set; }

        [Header("Decorations", Globalization.Language.en)]
        [Header("Decoraties", Globalization.Language.nl)]
        [Category("Web", Globalization.Language.en)]
        [Category("Web", Globalization.Language.nl)]
        public List<PossibleDecoration> Decorations { get; set; } = new List<PossibleDecoration>();
	}

    public class PossibleDecoration:StorableGuid
    {
        public string? DecorationGroupId { get; set; }
        public bool IsDefault { get; set; }
    }

	public class OrderSolutionDto : SolutionDto, IProjectSpecific //Referenced by orders
	{
		[ColumnVisible(false)]
		public string? ProjectId { get; set; }

		[Header("Project name", Globalization.Language.en)]
		[Header("Projectnaam", Globalization.Language.nl)]
		[ColumnVisible(true)]
		public string? ProjectName { get; set; }

		public WebFrameDto WebFrame { get; set; } = new WebFrameDto();
	}

	public abstract class SolutionDto : Customizable, ISolutionEntity, IStorable
	{
		public SolutionDto() { }

		[Header("Name", Globalization.Language.en)]
		[Header("Naam", Globalization.Language.nl)]
		[ColumnVisible(true)]
		public string Name { get; set; } = string.Empty;

		[Header("Wire frame", Globalization.Language.en)]
		[Header("Draadmodel", Globalization.Language.nl)]
		[ColumnVisible(false)]
		public string WireFrameId { get; set; } = null!;

		[Header("Main assembly", Globalization.Language.en)]
		[Header("Basissamenstelling", Globalization.Language.nl)]
		[ColumnVisible(false)]
		public string MainAssemblyId { get; set; } = null!;

        [Header("Border group", Globalization.Language.en)]
        [Header("Spouwlatten groep", Globalization.Language.nl)]
        [Category("Border", Globalization.Language.en)]
        [Category("Spouwlatten", Globalization.Language.nl)]
        [ColumnVisible(false)]
        public string? BorderAssemblyGroupId { get; set; }

        [Header("Border application", Globalization.Language.en)]
		[Header("Spouwlatten toepassing", Globalization.Language.nl)]
        [Category("Border", Globalization.Language.en)]
        [Category("Spouwlatten", Globalization.Language.nl)]
        [ColumnVisible(false)]
		public string? BorderApplicationId { get; set; }

        [Header("Border assembly", Globalization.Language.en)]
		[Header("Spouwlatten sam.", Globalization.Language.nl)]
        [Category("Border", Globalization.Language.en)]
        [Category("Spouwlatten", Globalization.Language.nl)]
        [ColumnVisible(false)]
		public string? BorderAssemblyId { get; set; }

        [Header("Border option", Globalization.Language.en)]
        [Header("Spouwlatten optie", Globalization.Language.nl)]
        [Category("Border", Globalization.Language.en)]
        [Category("Spouwlatten", Globalization.Language.nl)]
        [ColumnVisible(false)]
        public string? BorderOptionId { get; set; }

        [Header("Border rabbets", Globalization.Language.en)]
		[Header("Spouwsponning", Globalization.Language.nl)]
        [Category("Border", Globalization.Language.en)]
        [Category("Spouwlatten", Globalization.Language.nl)]
        [ColumnVisible(false)]
		public string? BorderRabbetSystemId { get; set; }

		[Header("Sill", Globalization.Language.en)]
		[Header("Onderdorpel", Globalization.Language.nl)]
		[ColumnVisible(false)]
		public string? SillId { get; set; }

		[Header("Raw material", Globalization.Language.en)]
		[Header("Ruw materiaal", Globalization.Language.nl)]
		[Category("Style", Globalization.Language.en)]
		[Category("Opmaak", Globalization.Language.nl)]
		[ColumnVisible(false)]
		public string? RawMaterialId { get; set; }

		[Header("Coating", Globalization.Language.en)]
		[Header("Coating", Globalization.Language.nl)]
		[Category("Style", Globalization.Language.en)]
		[Category("Opmaak", Globalization.Language.nl)]
		[ColumnVisible(false)]
		public string? PaintSystemId { get; set; }

		[Header("Color", Globalization.Language.en)]
		[Header("Kleur", Globalization.Language.nl)]
		[Category("Style", Globalization.Language.en)]
		[Category("Opmaak", Globalization.Language.nl)]
		[ColumnVisible(false)]
		public string? ColorId { get; set; }

		[Header("Status", Globalization.Language.en)]
		[Header("Status", Globalization.Language.nl)]
		[ColumnVisible(true)]
		public FrameSolutionStatus Status { get; set; }

		[JsonIgnore]
		public IEnumerable<IPartConfiguration> PartConfigurations => partConfigurations;
		[Header("Part configurations", Globalization.Language.en)]
		[Header("Onderdeelinstellingen", Globalization.Language.nl)]
		[DisplayIndex(100)]
		public List<PartConfigurationDto> partConfigurations { get; set; } = new List<PartConfigurationDto>();

		[JsonIgnore]
		public IEnumerable<IAdditionalPart> AdditionalParts => additionalParts;
		[Header("Additional parts", Globalization.Language.en)]
		[Header("Extra onderdelen", Globalization.Language.nl)]
		[DisplayIndex(101)]
		public List<AdditionalPartDto> additionalParts { get; set; } = new List<AdditionalPartDto>();

		[JsonIgnore]
		public IEnumerable<IOperationSetPlacement> OperationSets => operationSets;
		[Header("Operation sets", Globalization.Language.en)]
		[Header("Bewerkingen", Globalization.Language.nl)]
		[DisplayIndex(102)]
		public List<FrameOperationSetPlacement> operationSets { get; set; } = new List<FrameOperationSetPlacement>();

		[JsonIgnore]
		public IEnumerable<ICertificateTest> CertificateTests => certificateTests;

		[Header("Certificates", Globalization.Language.en)]
		[Header("Certificaten", Globalization.Language.nl)]
		[DisplayIndex(103)]
		public List<CertificateTest> certificateTests { get; set; } = new List<CertificateTest>();

		[JsonIgnore]
		public IEnumerable<ISolutionFilling> Fillings => fillings;
		[Header("Fillings", Globalization.Language.en)]
		[Header("Vullingen", Globalization.Language.nl)]
		[DisplayIndex(104)]
		public List<SolutionFillingDto> fillings { get; set; } = new List<SolutionFillingDto>();

        [JsonIgnore]
        public IEnumerable<ISubFrameWork> SubFrameWorks => subFrameWorks;
        [Header("Sub frame works", Globalization.Language.en)]
        [Header("Rekwerken", Globalization.Language.nl)]
        [DisplayIndex(105)]
        public List<SubFrameWorkDto> subFrameWorks { get; set; } = new List<SubFrameWorkDto>();
    }



}

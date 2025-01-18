using Quadro.Interface.Production;
using Quadro.Utils.Storage;
using System.Text.Json.Serialization;

namespace Quadro.DataModel.Production
{
	public class StationDto : StorableGuid, IStationEntity
    {
        public int Order { get; set; }
        public string Name { get; set; } = string.Empty;
        public StationType Type { get; set; }
        public string? WorkCenterId { get; set; }
        public ZeroCorner DefaultZeroCorner { get; set; }
        public double MinLength { get; set; }
        public double MinWidth { get; set; }
        public double MinHeight { get; set; }
        public double MaxLength { get; set; }
        public double MaxWidth { get; set; }
        public double MaxHeight { get; set; }
        public string ProtocolName { get; set; } = string.Empty;

        [JsonIgnore]
        public IEnumerable<IMacroDescription> Macros => macros;
        public List<MacroDto> macros { get; set; } = new List<MacroDto>();

        [JsonIgnore]
        public IEnumerable<IStationParameterDescription> Parameters => parameters;
        public List<StationParameterDto> parameters { get; set; } = new List<StationParameterDto>();

    }

    public class MacroDto : StorableGuid, IMacroDescription
    {
        public string Name { get; set; } = string.Empty;
        public MacroType MacroType { get; set; }
        public MacroShapeType Shape { get; set; }
    }

    public class StationParameterDto : StorableGuid, IStationParameterDescription
    {
        public StationParameterType Type { get; set; }
        public double Value { get; set; }
        public bool ValueBool { get; set; }
        public string? ValueString { get; set; }
    }
}

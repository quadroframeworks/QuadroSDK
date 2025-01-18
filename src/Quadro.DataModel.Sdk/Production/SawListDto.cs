using Quadro.Interface.Context;
using Quadro.Interface.Enums;
using Quadro.DataModel.Geometrics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quadro.Interface.Sills;
using Quadro.Interface.RawFrames;

namespace Quadro.DataModel.Production
{
	public class SawListDto
    {
        public string ManufacturingOrderId { get; set; } = null!;
        public List<SawListGroupDto> Groups { get; set; } = new List<SawListGroupDto>();
    }

    public class SawListGroupDto
    {
        public FrameContextType ContextType { get; set; }
        public List<SawListPartDto> Parts { get; set; } = new List<SawListPartDto>();
    }

    public class SawListPartDto
    {
        public string CatalogItemName { get; set; } = null!;
        public FramePartType PartType { get; set; }
        public SillPartType SillPartType { get; set; }
        public string FrameTag { get; set; } = null!;
        public int BatchNumber { get; set; }
        public int PartIndex { get; set; }
        public double RawWidth { get; set; }
        public double RawHeight { get; set; }
        public double RawLength { get; set; }
        public double PlanerWidth { get; set; }
        public double PlanerHeight { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public double Length { get; set; }
        public string? RawMaterial { get; set; }
        public string Barcode { get; set; } = null!;
        public SawListProfileType ProfileType { get; set; }
        public List<SawListPartProfileDto> Profiles { get; set; } = new List<SawListPartProfileDto>();

    }

    public class SawListPartProfileDto
    {
        public string? ProfileRightOrFull { get; set; }
        public string? ProfileLeft { get; set; }
        public Path2DDto Contour { get; set; } = null!;
    }
    
    public enum SawListProfileType
    {
        Full,
        TwoHalfes,
    }
}

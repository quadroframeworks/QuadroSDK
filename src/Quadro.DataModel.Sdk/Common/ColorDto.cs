using CPBase.Visual;
using Quadro.Interface.Colors;
using Quadro.Utils.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Quadro.DataModel.Common
{
	public class ColorDto : StorableGuid, IColorDescription
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public byte A { get; set; }
        public byte R { get; set; }
        public byte G { get; set; }
        public byte B { get; set; }

        public IColor ToUniversalColor() => new UniversalColor(Name) { A = this.A, R = this.R, G = this.G, B = this.B };
        public IBrush ToUniversalBrush() => new UniversalBrush(Name) { A = this.A, R = this.R, G = this.G, B = this.B };

        public static ColorDto FromColor(IColor color) =>
            new ColorDto() { Name = color.Name, A = color.A, R = color.R, G = color.G, B = color.B };

        public static ColorDto FromBrush(IBrush color) =>
            new ColorDto() { Name = color.Name, A = color.A, R = color.R, G = color.G, B = color.B };
    }
}

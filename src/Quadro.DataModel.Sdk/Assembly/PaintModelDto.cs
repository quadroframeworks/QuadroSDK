using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quadro.DataModel.Model
{
    public class PaintModelDto
    {
        public string? CatalogItemId { get; set; }
        public string? CatalogItemName { get;set; }
        public string Color { get; set; } = null!;
        public byte R { get; set; }
        public byte G { get; set; }
        public byte B { get; set; }
        public double LayerThickness { get; set; }
        public int NrOfLayers { get; set; }

    }
}

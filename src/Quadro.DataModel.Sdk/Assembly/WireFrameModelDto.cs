using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quadro.DataModel.Model
{
    public class WireFrameModelDto
    {
        public WireFrameModelDto() { }


        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string? WireFrameDescriptionId { get; set; } = String.Empty;
        public List<WireModelDto> Wires { get; set; } = new List<WireModelDto>();
        public List<WireJointModelDto> Joints { get; set; } = new List<WireJointModelDto>();
        

    }
}

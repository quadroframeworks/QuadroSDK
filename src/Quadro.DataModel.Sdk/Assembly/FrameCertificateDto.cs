using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quadro.DataModel.Model.FrameCertificates
{
    public class FrameCertificateDto
    {
        public FrameCertificateDto() { }

        public string? CertificateId { get; set; }
        public string Name { get; set; } = null!;
        public string? ImageId { get; set; }
        public bool Approved { get; set; }
        public List<FrameMessageDto> Messages { get; set; } = new List<FrameMessageDto>();
    }
}

using Quadro.Interface.Common;
using Quadro.Utils.Logging;

namespace Quadro.Interface.FrameCertificates
{
	public interface IFrameCertificate
    {
        string? CertificateId { get; set; }
        string Name { get; set; }
        string? ImageId { get; set; }
        public bool Approved { get; set; }
        public IList<LogMessage> Messages { get; }
    }
}

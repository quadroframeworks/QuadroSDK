using Quadro.Interface.Common;

namespace Quadro.Interface.FrameCertificates
{
	public interface IFrameCertificate
    {
        string? CertificateId { get; set; }
        string Name { get; set; }
        string? ImageId { get; set; }
        public bool Approved { get; set; }
        public IList<IFrameMessage> Messages { get; }
    }
}

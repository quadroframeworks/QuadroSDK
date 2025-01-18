namespace Quadro.Interface.FrameCertificates
{
	public interface IFrameCertificateEntity
    {
        public string Id { get; }
        public string Name { get; }
        public string Description { get; }
        public string? ImageId { get; }
        public string Script { get; }
        string? TestAssemblyId { get; set; }
    }
}

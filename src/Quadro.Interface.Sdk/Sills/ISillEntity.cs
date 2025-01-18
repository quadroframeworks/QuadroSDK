namespace Quadro.Interface.Sills
{
	public interface ISillEntity
    {
        public string Name { get; }
        public double SillHeight { get; }
        public double NutHeight { get; set; }
        public double RabbetDepth { get; set; }
        public double WireOffsetY { get; set; }
        public string? ColorId { get; set; }
        public bool IsWebReleased { get; }
        public IEnumerable<ISillPartDescription> Parts { get; }

    }

    public interface ISillPartDescription
    {
        public SillPartType SillPartType { get; set; }
        public double Height { get; set; }
        public double Width { get; set; }
        public string? CatalogItemId { get; set; }
        public string? SingleProfileId { get; set; }
        public string? HingeAndLockItemId { get; set; }
    }

    public enum SillPartType
    {
        None = 0,
        Sill = 1,
        NutLeft = 10,
        NutRight = 11,
        NutMid = 12,
        SillGlassBeading = 100,
        SillHingeAndLock = 200,
    }
}

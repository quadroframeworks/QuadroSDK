namespace Quadro.Interface.Assemblies
{
	public interface IBottomOffsetData
    {
        bool SetBySill { get; }
        double? ExtraOffset { get; }
        double? FixedOffset { get; }
        double? RabbetHeight { get; }
    }
}

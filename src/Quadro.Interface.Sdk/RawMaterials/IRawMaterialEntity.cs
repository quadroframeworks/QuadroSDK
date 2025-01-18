namespace Quadro.Interface.RawMaterials
{
	public interface IRawMaterialEntity
    {
        double Density { get; set; }
        string Name { get; set; }
        ProcessGrade ProcessGrade { get; set; }
        bool IsWebReleased { get; set; }
    }


    public enum ProcessGrade
    {
        Soft,
        Middle,
        Hard,
    }
}
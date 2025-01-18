using Quadro.DataModel.Geometrics;

namespace Quadro.DataModel.Model
{
	public class DowelModelDto
    {
        public string DescriptionId { get; set; } = null!;
        public string? Name { get; set; }
        public Matrix3DDto DowelToJointTransform { get; set; } = null!;
        public double Diameter { get; set; }
        public double Length { get; set; }
        public double ContraCover { get; set; }
        public double ContraOffset { get; set; }
        public double SideCover { get; set; }
        public double PlugTecWidth { get; set; }
        public bool IsPlugTec { get; set; }
    }
}   

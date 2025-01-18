namespace Quadro.DataModel.Model
{
    public class WireSegmentModelDto
    {
        public string? StartJointId { get; } //If null, starts at wire start
        public string? EndJointId { get; } //If null, ends at wire end
        public int IndexFromStart { get; }
    }
}

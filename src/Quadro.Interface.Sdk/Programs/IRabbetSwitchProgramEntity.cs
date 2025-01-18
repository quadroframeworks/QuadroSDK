namespace Quadro.Interface.Programs
{
	public interface IRabbetSwitchProgramEntity
    {
        public string Id { get; }
        public string Name { get; }
        public double TestWidth { get; }
        public bool TestFlipped { get; }
        public double ProfileHeight { get; }
        public string? ProfileIdExtLeft { get; }
        public string? ProfileIdExtRight { get; }
        public string? ProfileIdEndLeft { get; }
        public string? ProfileIdEndRight { get; }
        public string? AlternativeContraId { get; }
        public IEnumerable<IRabbetSwitchRunOffset> RunOffsetsLeft { get; }
        public IEnumerable<IRabbetSwitchRunOffset> RunOffsetsRight { get; }
        public IEnumerable<IRabbetSwitchOperation> OperationsExtended { get; }
        public IEnumerable<IRabbetSwitchOperation> OperationsEnd { get; }
    }

    public interface IRabbetSwitchProfiles
    {


    }

    public interface IRabbetSwitchRunOffset
    {
        bool Flipped { get; }
        int RunIndex { get; }
        double Offset { get; }
    }

}

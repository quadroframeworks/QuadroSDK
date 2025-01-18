namespace Quadro.Interface.Production
{
	public interface IStationEntity
    {
        string Id { get; }
        int Order { get; }
        string Name { get; }
        StationType Type { get; }
        string? WorkCenterId { get; }
        ZeroCorner DefaultZeroCorner { get; }
        double MinLength { get; }
        double MinWidth { get; }
        double MinHeight { get; }
        double MaxLength { get; }
        double MaxWidth { get; }
        double MaxHeight { get; }
        string ProtocolName { get; }
        IEnumerable<IMacroDescription> Macros { get; }
        IEnumerable<IStationParameterDescription> Parameters { get; }

    }

    public interface IStationParameterDescription
    {
        StationParameterType Type { get; }
        double Value { get; }
        bool ValueBool { get; }
        string? ValueString { get; }
    }

    public enum StationType
    {
        Trolleys = 1,
        Saw = 2,
        Planer = 3,
        Sorting = 4,
        Process = 5,
        Glueing = 6,
        Assemble = 7,
        Mounting = 8,
        Painting = 9,
        Storage = 9,
    }

    public enum StationParameterType
    {
        TrolleyNrPosHor,
        TrolleyNrPosVer,
        TrolleyWidthTotal,
        TrolleyByPartWidth,     //Bool
        Etc,
    }

    public enum ZeroCorner
    {
        StartRightBottom,
        EndRightBottom,
        EndLeftBottom,
        StartLeftBottom,
        StartRightTop,
        EndRightTop,
        EndLeftTop,
        StartLeftTop,
    }

}

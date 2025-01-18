namespace Quadro.Interface.Tools
{
	public interface IToolHolderEntity
    {
        double AggregateLength { get; set; }
        ShankSize HolderSize { get; set; }
        ShankType HolderType { get; set; }
        bool IsAggregate { get; set; }
        int Magazine { get; set; }
        string Name { get; set; }
        int Position { get; set; }
        double StartUpTime { get; set; }
        IEnumerable<IToolDescription> Tools { get; }
    }

    public enum ShankType
    {
        Unknown,
        Thread,
        ER,
        HSK_E,
        HSK_F,
    }

    public enum ShankSize
    {
        Unknown,
        Size_8,
        Size_11,
        Size_16,
        Size_25,
        Size_32,
        Size_40,
        Size_50,
        Size_63,
        Size_80,
    }
}
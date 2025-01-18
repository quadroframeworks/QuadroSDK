using Quadro.Base.Catalog;

namespace Quadro.Interface.Catalog
{
	public interface ICatalogItemDescription
    {
        string Id { get; }
        string Name { get; }
        string Description { get; }
        CatalogItemType Type { get; }
        StockType StockType { get; }
        Unit Unit { get; }
        double UnitCost { get; }
        double WastePercentage { get; }
        string? Color { get; }
        string? ERPId { get; set; }
        IEnumerable<IWorkProcessTime> ProcessTimes { get; }

    }

    public interface IWorkProcessTime
    {
        double UnitProcessTime { get; set; } //Time in seconds
        string? WorkCenterId { get; set; }
        string? ERPId { get; set; }
    }

    public enum CatalogItemType
    {
        Undefined = 0,
        HalfProfiling = 1,              //General half profiling
        Contra = 2,                     //General contra
        Part = 100,                     //Directly linked by description
        ProfileStyle = 101,             //Directly linked by description
        HingeAndLock = 102,             //Directly linked by description
        HingeAndLockOperation = 103,    //Directly linked by description
        DowelApplication = 104,         //Directly linked by description
        Dowel = 105,                    //Directly linked by description
        FrameOperation = 106,           //Directly linked by description, viewmodels to do...
        JointOperation = 107,           //Directly linked by description, viewmodels to do...
        Glass = 108,                    //Directly linked by description
        Plate = 109,                    //Directly linked by description
        SingleProfile = 110,            //Directly linked by description
        VentilationGrill = 120,         //Directly linked by description
        Sill = 130,                     //Directly linked by description
        Order = 200,                    //Will be chosen for each order line
        Assembly = 201,                 //Directly linked by description
        Frame = 202,                    //No content yet, but acts as folder in bom
        RawMaterial = 1000,             //Will be chosen for each frame
        Paint = 1001,                   //Will be chosen for each frame
        Glue = 1002,                    //Directly linked by description
    }



    public enum StockType
    {
        PurchaseToStock,
        PurchaseToOrder,
        ProduceToStock,
        ProduceToOrder,
    }

}

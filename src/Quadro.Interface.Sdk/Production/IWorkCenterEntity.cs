namespace Quadro.Interface.Production
{
	public interface IWorkCenterEntity
    {
        string Id { get; }
        double CostPerHour { get; set; }
        double CostPerHourEmployee { get; set; }
        string Name { get; set; }
        int NrOfEmployees { get; set; }
        string? ERPId { get; set; }
    }
}
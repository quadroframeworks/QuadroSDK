namespace Quadro.DataModel.Authorization
{
    public class NewAccountResult
    {
        public bool IsValid { get; set; } = false;
        public string? UserEmail { get; set; }
        public string? UserName { get; set; }
        public string? CompanyName { get; set; }
    }
}

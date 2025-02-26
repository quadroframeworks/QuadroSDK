namespace Quadro.DataModel.Authorization
{
    public class NewBusinessAccountResult
    {
        public NewBusinessAccountResult() { }
        public bool IsValid { get; set; } = false;
        public string? UserEmail { get; set; }
        public string? CompanyName { get; set; }
    }
}

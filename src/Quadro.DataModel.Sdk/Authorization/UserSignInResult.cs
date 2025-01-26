using Quadro.Globalization;

namespace Quadro.DataModel.Authorization
{
	public class UserSignInResult
    {
        public bool Succes { get; set; } = false;
        public string? UserEmail { get; set; }
        public string? LastName { get; set; }
		public string? FirstName { get; set; }
		public string? CompanyName { get; set; }
        public string? Role { get; set; }
        public Language Language { get; set; }
        public string? Bearer { get; set; }


    }
}

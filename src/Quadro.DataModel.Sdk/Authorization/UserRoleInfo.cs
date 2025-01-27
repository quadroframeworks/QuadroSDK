using Quadro.Globalization;

namespace Quadro.DataModel.Authorization
{
	public class UserRoleInfo
	{
		public string? UserEmail { get; set; }
		public string? LastName { get; set; }
		public string? FirstName { get; set; }
		public string? CompanyName { get; set; }
		public string? Role { get; set; }
		public Language Language { get; set; }


	}
}

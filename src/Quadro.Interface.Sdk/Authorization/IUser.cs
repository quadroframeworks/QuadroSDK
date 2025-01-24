using Quadro.Globalization;

namespace Quadro.Interface.Authorization
{
	public interface IUser
    {
        string Id { get; }
        string CompanyId { get; set; }
		string? CustomerId { get; set; }
		string Name { get; set; }
        string Email { get; set; }
        string Password { get; set; }
        Language Language { get; set; }
        UserRole Role { get; set; }
    }

    public enum UserRole
    {
        WebUser = 0,
		EndCustomer = 10,
		CustomerUser = 20,
		CustomerAdministrator = 30,
		Administrator = 100,
    }
}

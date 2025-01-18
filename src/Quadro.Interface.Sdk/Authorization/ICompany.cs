namespace Quadro.Interface.Authorization
{
	public interface ICompany
    {
        string Address { get; set; }
        string City { get; set; }
        string CompanyName { get; set; }
        string Country { get; set; }
        string Email { get; set; }
        bool EnableERP { get; set; }
        string ERPUrl { get; set; }
        string ERPDatabaseName { get; set; }
        string ERPUserName { get; set; }
        string ERPPassword { get; set; }    
        string HomePage { get; set; }
        bool EnableManufacturing { get; set; }
        string ManufacturingUrl { get; set; }
        string Phone { get; set; }
        string PostalCode { get; set; }
        string Region { get; set; }
        string? LogoImageId { get; set; }
    }

}

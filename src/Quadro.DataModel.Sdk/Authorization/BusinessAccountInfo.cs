using Quadro.Interface.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quadro.DataModel.Authorization
{
    public class BusinessAccountInfo : ICompany
    {
        public string CompanyName { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string PostalCode { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Region { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string HomePage { get; set; } = string.Empty;
        public string ERPUrl { get; set; } = string.Empty;
        public string ERPDatabaseName { get; set; } = string.Empty;
        public string ERPUserName { get; set; } = string.Empty;
        public string ERPPassword { get; set; } = string.Empty;
        public bool EnableERP { get; set; }
        public string ManufacturingUrl { get; set; } = string.Empty;
        public bool EnableManufacturing { get; set; }
        public string? LogoImageId { get; set; }

    }

    public class NewBusinessAccountInfo: BusinessAccountInfo
    {
        public NewBusinessAccountInfo()
        {

        }

        public string UserEmail { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}

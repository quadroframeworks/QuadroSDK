

using Quadro.Globalization;
using Quadro.Interface.Authorization;

namespace Quadro.DataModel.Authorization
{
    public class LoginResult
    {
        public bool IsValid { get; set; } = false;
        public string? UserEmail { get; set; }
        public string? UserName { get; set; }
        public string? CompanyName { get; set; }
        public UserRole? Role { get; set; }
        public Language? Language { get; set; }
        public string? Bearer { get; set; }


    }
}

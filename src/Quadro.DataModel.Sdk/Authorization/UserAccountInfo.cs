using Quadro.Globalization;
using Quadro.Interface.Authorization;

namespace Quadro.DataModel.Authorization
{
    public class UserAccountInfo
    {
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public Language Language { get; set; }
        public UserRole Role { get; set; }
    }

    public class NewUserAccountInfo : UserAccountInfo
    {
        public string Password { get; set; } = null!;
    }
}

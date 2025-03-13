using Quadro.Globalization;

namespace Quadro.DataModel.Authorization
{
	public class UserSignInResult
    {
        public bool Succes { get; set; } = false;
        public string? UserEmail { get; set; }
        public string? Bearer { get; set; }
        public string? RefreshToken { get; set; }

    }
}

namespace Quadro.DataModel.Authorization
{
	public class UserAccountInfo
    {
        public string FirstName { get; set; } = null!;
		public string LastName { get; set; } = null!;
		public string Email { get; set; } = null!;
    }

    public class NewUserAccountInfo : UserAccountInfo
    {
        public string Password { get; set; } = null!;
    }
}

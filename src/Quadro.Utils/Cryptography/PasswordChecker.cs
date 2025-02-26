using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quadro.Utils.Cryptography
{

	public static class PasswordChecker
	{
		public static string GeneratePasswordHash(string plainTextPassword, out string salt)
		{
			salt = SaltGenerator.GetSaltString();

			string finalString = plainTextPassword + salt;

			return HashComputer.GetHashFromString(finalString);
		}

		public static bool IsPasswordMatch(string password, string salt, string hash)
		{
			string finalString = HashComputer.GetHashFromString(password + salt);
			return hash == finalString;
		}
	}
}

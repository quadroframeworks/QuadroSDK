using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Quadro.Utils.Cryptography
{

	public class SaltGenerator
	{
		private static RandomNumberGenerator randomNumberGenerator;
		private const int SALT_SIZE = 24;

		static SaltGenerator()
		{
			randomNumberGenerator = RandomNumberGenerator.Create();
		}

		public static string GetSaltString()
		{
			byte[] saltBytes = new byte[SALT_SIZE];
			randomNumberGenerator.GetNonZeroBytes(saltBytes);
			string saltString = BitConverter.ToString(saltBytes).Replace("-", "");
			return saltString;
		}
	}
}

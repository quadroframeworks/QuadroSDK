using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Quadro.Utils.Cryptography
{

	public static class HashComputer
	{
		public static string GetHashFromString(string password)
		{
			var sha = SHA256.Create();
			byte[] dataBytes = Encoding.Default.GetBytes(password);
			byte[] resultBytes = sha.ComputeHash(dataBytes);
			return BitConverter.ToString(resultBytes).Replace("-", "");
		}
	}

}

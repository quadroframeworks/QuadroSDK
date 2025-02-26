using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CPBase.UserManagement
{

    public class SaltGenerator
    {
        private static RNGCryptoServiceProvider m_cryptoServiceProvider = null;
        private const int SALT_SIZE = 24;

        static SaltGenerator()
        {
            m_cryptoServiceProvider = new RNGCryptoServiceProvider();
        }

        public static string GetSaltString()
        {
            byte[] saltBytes = new byte[SALT_SIZE];
            m_cryptoServiceProvider.GetNonZeroBytes(saltBytes);
            string saltString = BitConverter.ToString(saltBytes).Replace("-", "");
            return saltString;
        }
    }
}

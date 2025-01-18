using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CPBase.UserManagement
{

    public static class HashComputer
    {
        public static string GetPasswordHash(string message)
        {
            var sha = SHA256.Create();
            byte[] dataBytes = Encoding.Default.GetBytes(message);
            byte[] resultBytes = sha.ComputeHash(dataBytes);
            return BitConverter.ToString(resultBytes).Replace("-", "");
        }
    }

}

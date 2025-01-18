using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CPBase.UserManagement
{

    /// <summary>
    /// Can generate hash codes for password encryption.
    /// </summary>
    public static class HashComputer
    {
        public static string GetPasswordHash(string message)
        {
            // Let us use SHA256 algorithm to 
            // generate the hash from this salted password
            var sha = SHA256.Create();
            byte[] dataBytes = Encoding.Default.GetBytes(message);
            byte[] resultBytes = sha.ComputeHash(dataBytes);

            // return the hash string to the caller
            return BitConverter.ToString(resultBytes).Replace("-", "");
            //return Encoding.Default.GetString(resultBytes);
        }
    }

}

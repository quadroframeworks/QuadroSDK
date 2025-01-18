using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPBase.UserManagement
{

    /// <summary>
    /// Provides function for password encryption and password matching.
    /// </summary>
    public static class PasswordManager
    {

        /// <summary>
        /// Returns a password hash based on a hash code and a salt string.
        /// </summary>
        /// <param name="plainTextPassword"></param>
        /// <param name="salt"></param>
        /// <returns></returns>
        public static string GeneratePasswordHash(string plainTextPassword, out string salt)
        {
            salt = SaltGenerator.GetSaltString();

            string finalString = plainTextPassword + salt;

            return HashComputer.GetPasswordHash(finalString);
        }

        /// <summary>
        /// Returns a value if the password matches with the hash + salt that was once stored.
        /// </summary>
        /// <param name="password"></param>
        /// <param name="salt"></param>
        /// <param name="hash"></param>
        /// <returns></returns>
        public static bool IsPasswordMatch(string password, string salt, string hash)
        {
            string finalString = HashComputer.GetPasswordHash(password + salt);
            return hash == finalString;
        }
    }
}

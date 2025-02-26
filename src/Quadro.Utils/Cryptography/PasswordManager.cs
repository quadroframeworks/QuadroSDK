using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPBase.UserManagement
{

    public static class PasswordManager
    {
        public static string GeneratePasswordHash(string plainTextPassword, out string salt)
        {
            salt = SaltGenerator.GetSaltString();

            string finalString = plainTextPassword + salt;

            return HashComputer.GetPasswordHash(finalString);
        }

        public static bool IsPasswordMatch(string password, string salt, string hash)
        {
            string finalString = HashComputer.GetPasswordHash(password + salt);
            return hash == finalString;
        }
    }
}

using System.Linq;
using System.Security.Cryptography;

namespace KeepFit.Core.Services
{
    public class SecurityService : ISecurityService
    {
        private static readonly RNGCryptoServiceProvider CryptoServiceProvider = new RNGCryptoServiceProvider();
        private const int SaltSize = 24;

        public string GeneratePasswordHash(string plainTextPassword, out string salt)
        {
            salt = GetSaltString();

            var finalString = plainTextPassword + salt;

            return GetPasswordHashAndSalt(finalString);
        }

        public bool IsPasswordMatch(string password, string salt, string hash)
        {
            var finalString = password + salt;

            return hash == GetPasswordHashAndSalt(finalString);
        }

        #region Helpers
        private static string GetSaltString()
        {
            // Lets create a byte array to store the salt bytes
            var saltBytes = new byte[SaltSize];

            // lets generate the salt in the byte array
            CryptoServiceProvider.GetNonZeroBytes(saltBytes);

            // Let us get some string representation for this salt
            var saltString = GetString(saltBytes);

            // Now we have our salt string ready lets return it to the caller
            return saltString;
        }

        private string GetPasswordHashAndSalt(string message)
        {
            // Let us use SHA256 algorithm to 
            // generate the hash from this salted password
            var sha = new SHA256CryptoServiceProvider();
            var dataBytes = GetBytes(message);
            var resultBytes = sha.ComputeHash(dataBytes);

            // return the hash string to the caller
            return GetString(resultBytes);
        }

        // utilty function to convert string to byte[]        
        private static byte[] GetBytes(string str)
        {
            var bytes = new byte[str.Length * sizeof(char)];

            System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);

            return bytes;
        }

        // utilty function to convert byte[] to string        
        private static string GetString(byte[] bytes)
        {
            return string.Concat(bytes.Select(b => b.ToString("X2")));
        }
        #endregion
    }
}

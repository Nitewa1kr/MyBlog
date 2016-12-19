using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Security.Cryptography;
using System.Text;

namespace myBlog.PassHelper
{
    public class SaltHashing
    {
        public static string ComputeHash(string password, string HashAlgorithm, byte[] saltBytes)
        {
            if (saltBytes == null)
            {
                int minSaltSize = 4, maxSaltSize = 8, getSaltSize;

                Random rand = new Random();
                getSaltSize = rand.Next(minSaltSize, maxSaltSize);

                saltBytes = new byte[getSaltSize];

                RNGCryptoServiceProvider RNG = new RNGCryptoServiceProvider();

                RNG.GetNonZeroBytes(saltBytes);
            }

            byte[] PasswordBytes = Encoding.UTF8.GetBytes(password);

            byte[] PasswordWithSaltBytes = new byte[PasswordBytes.Length + saltBytes.Length];

            for (int i = 0; i < PasswordBytes.Length; i++)
            {
                PasswordWithSaltBytes[i] = PasswordBytes[i];
            }
            for (int i = 0; i < saltBytes.Length; i++)
            {
                PasswordWithSaltBytes[PasswordBytes.Length + i] = saltBytes[i];
            }

            //INITIALIZE APPROPRIATE HASH ALGORITHM
            HashAlgorithm hash = new SHA256Managed();

            //COMPUTE HASH VALUE OF PASSWORD WITH APPENDED SALT.
            byte[] HashBytes = hash.ComputeHash(PasswordWithSaltBytes);

            byte[] HashWithSaltBytes = new byte[HashBytes.Length + saltBytes.Length];

            //COPY HASH BYTES INTO RESULTING ARRAY
            for (int i = 0; i < HashBytes.Length; i++)
            {
                HashWithSaltBytes[i] = HashBytes[i];
            }
            for (int i = 0; i < saltBytes.Length; i++)
            {
                HashWithSaltBytes[HashBytes.Length + i] = saltBytes[i];
            }

            string HashValue = Convert.ToBase64String(HashWithSaltBytes);

            return HashValue;
        }

        public static bool VerifyHash(string password, string HashAlgorithm, string HashValue)
        {
            byte[] HashWithSaltBytes = Convert.FromBase64String(HashValue);
            //INITIALIZE BITS TO 256 FOR SHA256
            int HashSizeInBits = 256, HashSizeInBytes;

            HashSizeInBytes = HashSizeInBits / 8;

            if (HashWithSaltBytes.Length < HashSizeInBytes)
            {
                return false;
            }

            byte[] saltBytes = new byte[HashWithSaltBytes.Length - HashSizeInBytes];

            for (int i = 0; i < saltBytes.Length; i++)
            {
                saltBytes[i] = HashWithSaltBytes[HashSizeInBytes + i];
            }

            string exptedHashString = ComputeHash(password, HashAlgorithm, saltBytes);

            return (HashValue == exptedHashString);
        }
    }
}
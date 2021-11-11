using System;
using System.Security.Cryptography;
using System.Text;

namespace Imp4Task1Optimized
{
    class Program
    {
        static void Main(string[] args)
        {
            var hasOperations = new HashOperations();
            var saltBytes = Encoding.UTF8.GetBytes("516f8f4d1s5w8r7r");
            for (var i = 0; i < 1000; i++)
            {
                var guid = Guid.NewGuid().ToString();
                hasOperations.GeneratePasswordHashUsingSalt(guid, saltBytes);
            }
            Console.ReadLine();
        }


    }

    public class HashOperations
    {
        public string GeneratePasswordHashUsingSalt(string passwordText, byte[] salt)
        {
            var iterate = 10000;
            var pbkdf2 = new Rfc2898DeriveBytes(passwordText, salt, iterate);
            var hash = pbkdf2.GetBytes(10);
            var hashBytes = new byte[26];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 10);
            var passwordHash = Convert.ToBase64String(hashBytes);
            return passwordHash;
        }
    }
}

using System;
using System.IO;
using System.Security.Cryptography;

namespace SecureVast.SDK.Algorithms
{
    class SHA1Generator
    {
        public static string SHA1(string filePath)
        {
            using (SHA1 SHA1 = SHA1Managed.Create())
            {
                using (FileStream fileStream = File.OpenRead(filePath))
                    return Convert.ToBase64String(SHA1.ComputeHash(fileStream));
            }
        }
    }
}


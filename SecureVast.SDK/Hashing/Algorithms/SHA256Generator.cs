using System;
using System.IO;
using System.Security.Cryptography;

namespace SecureVast.SDK.Algorithms
{
    class SHA256Generator
    {
        public static string SHA256(string filePath)
        {
            using (SHA256 SHA256 = SHA256Managed.Create())
            {
                using (FileStream fileStream = File.OpenRead(filePath))
                    return Convert.ToBase64String(SHA256.ComputeHash(fileStream));
            }
        }
    }
}


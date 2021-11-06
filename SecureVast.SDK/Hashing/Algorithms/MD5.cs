using System;
using System.IO;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography;

namespace SecureVast.SDK.Algorithms
{

    [Obsolete("MD5 has been cryptographically broken and considered insecure. Please use other Algorithms.")]
    class MD5Generator
    {
        public static string MD5(string filePath)
        {
            using (var md5 = System.Security.Cryptography.MD5.Create())
            {
                using (var stream = File.OpenRead(filePath))
                {
                    var hash = md5.ComputeHash(stream);
                    return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
                }
            }
        }
    }
}
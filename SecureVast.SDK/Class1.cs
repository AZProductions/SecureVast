using System;
using System.IO;

namespace SecureVast.SDK
{
    public class HashAlgorithms
    {
        private static readonly string sHA256;
        public static string SHA256 => sHA256;

        private static bool writeAcces(string dirPath,
                                       bool throwIfFails = false)
        {
        try
        {
            using (FileStream fs = File.Create(
                Path.Combine(
                    dirPath, 
                    Path.GetRandomFileName()
                ), 
                1,
                FileOptions.DeleteOnClose)
            )
            { }
            return true;
        }
        catch
        {
            if (throwIfFails)
                throw;
            else
                return false;
        }
        }
    }

    public class Hash : HashAlgorithms
    {
        public Hash(string location)
        {
           
        }
    }
}


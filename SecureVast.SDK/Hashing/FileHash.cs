using System;
using System.IO;

namespace SecureVast.SDK
{
    public class FileHash
    {
        private readonly bool writeAccess = IO.writeAccess.GetAccess(Path.GetTempPath(), true);
        private string location { get; }

        public FileHash(string Location)
        {
            if (Location is null)
            {
                throw new ArgumentNullException(nameof(Location));
            }

            location = Location;
            SHA1 = Algorithms.SHA1Generator.SHA1(location);
            SHA256 = Algorithms.SHA256Generator.SHA256(location);
#pragma warning disable CS0618
            MD5 = Algorithms.MD5Generator.MD5(location);
#pragma warning restore CS0618
        }

        public string SHA256 { get; }
        public string SHA1 { get; }
        public string MD5 { get; }
        public string FullName { get; } = null;
        public string Name { get; } = Path.GetFileNameWithoutExtension(null);
        public bool WriteAccess => writeAccess;
    }
}


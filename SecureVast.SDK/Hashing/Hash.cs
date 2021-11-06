using System;
using System.IO;

namespace SecureVast.SDK
{
    public class Hash
    {
        public Hash(string Location)
        {
            if (Location is null)
            {
                throw new ArgumentNullException(nameof(Location));
            }

            _location = Location;
            SHA1 = Algorithms.SHA1Generator.SHA1(_location);
            SHA256 = Algorithms.SHA256Generator.SHA256(_location);
#pragma warning disable CS0618
            MD5 = Algorithms.MD5Generator.MD5(_location);
#pragma warning restore CS0618
        }

        private string _location { get; }
        public string SHA256 { get; }
        public string SHA1 { get; }
        public string MD5 { get; }
    }
}


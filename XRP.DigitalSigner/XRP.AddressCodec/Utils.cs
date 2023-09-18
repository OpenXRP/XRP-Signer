using System.Security.Cryptography;

namespace OpenXRP.AddressCodec
{
    public class Utils
    {
        private static object _lock = new object();
        public static HashAlgorithm digest = HashAlgorithm.Create("SHA-256");

        public static byte[] doubleDigest(byte[] input)
        {
            return doubleDigest(input, 0, input.Length);
        }

        public static byte[] doubleDigest(byte[] input, int offset, int length)
        {
            lock (_lock)
            {
                digest.Clear();
                digest.ComputeHash(input, offset, length);
                var first = digest.Hash;
                return digest.ComputeHash(first);
            }
        }
    }
}

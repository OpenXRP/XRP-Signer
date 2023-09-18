using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using XRP.Net.Utils.Extensions;

namespace OpenXRP.AddressCodec
{
    public class UnsignedByteArray : IDisposable
    {
        public List<UnsignedByte> unsignedBytes = new List<UnsignedByte>();
        private bool destroyed;

        public UnsignedByteArray(List<UnsignedByte> unsignedBytes)
        {
            if (unsignedBytes == null) throw new ArgumentNullException("Unsigned bytes array must not be null");
            this.unsignedBytes = unsignedBytes;
        }

        public static UnsignedByteArray Of(byte[] bytes)
        {
            if (bytes == null) throw new ArgumentNullException("Byte array cannot be null and must contain a value");

            var cunsignedBytes = new List<UnsignedByte>();
            for (int i = 0; i < bytes.Length; i++)
            {
                cunsignedBytes.Add(UnsignedByte.Of((byte)i, bytes[i]));
            }

            return new UnsignedByteArray(cunsignedBytes);
        }

        public static UnsignedByteArray Of(UnsignedByte first, params UnsignedByte[] rest)
        {
            var cunsignedBytes = new List<UnsignedByte>();
            cunsignedBytes.Add(first);
            cunsignedBytes.AddRange(rest);

            return new UnsignedByteArray(cunsignedBytes);
        }

        public static UnsignedByteArray Empty()
        {
            return new UnsignedByteArray(new List<UnsignedByte>());
        }
        public static UnsignedByteArray OfSize(int size)
        {
            return new UnsignedByteArray(new List<UnsignedByte>(size));
        }


        //public static UnsignedByteArray FromHex(string hex)
        //{
        //    if (string.IsNullOrWhiteSpace(hex))
        //    {
        //        throw new ArgumentNullException("Hex must contain a value, and cannot be null");
        //    }

        //    var cunsignedBytes = new List<UnsignedByte>();
        //    return new UnsignedByteArray(new List<UnsignedByte>(size));
        //}


        public void Dispose()
        {
        }
    }
}

using OpenXRP.AddressCodec.Exceptions;
using System;
using System.Collections.Generic;

namespace OpenXRP.AddressCodec
{
    public class ByteUtils
    {
        public static byte[] ToByteArray(long value, int byteSize)
        {
            return ToLeftPaddedByteArray(byteSize, CheckSize(byteSize & Byte.MaxValue, value));
        }

        public static byte[] ToLeftPaddedByteArray(int byteSize, long bigInteger)
        {
            var target = new byte[byteSize];
            var source = BitConverter.GetBytes(bigInteger);
            for (int i = 0; i < byteSize; i++)
            {
                target[byteSize - i - 1] = source[source.Length - i - 1];
            }

            return target;
        }

        public static List<UnsignedByte> Parse(string hex)
        {
            var padded = Padded(hex);
            var result = new List<UnsignedByte>();
            for (int i = 0; i < padded.Length; i++)
            {
                result.Add(UnsignedByte.Of(padded.Substring(i, i + 2)));
            }

            return result;
        }

        public static long CheckSize(int expectedBits, long value)
        {
            if (!(value <= expectedBits))
            {
                throw new EncodeException("Value is outside expected bit range");
            }

            return value;
        }

        public static string Padded(string hex)
        {
            return hex.Length % 2 == 0 ? hex : string.Concat("0", hex);
        }

        public static string Padded(string hex, int hexLength)
        {
            return new String('0', hexLength - hex.Length) + hex;
        }
    }
}

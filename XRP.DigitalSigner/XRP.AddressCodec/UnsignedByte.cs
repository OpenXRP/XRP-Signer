using OpenXRP.AddressCodec.Exceptions;
using System;
using XRP.Net.Utils.Extensions;

namespace OpenXRP.AddressCodec
{
    public class UnsignedByte : IDisposable
    {
        private int value;

        public UnsignedByte(int value)
        {
            if (value >= 0 && value <= 255)
            {
                this.value = value;
            }

            throw new EncodingFormatException("Value is out of range, and must be between 0 and 255");
        }

        public static UnsignedByte Of(int value)
        {
            return new UnsignedByte(value);
        }

        public static UnsignedByte Of(byte value)
        {
            return new UnsignedByte(value & 0xff);
        }
        public static UnsignedByte Of(byte highBits, byte lowBits)
        {
            return new UnsignedByte((highBits << 4) + lowBits);
        }

        public static UnsignedByte Of(string hex)
        {
            var highBits = Decimal.ToByte(HexExtensions.GetDecimalFromHex(hex));
            var lowBits = Decimal.ToByte(HexExtensions.GetDecimalFromHex(hex));

            return Of(highBits, lowBits);
        }

        public int AsInt()
        {
            return value;
        }
        public byte AsByte()
        {
            return (byte)value;
        }
        public int GetHighBits()
        {
            return value >> 4;
        }
        public int GetLowBits()
        {
            return value & 0x0F;
        }

        public bool IsNthBitSet(int nth)
        {
            if (nth >= 1 && nth <= 8)
            {
                return (value >> (8 - nth) & 1) == 1;
            }

            throw new EncodingFormatException("nthBit cannot be encoded, invalid range, must be between 1 and 8");
        }

        public UnsignedByte Or(UnsignedByte unsignedByte)
        {
            return Of(value | unsignedByte.value);
        }

        public string HexValue()
        {
            return HexExtensions.ToStringHex(new byte[] { AsByte() });
        }

        public override bool Equals(object obj)
        {
            if (this == obj)
            {
                return true;
            }
            if (!(obj is UnsignedByte))
            {
                return false;
            }

            var that = (UnsignedByte)obj;
            return value == that.value;
        }

        public void Dispose()
        {
            this.value = 0;
        }
    }
}

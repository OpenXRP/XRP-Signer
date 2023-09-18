namespace OpenXRP.AddressCodec
{
    public class Version
    {
        public int[] ED25519_SEED = new int[] { 0x01, 0xE1, 0x4B };
        public int[] FAMILY_SEED = new int[] { 0x21 };
        public int[] ACCOUNT_ID = new int[] { 0 };
        public int[] NODE_PUBLIC = new int[] { 0x1C };
        public int[] ACCOUNT_PUBLIC_KEY = new int[] { 0x23 };

        public static int[] values;

        public byte[] GetValuesAsBytes()
        {
            var bytes = new byte[values.Length];
            for (int i = 0; i < values.Length; i++)
            {
                bytes[i] = (byte)values[i];
            }

            return bytes;
        }
    }
}

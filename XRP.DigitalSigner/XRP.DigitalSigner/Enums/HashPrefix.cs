namespace XRP.DigitalSigner.Enums
{
    public enum HashPrefix
    {
        TRANSACTION_ID = 0x54584e00,
        TRANSACTION_NODE = 0x534e4400,
        INNER_NODE = 0x4d494e00,
        LEAF_NODE = 0x4d4c4e00,
        TRANSACTION_SIGN = 0x53545800,
        TRANSACTION_SIGN_TESTNET = 0x73747800,
        TRANSACTION_MULTISIGN = 0x534d5400,
        LEDGER = 0x4c575200,
    }
}

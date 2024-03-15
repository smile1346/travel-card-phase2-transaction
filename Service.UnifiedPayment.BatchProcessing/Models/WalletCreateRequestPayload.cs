namespace Models;

struct WalletCreateRequestPayload
{
    public Guid customerWalletProfileId;
    public string walletName;
    public string currencyCode;
    public string walletType;
    // public bool canDisburse;
    public string additionalInformation;
}

struct WalletCreateResponsePayload
{
    public Guid walletId;
    public decimal availableBalance;
    public decimal ledgerBalance;
    public DateTime balanceAsOf;
    public string walletName;
    public string currencyCode;
    public string walletType;
    // public bool canDisburse;
    public string additionalInformation;
    public Guid customerWalletProfileId;
}
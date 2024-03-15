namespace Models;

class WalletProviderCreateRequestPayload
{
    public string name;
    public string taxId;
    public KYCInfo kycInfo;
}

class WalletProviderCreateResponsePayload : WalletProviderCreateRequestPayload{
    public string walletProviderId;
}
using System.ComponentModel;

namespace Models;

public class CustomerCreateResponsePayload
{
    public Guid customerWalletProfileId;
    public string walletProviderId;
    public string mobileNumber;
    public KYCInfo kycInfo;
}
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace ModelsYoutap;

public struct AccountInfo
{
    [DefaultValue("3481")]
    public string Owner { get; set; }

    [DefaultValue(null)]
    public object Msisdn { get; set; }

    [DefaultValue("112233")]
    [JsonPropertyName("accountPin")]
    public string AccountPin { get; set; }

    [DefaultValue("AccountName")]
    public string Name { get; set; }

    [DefaultValue(91)]
    [JsonPropertyName("walletType")]
    public int WalletType { get; set; }

    [DefaultValue("ff69700c")]
    public string Color { get; set; }

    [DefaultValue("FINERACT")]
    [JsonPropertyName("accountCreator")]
    public string AccountCreator { get; set; }
}

using System.Text.Json.Serialization;

namespace UpdateAccountResponseSuccessModel;

public class Root
{
    [JsonPropertyName("owner")]
    public string Owner { get; set; }

    [JsonPropertyName("accountId")]
    public int AccountId { get; set; }

    [JsonPropertyName("accountType")]
    public string AccountType { get; set; }

    [JsonPropertyName("accountTypeDescription")]
    public object AccountTypeDescription { get; set; }

    [JsonPropertyName("status")]
    public object Status { get; set; }

    [JsonPropertyName("suspend")]
    public object Suspend { get; set; }

    [JsonPropertyName("fraudlock")]
    public bool Fraudlock { get; set; }

    [JsonPropertyName("timezoneId")]
    public int TimezoneId { get; set; }

    [JsonPropertyName("javaTimezone")]
    public string JavaTimezone { get; set; }

    [JsonPropertyName("smsNotification")]
    public bool SmsNotification { get; set; }

    [JsonPropertyName("emailNotification")]
    public bool EmailNotification { get; set; }

    [JsonPropertyName("pushNotification")]
    public bool PushNotification { get; set; }

    [JsonPropertyName("walletType")]
    public object WalletType { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("accountGroup")]
    public object AccountGroup { get; set; }

    [JsonPropertyName("accountCreator")]
    public string AccountCreator { get; set; }

    [JsonPropertyName("accountPin")]
    public object AccountPin { get; set; }

    [JsonPropertyName("expiryDate")]
    public object ExpiryDate { get; set; }

    [JsonPropertyName("firstUsed")]
    public object FirstUsed { get; set; }

    [JsonPropertyName("firstUsedDate")]
    public object FirstUsedDate { get; set; }

    [JsonPropertyName("lastUsed")]
    public object LastUsed { get; set; }

    [JsonPropertyName("creationDate")]
    public object CreationDate { get; set; }

    [JsonPropertyName("balances")]
    public object Balances { get; set; }

    [JsonPropertyName("balanceTypes")]
    public object BalanceTypes { get; set; }

    [JsonPropertyName("customerName")]
    public object CustomerName { get; set; }

    [JsonPropertyName("parentAccountId")]
    public object ParentAccountId { get; set; }

    [JsonPropertyName("parentAccountCust")]
    public object ParentAccountCust { get; set; }

    [JsonPropertyName("language")]
    public string Language { get; set; }

    [JsonPropertyName("glcode")]
    public object Glcode { get; set; }

    [JsonPropertyName("upgradeOption")]
    public object UpgradeOption { get; set; }

    [JsonPropertyName("vendor")]
    public object Vendor { get; set; }

    [JsonPropertyName("msisdn")]
    public object Msisdn { get; set; }

    [JsonPropertyName("delete")]
    public bool Delete { get; set; }

    [JsonPropertyName("default")]
    public bool Default { get; set; }

    [JsonPropertyName("taxRate")]
    public object TaxRate { get; set; }

    [JsonPropertyName("withHoldTax")]
    public bool WithHoldTax { get; set; }

    [JsonPropertyName("taxNumber")]
    public object TaxNumber { get; set; }

    [JsonPropertyName("color")]
    public string Color { get; set; }
}


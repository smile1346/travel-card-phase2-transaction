using System.Text.Json.Serialization;

namespace GetQuickAccountsResponseModel;

public class Balance
{
    [JsonPropertyName("balanceId")]
    public int BalanceId { get; set; }

    [JsonPropertyName("balance")]
    public double BalanceValue { get; set; }

    [JsonPropertyName("balanceType")]
    public string BalanceType { get; set; }

    [JsonPropertyName("balanceTypeId")]
    public int BalanceTypeId { get; set; }

    [JsonPropertyName("metric")]
    public Metric Metric { get; set; }
}

public class Metric
{
    [JsonPropertyName("unitLongName")]
    public string UnitLongName { get; set; }

    [JsonPropertyName("unitShortName")]
    public string UnitShortName { get; set; }

    [JsonPropertyName("displayString")]
    public string DisplayString { get; set; }

    [JsonPropertyName("displayDivisor")]
    public int DisplayDivisor { get; set; }

    [JsonPropertyName("displayUnitDelimiter")]
    public string DisplayUnitDelimiter { get; set; }

    [JsonPropertyName("displayUnitMinorDelimiter")]
    public string DisplayUnitMinorDelimiter { get; set; }

    [JsonPropertyName("displayFormatter")]
    public string DisplayFormatter { get; set; }
}

public class Root
{
    [JsonPropertyName("clientType")]
    public string ClientType { get; set; }

    [JsonPropertyName("customerId")]
    public int CustomerId { get; set; }

    [JsonPropertyName("accountId")]
    public int AccountId { get; set; }

    [JsonPropertyName("accountName")]
    public string AccountName { get; set; }

    [JsonPropertyName("suspended")]
    public bool Suspended { get; set; }

    [JsonPropertyName("fraudLocked")]
    public bool FraudLocked { get; set; }

    [JsonPropertyName("accountStatus")]
    public string AccountStatus { get; set; }

    [JsonPropertyName("accountStatusId")]
    public int AccountStatusId { get; set; }

    [JsonPropertyName("default")]
    public bool Default { get; set; }

    [JsonPropertyName("accountType")]
    public string AccountType { get; set; }

    [JsonPropertyName("accountTypeId")]
    public int? AccountTypeId { get; set; }

    [JsonPropertyName("accountColor")]
    public string AccountColor { get; set; }

    [JsonPropertyName("walletType")]
    public string WalletType { get; set; }

    [JsonPropertyName("walletTypeId")]
    public int? WalletTypeId { get; set; }

    [JsonPropertyName("createdDate")]
    public object CreatedDate { get; set; }

    [JsonPropertyName("balances")]
    public List<Balance> Balances { get; set; }
}

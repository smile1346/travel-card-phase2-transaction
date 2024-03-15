using System.Text.Json.Serialization;

namespace GetAvailableWalletTypesResponseModel;

// Root myDeserializedClass = JsonSerializer.Deserialize<List<Root>>(myJsonResponse);
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
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; }

    [JsonPropertyName("imageUrl")]
    public string ImageUrl { get; set; }

    [JsonPropertyName("conditionsUrl")]
    public string ConditionsUrl { get; set; }

    [JsonPropertyName("accountTypes")]
    public List<string> AccountTypes { get; set; }

    [JsonPropertyName("rules")]
    public List<Rule> Rules { get; set; }

    [JsonPropertyName("status")]
    public string Status { get; set; }

    [JsonPropertyName("externalSystemId")]
    public int? ExternalSystemId { get; set; }

    [JsonPropertyName("externalSystemType")]
    public string ExternalSystemType { get; set; }

    [JsonPropertyName("taxTypeId")]
    public int? TaxTypeId { get; set; }

    [JsonPropertyName("taxTypeName")]
    public string TaxTypeName { get; set; }

    [JsonPropertyName("taxTypeDescription")]
    public string TaxTypeDescription { get; set; }

    [JsonPropertyName("interestRate")]
    public double? InterestRate { get; set; }

    [JsonPropertyName("available")]
    public bool Available { get; set; }
}

public class Rule
{
    [JsonPropertyName("balanceTypeId")]
    public int BalanceTypeId { get; set; }

    [JsonPropertyName("minTransferAmount")]
    public int MinTransferAmount { get; set; }

    [JsonPropertyName("maxBalanceAmount")]
    public object MaxBalanceAmount { get; set; }

    [JsonPropertyName("withdrawalDelay")]
    public int WithdrawalDelay { get; set; }

    [JsonPropertyName("metric")]
    public Metric Metric { get; set; }
}


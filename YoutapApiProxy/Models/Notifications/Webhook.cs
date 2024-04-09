
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Annotations;
namespace WebhookModel;

[SwaggerSchema("The details of the event, this is a dynamic object varied by specific events.")]
public class Detail
{
    [JsonPropertyName("EVENT")]
    [SwaggerSchema("**Example: LOW_BALANCE**")]
    public string Event { get; set; }

    [JsonPropertyName("eventType")]
    [SwaggerSchema("**Example: CONSUMER**")]
    public string EventType { get; set; }

    [JsonPropertyName("dateTime")]
    [SwaggerSchema("**Format: 2024-02-02 12:12:12**")]
    public string DateTime { get; set; }

    [JsonPropertyName("time")]
    [SwaggerSchema("**Format: 12:12PM**")]
    public string Time { get; set; }

    [JsonPropertyName("newBalance")]
    [SwaggerSchema("New account balance after transaction")]
    public string NewBalance { get; set; }

    [JsonPropertyName("balanceThreshold")]
    [SwaggerSchema("The associated balance threshold from configuration")]
    public string BalanceThreshold { get; set; }

    [JsonPropertyName("currency")]
    [SwaggerSchema("The balance currency code\n\nFormat: ISO 4217 standard three-letter codes for currencies, uppercase\n\nSample Value: THB")]
    public string Currency { get; set; }

    [JsonPropertyName("date")]
    public string Date { get; set; }

    [JsonPropertyName("remainingBalanceAvailable")]
    public double RemainingBalanceAvailable { get; set; }

    [JsonPropertyName("lowBalanceThreshold")]
    public double LowBalanceThreshold { get; set; }

    [JsonPropertyName("merchantEmail")]
    public string MerchantEmail { get; set; }

    [JsonPropertyName("acctid")]
    [SwaggerSchema("Account ID")]
    public int Acctid { get; set; }

    [JsonPropertyName("language")]
    public string Language { get; set; }

    [JsonPropertyName("transactionId")]
    public int TransactionId { get; set; }

    // [JsonPropertyName("EVENT")]
    // public string EVENT { get; set; }

    [JsonPropertyName("merchantName")]
    public string MerchantName { get; set; }

    [JsonPropertyName("ACCTID")]
    [SwaggerSchema("Account ID")]
    public int ACCTID { get; set; }

    [JsonPropertyName("remainingBalance")]
    public double RemainingBalance { get; set; }

    [JsonPropertyName("PACKAGE_NAME")]
    public string PackageName { get; set; }

    [JsonPropertyName("terminalIds")]
    public List<string> TerminalIds { get; set; }

    [JsonPropertyName("currencyCode")]
    public string CurrencyCode { get; set; }
}

public class Root
{
    [JsonPropertyName("event")]
    [SwaggerSchema("**Example: LOW_BALANCE** the event name")]
    public string Event { get; set; }

    [JsonPropertyName("detail")]
    public Detail Detail { get; set; }
}


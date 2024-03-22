
using System.Text.Json.Serialization;
namespace WebhookModel;
public class Detail
{
    [JsonPropertyName("event")]
    public string Event { get; set; }

    [JsonPropertyName("eventType")]
    public string EventType { get; set; }

    [JsonPropertyName("dateTime")]
    public string DateTime { get; set; }

    [JsonPropertyName("time")]
    public string Time { get; set; }

    [JsonPropertyName("newBalance")]
    public string NewBalance { get; set; }

    [JsonPropertyName("balanceThreshold")]
    public string BalanceThreshold { get; set; }

    [JsonPropertyName("currency")]
    public string Currency { get; set; }
}

public class Root
{
    [JsonPropertyName("event")]
    public string Event { get; set; }

    [JsonPropertyName("detail")]
    public Detail Detail { get; set; }
}


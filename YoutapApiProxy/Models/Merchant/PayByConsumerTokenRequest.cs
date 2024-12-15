// Root myDeserializedClass = JsonSerializer.Deserialize<Root>(myJsonResponse);
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Swashbuckle.AspNetCore.Annotations;

namespace PayByConsumerTokenRequestModel;
// Root myDeserializedClass = JsonSerializer.Deserialize<Root>(myJsonResponse);
public class AdditionalDetails
{
    [JsonPropertyName("paymentPurpose")]
    public string PaymentPurpose { get; set; }
}

public class OriginalAmount
{
    [Required]
    [JsonPropertyName("amount")]
    public string Amount { get; set; }

    [Required]
    [JsonPropertyName("currency")]
    public string Currency { get; set; }
}

public class Root
{
    [Required]
    [JsonPropertyName("payeeAccount")]
    public string PayeeAccount { get; set; }

    [Required]
    [JsonPropertyName("payeeDevice")]
    public string PayeeDevice { get; set; }

    [Required]
    [JsonPropertyName("cpmQrCode")]
    public string CpmQrCode { get; set; }

    [JsonPropertyName("terminalId")]
    public string TerminalId { get; set; }

    [JsonPropertyName("channel")]
    public string Channel { get; set; }

    [Required]
    [JsonPropertyName("requestRef")]
    public string RequestRef { get; set; }

    [Required]
    [JsonPropertyName("originalAmount")]
    public OriginalAmount OriginalAmount { get; set; }

    [JsonPropertyName("notes")]
    public string Notes { get; set; }

    [JsonPropertyName("additionalDetails")]
    public AdditionalDetails AdditionalDetails { get; set; }
}


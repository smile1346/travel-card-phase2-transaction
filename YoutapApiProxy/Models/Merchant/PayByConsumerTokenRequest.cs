// Root myDeserializedClass = JsonSerializer.Deserialize<Root>(myJsonResponse);
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Swashbuckle.AspNetCore.Annotations;

namespace PayByConsumerTokenRequestModel;
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
    [SwaggerSchema("The `Customer Number` of the merchant, as shown in CMS portal.")]
    [JsonPropertyName("payeeAccount")]
    public string PayeeAccount { get; set; }

    [Required]
    [JsonPropertyName("payeeDevice")]
    [SwaggerSchema("ID of the device that initiated the payment, use `API` if unknown.")]
    public string PayeeDevice { get; set; }

    [Required]
    [JsonPropertyName("cpmQrCode")]
    public string CpmQrCode { get; set; }

    [Required]
    [JsonPropertyName("requestRef")]
    [SwaggerSchema("unique reference number for lookup, same as `externalReference`.")]
    public string RequestRef { get; set; }

    [Required]
    [JsonPropertyName("originalAmount")]
    public OriginalAmount OriginalAmount { get; set; }

    [JsonPropertyName("billReference")]
    public string BillReference { get; set; }

    [JsonPropertyName("salesId")]
    public string SalesId { get; set; }

    [JsonPropertyName("balanceType")]
    public string BalanceType { get; set; }
}


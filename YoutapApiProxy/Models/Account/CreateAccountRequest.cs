using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Swashbuckle.AspNetCore.Annotations;

namespace CreateAccountRequestModel;

// Root myDeserializedClass = JsonSerializer.Deserialize<Root>(myJsonResponse);
public class Root
{
    [JsonPropertyName("owner")]
    [Required]
    [SwaggerSchema("Customer ID from KYC.")]
    public string Owner { get; set; }

    [JsonPropertyName("msisdn")]
    public object Msisdn { get; set; }

    [JsonPropertyName("accountPin")]
    [SwaggerSchema("The PIN used for authorization.")]
    public string AccountPin { get; set; }

    [JsonPropertyName("name")]
    [SwaggerSchema("**Example: “Bowling fund”.** Name for identifying accounts.")]
    public string Name { get; set; }

    [JsonPropertyName("walletType")]
    [Required]
    [SwaggerSchema("**Example: 9 for “Xceda Secured Term Deposit”.** Wallet types are primarily used to define minimum and maximum balances for each type.")]
    public int WalletType { get; set; }

    [JsonPropertyName("color")]
    [SwaggerSchema("**Example: “ff00ff00”.** Used for differentiating accounts.")]
    public string Color { get; set; }

    [JsonPropertyName("accountCreator")]
    [SwaggerSchema("**Example: “YTS”.** System identifier (use YTS unless using loans/savings)")]
    public string AccountCreator { get; set; }
}


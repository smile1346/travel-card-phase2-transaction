using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Swashbuckle.AspNetCore.Annotations;

namespace GeneralTransactionRequestModel;

[SwaggerSchema("The account ID, QR code, OTP, and other details that may be provided for the merchant/customer.")]
public class UserDetails
{
    [JsonPropertyName("accountId")]
    [Required]
    public string AccountId { get; set; }

    [JsonPropertyName("mobileNumber")]
    public string MobileNumber { get; set; }

    [JsonPropertyName("nfgTag")]
    public string NfcTag { get; set; }

    [JsonPropertyName("qrCode")]
    public string QrCode { get; set; }

    [JsonPropertyName("otp")]
    public string OTP { get; set; }

    [JsonPropertyName("firstName")]
    public string FirstName { get; set; }

    [JsonPropertyName("lastName")]
    public string LastName { get; set; }
}

public class Root
{
    // [JsonPropertyName("walletProviderId")]
    // [Required]
    // public string WalletProviderId { get; set; }

    [JsonPropertyName("mode")]
    [Required]
    [SwaggerSchema("**Example: 'QUERY' or 'TRANSACTION'** Either 'query' mode or 'transaction' mode.\n\nQuery: The payment system primarily focuses on retrieving information or querying the status of a transaction without necessarily initiating any financial transaction\n\nTransaction: Transaction mode, on the other hand, involves the initiation and processing of financial transactions.")]
    public string Mode { get; set; }

    [JsonPropertyName("transactionDate")]
    [Required]
    [SwaggerSchema("**Example: 1709615431600** The epoch time of the transaction in milliseconds.")]
    public long TransactionDate { get; set; }

    [JsonPropertyName("merchantDetails")]
    [Required]
    public UserDetails MerchantDetails { get; set; }

    [JsonPropertyName("customerDetails")]
    [Required]
    public UserDetails CustomerDetails { get; set; }

    [JsonPropertyName("transactionDetails")]
    [Required]
    public TransactionDetails TransactionDetails { get; set; }
}

[SwaggerSchema("The amount, balance type, bill reference, etc. that all define how the transaction should be processed.")]
public class TransactionDetails
{
    [JsonPropertyName("transactionAmount")]
    [Required]
    public string TransactionAmount { get; set; }

    [JsonPropertyName("currency")]
    [Required]
    [SwaggerSchema("amount currency\n\nFormat: ISO 4217 standard three-letter codes for currencies, uppercase\n\nSample value: THB")]
    public string Currency { get; set; }

    [JsonPropertyName("balanceType")]
    [Required]
    [SwaggerSchema("Type of balance\n\nDefault: `EMONEY`\n\n")]
    public string BalanceType { get; set; }

    [JsonPropertyName("channel")]
    [Required]
    [SwaggerSchema("Use `Bank` to represent the top up from BBL channel")]
    public string Channel { get; set; }

    [JsonPropertyName("paymentType")]
    [Required]
    [SwaggerSchema("C2MD (customer to merchant deposit)\n\nC2MW (customer to merchant withdrawal)\n\nC2MP (customer to merchant purchase) etc.")]
    public string PaymentType { get; set; }

    [JsonPropertyName("terminalId")]
    [Required]
    public string TerminalId { get; set; }

    [JsonPropertyName("externalReference")]
    [SwaggerSchema("unique reference number for lookup")]
    public string ExternalReference { get; set; }
}


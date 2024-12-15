using System.Text.Json.Serialization;

namespace PayByMerchantTokenRequestModel;
public class AdditionalDetails
{
    [JsonPropertyName("paymentPurpose")]
    public string PaymentPurpose { get; set; }
}

public class Root
{
    [JsonPropertyName("transactionAmount")]
    public TransactionAmount TransactionAmount { get; set; }

    [JsonPropertyName("balanceType")]
    public string BalanceType { get; set; }

    [JsonPropertyName("merchantId")]
    public string MerchantId { get; set; }

    [JsonPropertyName("channel")]
    public string Channel { get; set; }

    [JsonPropertyName("billReference")]
    public string BillReference { get; set; }

    [JsonPropertyName("terminalId")]
    public string TerminalId { get; set; }

    [JsonPropertyName("externalReference")]
    public string ExternalReference { get; set; }

    [JsonPropertyName("notes")]
    public string Notes { get; set; }

    [JsonPropertyName("additionalDetails")]
    public AdditionalDetails AdditionalDetails { get; set; }
}

public class TransactionAmount
{
    [JsonPropertyName("amount")]
    public string Amount { get; set; }

    [JsonPropertyName("currency")]
    public string Currency { get; set; }
}


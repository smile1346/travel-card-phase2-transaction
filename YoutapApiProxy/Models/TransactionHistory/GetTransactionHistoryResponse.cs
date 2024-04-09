using System.Text.Json.Serialization;
using Swashbuckle.AspNetCore.Annotations;

namespace GetTransactionHistoryResponse;

public class Content
{
    [JsonPropertyName("merchantId")]
    public object MerchantId { get; set; }

    [JsonPropertyName("customerId")]
    public object CustomerId { get; set; }

    [JsonPropertyName("nfcTagId")]
    public object NfcTagId { get; set; }

    [JsonPropertyName("date")]
    [SwaggerSchema("Transaction date (Epoch)")]
    public string Date { get; set; }

    [JsonPropertyName("receiptAdditionalDetails")]
    public object ReceiptAdditionalDetails { get; set; }

    [JsonPropertyName("salesId")]
    public int SalesId { get; set; }

    [JsonPropertyName("latitude")]
    public double Latitude { get; set; }

    [JsonPropertyName("longitude")]
    public double Longitude { get; set; }

    [JsonPropertyName("productId")]
    public object ProductId { get; set; }

    [JsonPropertyName("billerId")]
    public object BillerId { get; set; }

    [JsonPropertyName("pylId")]
    public object PylId { get; set; }

    [JsonPropertyName("paymentModeId")]
    [SwaggerSchema("Payment method ID")]
    public int PaymentModeId { get; set; }

    [JsonPropertyName("sourceAcctId")]
    public int SourceAcctId { get; set; }

    [JsonPropertyName("alternateAccountId")]
    [SwaggerSchema("Customized field for Promptpay wallet Id\n\nFormat: Promptpay Wallet Id Format 160-01-{accountId} (10 digit)")]
    public string AlternateAccountId { get; set; }

    [JsonPropertyName("relatedAcctId")]
    public int RelatedAcctId { get; set; }

    [JsonPropertyName("bplId")]
    public object BplId { get; set; }

    [JsonPropertyName("transactionCCNumber")]
    public object TransactionCCNumber { get; set; }

    [JsonPropertyName("terminalId")]
    public object TerminalId { get; set; }

    [JsonPropertyName("contactMsisdn")]
    public object ContactMsisdn { get; set; }

    [JsonPropertyName("paymentType")]
    [SwaggerSchema("Type of payment. Possible Values:  `Top-up / เติมเงิน`\n\n`Payment / ชําระค่าสินค้าหรือบริการ`\n\n`Transportation Fare / ค่าโดยสารรถไฟฟ้า`")]
    public string PaymentType { get; set; }

    [JsonPropertyName("status")]
    public object Status { get; set; }

    [JsonPropertyName("message")]
    [SwaggerSchema("Free-form notes related to the transaction")]
    public string Message { get; set; }

    [JsonPropertyName("duration")]
    public object Duration { get; set; }

    [JsonPropertyName("dateFallback")]
    public object DateFallback { get; set; }

    [JsonPropertyName("accountRefId")]
    public string AccountRefId { get; set; }

    [JsonPropertyName("transactionRef")]
    public string TransactionRef { get; set; }

    [JsonPropertyName("balanceType")]
    public int BalanceType { get; set; }

    [JsonPropertyName("extSession")]
    public string ExtSession { get; set; }

    [JsonPropertyName("sourceRef")]
    [SwaggerSchema("Reference ID of the source, sending from source in bill payment, top up or other transaction\n\nFormat: String (max length support 50 digits)")]
    public string SourceRef { get; set; }

    [JsonPropertyName("patternA")]
    public string PatternA { get; set; }

    [JsonPropertyName("patternB")]
    public string PatternB { get; set; }

    [JsonPropertyName("patternC")]
    public string PatternC { get; set; }

    [JsonPropertyName("workingAmount")]
    public double WorkingAmount { get; set; }

    [JsonPropertyName("workingAmountDisplay")]
    [SwaggerSchema("Transaction amount")]
    public string WorkingAmountDisplay { get; set; }

    [JsonPropertyName("sendingAmountExclFee")]
    public object SendingAmountExclFee { get; set; }

    [JsonPropertyName("receivedAmount")]
    public object ReceivedAmount { get; set; }

    [JsonPropertyName("fxRate")]
    public object FxRate { get; set; }

    [JsonPropertyName("totalFee")]
    public object TotalFee { get; set; }

    [JsonPropertyName("costToSend")]
    public object CostToSend { get; set; }

    [JsonPropertyName("balanceBefore")]
    public double BalanceBefore { get; set; }

    [JsonPropertyName("balanceAfter")]
    public double BalanceAfter { get; set; }

    [JsonPropertyName("balanceAfterDisplay")]
    public string BalanceAfterDisplay { get; set; }

    [JsonPropertyName("workingCurrencyUnit")]
    [SwaggerSchema("Currency unit short name\n\nFormat: ISO 4217 standard three-letter codes for currencies, uppercase\n\nSample Value: THB")]
    public string WorkingCurrencyUnit { get; set; }

    [JsonPropertyName("workingCurrencySymbol")]
    [SwaggerSchema("Currency symbol\n\nSample Value: ฿")]
    public string WorkingCurrencySymbol { get; set; }

    [JsonPropertyName("destinationCurrencyUnit")]
    public object DestinationCurrencyUnit { get; set; }

    [JsonPropertyName("destinationCurrencySymbol")]
    public object DestinationCurrencySymbol { get; set; }

    [JsonPropertyName("txType")]
    public string TxType { get; set; }

    [JsonPropertyName("transactionTypeCode")]
    [SwaggerSchema("Code for the transaction type (DR/CR)")]
    public string TransactionTypeCode { get; set; }

    [JsonPropertyName("billableEvent")]
    public int BillableEvent { get; set; }

    [JsonPropertyName("billableEvent2")]
    public int BillableEvent2 { get; set; }

    [JsonPropertyName("reversalOriginalTransactionId")]
    public int ReversalOriginalTransactionId { get; set; }

    [JsonPropertyName("transactionId")]
    [SwaggerSchema("Transaction ID\n\nFormat: String (10 digits)")]
    public string TransactionId { get; set; }

    [JsonPropertyName("utransactionId")]
    public object UtransactionId { get; set; }

    [JsonPropertyName("paymentTrailId")]
    public object PaymentTrailId { get; set; }

    [JsonPropertyName("originCode")]
    public string OriginCode { get; set; }

    [JsonPropertyName("destinationCode")]
    public string DestinationCode { get; set; }

    [JsonPropertyName("debitName")]
    public string DebitName { get; set; }

    [JsonPropertyName("creditName")]
    [SwaggerSchema("Merchant name where the customer has made a payment")]
    public string CreditName { get; set; }

    [JsonPropertyName("externalAccount")]
    public string ExternalAccount { get; set; }
}

public class Root
{
    [JsonPropertyName("number")]
    public int Number { get; set; }

    [JsonPropertyName("size")]
    public int Size { get; set; }

    [JsonPropertyName("numberOfElements")]
    public int NumberOfElements { get; set; }

    [JsonPropertyName("content")]
    public List<Content> Content { get; set; }

    [JsonPropertyName("first")]
    public bool First { get; set; }

    [JsonPropertyName("last")]
    public bool Last { get; set; }

    [JsonPropertyName("totalPages")]
    public int TotalPages { get; set; }

    [JsonPropertyName("totalElements")]
    public int TotalElements { get; set; }
}


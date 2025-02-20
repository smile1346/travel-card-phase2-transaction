using System.Text.Json.Serialization;

namespace GetTransactionHistoryResponse;

public class Content
{
    [JsonPropertyName("merchantId")]
    public object MerchantId { get; set; }

    [JsonPropertyName("customerId")]
    public object CustomerId { get; set; }

    [JsonPropertyName("nfcTagId")]
    public object NfcTagId { get; set; }

    [JsonPropertyName("terminalId")]
    public string TerminalId { get; set; }

    [JsonPropertyName("contactMsisdn")]
    public object ContactMsisdn { get; set; }

    [JsonPropertyName("paymentType")]
    public string PaymentType { get; set; }

    [JsonPropertyName("status")]
    public object Status { get; set; }

    [JsonPropertyName("message")]
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

    [JsonPropertyName("externalReference")]
    public string ExternalReference { get; set; }

    [JsonPropertyName("sourceRef")]
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
    public string WorkingCurrencyUnit { get; set; }

    [JsonPropertyName("workingCurrencySymbol")]
    public string WorkingCurrencySymbol { get; set; }

    [JsonPropertyName("destinationCurrencyUnit")]
    public object DestinationCurrencyUnit { get; set; }

    [JsonPropertyName("destinationCurrencySymbol")]
    public object DestinationCurrencySymbol { get; set; }

    [JsonPropertyName("txType")]
    public string TxType { get; set; }

    [JsonPropertyName("transactionTypeCode")]
    public string TransactionTypeCode { get; set; }

    [JsonPropertyName("billableEvent")]
    public int BillableEvent { get; set; }

    [JsonPropertyName("billableEvent2")]
    public int BillableEvent2 { get; set; }

    [JsonPropertyName("reversalOriginalTransactionId")]
    public int ReversalOriginalTransactionId { get; set; }

    [JsonPropertyName("transactionId")]
    public string TransactionId { get; set; }

    [JsonPropertyName("utransactionId")]
    public object UtransactionId { get; set; }

    [JsonPropertyName("paymentTrailId")]
    public object PaymentTrailId { get; set; }

    [JsonPropertyName("originCode")]
    public string OriginCode { get; set; }

    [JsonPropertyName("destinationCode")]
    public string DestinationCode { get; set; }

    [JsonPropertyName("creditName")]
    public string CreditName { get; set; }

    [JsonPropertyName("debitName")]
    public string DebitName { get; set; }

    [JsonPropertyName("date")]
    public object Date { get; set; }

    [JsonPropertyName("receiptAdditionalDetails")]
    public object ReceiptAdditionalDetails { get; set; }

    [JsonPropertyName("salesId")]
    public int SalesId { get; set; }

    [JsonPropertyName("latitude")]
    public double Latitude { get; set; }

    [JsonPropertyName("longitude")]
    public double Longitude { get; set; }

    [JsonPropertyName("productId")]
    public string ProductId { get; set; }

    [JsonPropertyName("billerId")]
    public string BillerId { get; set; }

    [JsonPropertyName("pylId")]
    public int? PylId { get; set; }

    [JsonPropertyName("paymentModeId")]
    public object PaymentModeId { get; set; }

    [JsonPropertyName("sourceAcctId")]
    public int SourceAcctId { get; set; }

    [JsonPropertyName("relatedAcctId")]
    public int RelatedAcctId { get; set; }

    [JsonPropertyName("billReference")]
    public string BillReference { get; set; }

    [JsonPropertyName("reverseReferenceId")]
    public object ReverseReferenceId { get; set; }

    [JsonPropertyName("bplId")]
    public int? BplId { get; set; }

    [JsonPropertyName("transactionCCNumber")]
    public object TransactionCCNumber { get; set; }

    [JsonPropertyName("externalAccount")]
    public object ExternalAccount { get; set; }

    [JsonPropertyName("additionalDetails")]
    public dynamic AdditionalDetails { get; set; }

    [JsonPropertyName("openDate")]
    public object OpenDate { get; set; }

    [JsonPropertyName("approvalCode")]
    public object ApprovalCode { get; set; }

    [JsonPropertyName("blncid")]
    public int Blncid { get; set; }
}

public class Pageable
{
    [JsonPropertyName("pageNumber")]
    public int PageNumber { get; set; }

    [JsonPropertyName("pageSize")]
    public int PageSize { get; set; }

    [JsonPropertyName("sort")]
    public List<Sort> Sort { get; set; }

    [JsonPropertyName("offset")]
    public int Offset { get; set; }

    [JsonPropertyName("paged")]
    public bool Paged { get; set; }

    [JsonPropertyName("unpaged")]
    public bool Unpaged { get; set; }
}

public class Root
{
    [JsonPropertyName("content")]
    public List<Content> Content { get; set; }

    [JsonPropertyName("pageable")]
    public Pageable Pageable { get; set; }

    [JsonPropertyName("last")]
    public bool Last { get; set; }

    [JsonPropertyName("totalElements")]
    public int TotalElements { get; set; }

    [JsonPropertyName("totalPages")]
    public int TotalPages { get; set; }

    [JsonPropertyName("first")]
    public bool First { get; set; }

    [JsonPropertyName("size")]
    public int Size { get; set; }

    [JsonPropertyName("number")]
    public int Number { get; set; }

    [JsonPropertyName("sort")]
    public List<Sort> Sort { get; set; }

    [JsonPropertyName("numberOfElements")]
    public int NumberOfElements { get; set; }

    [JsonPropertyName("empty")]
    public bool Empty { get; set; }
}

public class Sort
{
    [JsonPropertyName("direction")]
    public string Direction { get; set; }

    [JsonPropertyName("property")]
    public string Property { get; set; }

    [JsonPropertyName("ignoreCase")]
    public bool IgnoreCase { get; set; }

    [JsonPropertyName("nullHandling")]
    public string NullHandling { get; set; }

    [JsonPropertyName("ascending")]
    public bool Ascending { get; set; }

    [JsonPropertyName("descending")]
    public bool Descending { get; set; }
}


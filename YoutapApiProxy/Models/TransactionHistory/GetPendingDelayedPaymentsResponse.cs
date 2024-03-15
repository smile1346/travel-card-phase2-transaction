using System.Text.Json.Serialization;

namespace GetPendingDelayedPaymentsResponseModel;

// Root myDeserializedClass = JsonSerializer.Deserialize<List<Root>>(myJsonResponse);
public class AdditionalValues
{
    [JsonPropertyName("close")]
    public string Close { get; set; }

    [JsonPropertyName("custId")]
    public string CustId { get; set; }

    [JsonPropertyName("externalFromAccount")]
    public string ExternalFromAccount { get; set; }

    [JsonPropertyName("productType")]
    public string ProductType { get; set; }

    [JsonPropertyName("productTypeId")]
    public string ProductTypeId { get; set; }
}

public class DelayedPaymentRequest
{
    [JsonPropertyName("delayedTransactionId")]
    public int DelayedTransactionId { get; set; }

    [JsonPropertyName("mmTransferRequest")]
    public MmTransferRequest MmTransferRequest { get; set; }

    [JsonPropertyName("paymentRequest")]
    public PaymentRequest PaymentRequest { get; set; }
}

public class MmTransferRequest
{
    [JsonPropertyName("additionalValues")]
    public AdditionalValues AdditionalValues { get; set; }

    [JsonPropertyName("custReference")]
    public string CustReference { get; set; }

    [JsonPropertyName("destination")]
    public string Destination { get; set; }

    [JsonPropertyName("direction")]
    public object Direction { get; set; }

    [JsonPropertyName("inputValues")]
    public object InputValues { get; set; }

    [JsonPropertyName("origin")]
    public string Origin { get; set; }

    [JsonPropertyName("paymentRequest")]
    public PaymentRequest PaymentRequest { get; set; }

    [JsonPropertyName("pin")]
    public object Pin { get; set; }

    [JsonPropertyName("transactionId")]
    public object TransactionId { get; set; }

    [JsonPropertyName("transferCode")]
    public TransferCode TransferCode { get; set; }

    [JsonPropertyName("voluntaryDelay")]
    public object VoluntaryDelay { get; set; }
}

public class PaymentRequest
{
    [JsonPropertyName("MerchantAccountId")]
    public int MerchantAccountId { get; set; }

    [JsonPropertyName("Method")]
    public int Method { get; set; }

    [JsonPropertyName("amount")]
    public int Amount { get; set; }

    [JsonPropertyName("approvalCode")]
    public object ApprovalCode { get; set; }

    [JsonPropertyName("balanceCategory")]
    public object BalanceCategory { get; set; }

    [JsonPropertyName("balanceType")]
    public int BalanceType { get; set; }

    [JsonPropertyName("balanceTypeCode")]
    public object BalanceTypeCode { get; set; }

    [JsonPropertyName("billReference")]
    public object BillReference { get; set; }

    [JsonPropertyName("billerProviderId")]
    public object BillerProviderId { get; set; }

    [JsonPropertyName("billerProviderProductId")]
    public object BillerProviderProductId { get; set; }

    [JsonPropertyName("creditName")]
    public string CreditName { get; set; }

    [JsonPropertyName("currency")]
    public string Currency { get; set; }

    [JsonPropertyName("debitName")]
    public string DebitName { get; set; }

    [JsonPropertyName("destinationCode")]
    public object DestinationCode { get; set; }

    [JsonPropertyName("extSession")]
    public string ExtSession { get; set; }

    [JsonPropertyName("externalAccount")]
    public object ExternalAccount { get; set; }

    [JsonPropertyName("fromAccountId")]
    public int FromAccountId { get; set; }

    [JsonPropertyName("fromMsisdn")]
    public object FromMsisdn { get; set; }

    [JsonPropertyName("geolocationId")]
    public int GeolocationId { get; set; }

    [JsonPropertyName("latitude")]
    public double Latitude { get; set; }

    [JsonPropertyName("longitude")]
    public double Longitude { get; set; }

    [JsonPropertyName("merchantMsisdn")]
    public object MerchantMsisdn { get; set; }

    [JsonPropertyName("originCode")]
    public object OriginCode { get; set; }

    [JsonPropertyName("patternFrom")]
    public string PatternFrom { get; set; }

    [JsonPropertyName("patternOptional")]
    public string PatternOptional { get; set; }

    [JsonPropertyName("patternTo")]
    public string PatternTo { get; set; }

    [JsonPropertyName("paymentModeId")]
    public object PaymentModeId { get; set; }

    [JsonPropertyName("paymentType")]
    public int PaymentType { get; set; }

    [JsonPropertyName("paymentTypeCode")]
    public object PaymentTypeCode { get; set; }

    [JsonPropertyName("reservationUpdate")]
    public bool ReservationUpdate { get; set; }

    [JsonPropertyName("revBevtid1")]
    public object RevBevtid1 { get; set; }

    [JsonPropertyName("revCrTxnlid")]
    public object RevCrTxnlid { get; set; }

    [JsonPropertyName("revDrTxnlid")]
    public object RevDrTxnlid { get; set; }

    [JsonPropertyName("revFees")]
    public object RevFees { get; set; }

    [JsonPropertyName("saleId")]
    public object SaleId { get; set; }

    [JsonPropertyName("sourceRef")]
    public string SourceRef { get; set; }

    [JsonPropertyName("terminalId")]
    public object TerminalId { get; set; }

    [JsonPropertyName("timeZoneId")]
    public int TimeZoneId { get; set; }

    [JsonPropertyName("toAccountId")]
    public int ToAccountId { get; set; }

    [JsonPropertyName("toMsisdn")]
    public object ToMsisdn { get; set; }

    [JsonPropertyName("transReqRef")]
    public string TransReqRef { get; set; }

    [JsonPropertyName("txnEnd")]
    public long TxnEnd { get; set; }

    [JsonPropertyName("txnNotes")]
    public string TxnNotes { get; set; }

    [JsonPropertyName("txnStart")]
    public long TxnStart { get; set; }

    [JsonPropertyName("txnlCCNumber")]
    public object TxnlCCNumber { get; set; }
}

public class Root
{
    [JsonPropertyName("delayedPaymentRequest")]
    public DelayedPaymentRequest DelayedPaymentRequest { get; set; }

    [JsonPropertyName("dueDate")]
    public string DueDate { get; set; }

    [JsonPropertyName("endDate")]
    public string EndDate { get; set; }

    [JsonPropertyName("frequency")]
    public string Frequency { get; set; }
}

public class TransferCode
{
    [JsonPropertyName("destinationCode")]
    public string DestinationCode { get; set; }

    [JsonPropertyName("javaName")]
    public string JavaName { get; set; }

    [JsonPropertyName("originCode")]
    public string OriginCode { get; set; }
}


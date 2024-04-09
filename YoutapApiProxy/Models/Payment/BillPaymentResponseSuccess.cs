using System.Text.Json.Serialization;
using Swashbuckle.AspNetCore.Annotations;

namespace BillPaymentResponseSuccessModel;
// Root myDeserializedClass = JsonSerializer.Deserialize<Root>(myJsonResponse);
// public class Additional
// {
//     [JsonPropertyName("Account Name")]
//     public string AccountName { get; set; }

//     [JsonPropertyName("Bank Account")]
//     public string BankAccount { get; set; }

//     [JsonPropertyName("Code")]
//     public string Code { get; set; }

//     [JsonPropertyName("Particulars")]
//     public string Particulars { get; set; }

//     [JsonPropertyName("Reference")]
//     public string Reference { get; set; }

//     [JsonPropertyName("billDate")]
//     public DateTime BillDate { get; set; }

//     [JsonPropertyName("billerIdentifier")]
//     public string BillerIdentifier { get; set; }

//     [JsonPropertyName("billerName")]
//     public string BillerName { get; set; }

//     [JsonPropertyName("billerType")]
//     public string BillerType { get; set; }

//     [JsonPropertyName("customerPhoneNumber")]
//     public string CustomerPhoneNumber { get; set; }

//     [JsonPropertyName("merchantAccountId")]
//     public string MerchantAccountId { get; set; }

//     [JsonPropertyName("payerName")]
//     public string PayerName { get; set; }

//     [JsonPropertyName("productId")]
//     public string ProductId { get; set; }

//     [JsonPropertyName("productName")]
//     public string ProductName { get; set; }

//     [JsonPropertyName("productTypeCode")]
//     public string ProductTypeCode { get; set; }

//     [JsonPropertyName("subProductId")]
//     public string SubProductId { get; set; }

//     [JsonPropertyName("subProductName")]
//     public string SubProductName { get; set; }

//     [JsonPropertyName("subscriptionCode")]
//     public string SubscriptionCode { get; set; }
// }

public class CouponAmount
{
    [JsonPropertyName("amount")]
    public int Amount { get; set; }

    [JsonPropertyName("currency")]
    public string Currency { get; set; }
}

public class Fee
{
    [JsonPropertyName("toFee")]
    public ToFromFee ToFee { get; set; }

    [JsonPropertyName("fromFee")]
    public ToFromFee FromFee { get; set; }
}

// public class FromFee
// {
//     [JsonPropertyName("amount")]
//     public int Amount { get; set; }

//     [JsonPropertyName("currency")]
//     public string Currency { get; set; }
// }

public class Root
{
    [JsonPropertyName("status")]
    [SwaggerSchema("Transaction status\n\n0 = Success, otherwise return HTTP status code")]
    public int Status { get; set; }

    [JsonPropertyName("error")]
    public object Error { get; set; }

    [JsonPropertyName("toTransactionId")]
    [SwaggerSchema("Transaction No. Same as the transactionId return in the transaction history API")]
    public int ToTransactionId { get; set; }

    [JsonPropertyName("fromTransactionId")]
    public int FromTransactionId { get; set; }

    [JsonPropertyName("fee")]
    public Fee Fee { get; set; }

    [JsonPropertyName("couponAmount")]
    public CouponAmount CouponAmount { get; set; }

    [JsonPropertyName("additional")]
    public object Additional { get; set; }
}

public class ToFromFee
{
    [JsonPropertyName("amount")]
    public int Amount { get; set; }

    [JsonPropertyName("currency")]
    public string Currency { get; set; }
}


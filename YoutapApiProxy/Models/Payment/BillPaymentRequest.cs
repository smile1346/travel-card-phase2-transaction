using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BillPaymentRequestModel;

public class Coupon
{
    [JsonPropertyName("couponCode")]
    public object CouponCode { get; set; }

    [JsonPropertyName("merchantPartnerId")]
    public object MerchantPartnerId { get; set; }
}

public class GeoLocation
{
    [JsonPropertyName("latitude")]
    public double Latitude { get; set; }

    [JsonPropertyName("longitude")]
    public double Longitude { get; set; }
}

public class InputValues
{
    [JsonPropertyName("Bank Account")]
    public string BankAccount { get; set; }

    [JsonPropertyName("Account Name")]
    public string AccountName { get; set; }

    [JsonPropertyName("Code")]
    public string Code { get; set; }

    [JsonPropertyName("Reference")]
    public string Reference { get; set; }

    [JsonPropertyName("Particulars")]
    public string Particulars { get; set; }
}

public class ProductTypeInfo
{
    [JsonPropertyName("Bank Account")]
    public string BankAccount { get; set; }

    [JsonPropertyName("Account Name")]
    public string AccountName { get; set; }

    [JsonPropertyName("Code")]
    public string Code { get; set; }

    [JsonPropertyName("Reference")]
    public string Reference { get; set; }

    [JsonPropertyName("Particulars")]
    public string Particulars { get; set; }

    [JsonPropertyName("subscriptionCode")]
    public string SubscriptionCode { get; set; }

    [JsonPropertyName("subProductName")]
    public string SubProductName { get; set; }

    [JsonPropertyName("subProductId")]
    public string SubProductId { get; set; }

    [JsonPropertyName("billerType")]
    public int BillerType { get; set; }

    [JsonPropertyName("customerPhoneNumber")]
    public string CustomerPhoneNumber { get; set; }

    [JsonPropertyName("productTypeCode")]
    public object ProductTypeCode { get; set; }
}

public class Root
{
    [JsonPropertyName("billerIdentifier")]
    [Required]
    public int BillerIdentifier { get; set; }

    [JsonPropertyName("externalBillerIdentifier")]
    public string ExternalBillerIdentifier { get; set; }

    [JsonPropertyName("productId")]
    [Required]
    public string ProductId { get; set; }

    [JsonPropertyName("value")]
    [Required]
    public Value Value { get; set; }

    [JsonPropertyName("merchantId")]
    public string MerchantId { get; set; }

    [JsonPropertyName("fromMsisdn")]
    public string FromMsisdn { get; set; }

    [JsonPropertyName("fromPin")]
    public string FromPin { get; set; }

    [JsonPropertyName("productTypeInfo")]
    public ProductTypeInfo ProductTypeInfo { get; set; }

    [JsonPropertyName("inputValues")]
    public InputValues InputValues { get; set; }

    [JsonPropertyName("geoLocation")]
    public GeoLocation GeoLocation { get; set; }

    [JsonPropertyName("coupon")]
    public Coupon Coupon { get; set; }

    [JsonPropertyName("originalAmount")]
    public double OriginalAmount { get; set; }

    [JsonPropertyName("notes")]
    public string Notes { get; set; }

    [JsonPropertyName("voluntaryDelay")]
    public int VoluntaryDelay { get; set; }
}

public class Value
{
    [JsonPropertyName("currency")]
    [Required]
    public string Currency { get; set; }

    [JsonPropertyName("amount")]
    [Required]
    public decimal Amount { get; set; }
}


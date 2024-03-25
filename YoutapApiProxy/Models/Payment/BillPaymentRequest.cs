using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Swashbuckle.AspNetCore.Annotations;

namespace BillPaymentRequestModel;

public class Coupon
{
    [JsonPropertyName("couponCode")]
    public object CouponCode { get; set; }

    [JsonPropertyName("merchantPartnerId")]
    public object MerchantPartnerId { get; set; }
}

[SwaggerSchema("Can record location of transaction")]
public class GeoLocation
{
    [JsonPropertyName("latitude")]
    public double Latitude { get; set; }

    [JsonPropertyName("longitude")]
    public double Longitude { get; set; }
}

[SwaggerSchema("Values provided by customer. These fields are configurable from admin portal.")]
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

[SwaggerSchema("information passed to biller for processing. These fields are configurable from admin portal.")]
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
    [SwaggerSchema("Id for biller from Biller Providers")]
    public int BillerIdentifier { get; set; }

    // [JsonPropertyName("externalBillerIdentifier")]
    // public string ExternalBillerIdentifier { get; set; }

    [JsonPropertyName("productId")]
    [Required]
    [SwaggerSchema("Code for product from Biller Providers")]
    public string ProductId { get; set; }

    [JsonPropertyName("value")]
    [Required]
    public Value Value { get; set; }

    // [JsonPropertyName("merchantId")]
    // public string MerchantId { get; set; }

    [JsonPropertyName("fromMsisdn")]
    [Required]
    [SwaggerSchema("Phone number as identifier of the customer")]
    public string FromMsisdn { get; set; }

    [JsonPropertyName("fromPin")]
    [SwaggerSchema("Pin for customer to authorize")]
    public string FromPin { get; set; }

    [JsonPropertyName("productTypeInfo")]
    [SwaggerSchema("information passed to biller for processing. These fields are configurable from admin portal.")]
    public object ProductTypeInfo { get; set; }

    [JsonPropertyName("inputValues")]
    [SwaggerSchema("Values provided by customer. These fields are configurable from admin portal.")]
    public object InputValues { get; set; }

    [JsonPropertyName("geoLocation")]
    public GeoLocation GeoLocation { get; set; }

    // [JsonPropertyName("coupon")]
    // public Coupon Coupon { get; set; }

    // [JsonPropertyName("originalAmount")]
    // public double OriginalAmount { get; set; }

    [JsonPropertyName("notes")]
    [SwaggerSchema("Allow notes to be stored against transaction (50 character limit)")]
    public string Notes { get; set; }

    // [JsonPropertyName("voluntaryDelay")]
    // public int VoluntaryDelay { get; set; }
}

[SwaggerSchema("Money. Iso currecy code and BigDecimal amount")]
public class Value
{
    [JsonPropertyName("currency")]
    [Required]
    public string Currency { get; set; }

    [JsonPropertyName("amount")]
    [Required]
    public decimal Amount { get; set; }
}


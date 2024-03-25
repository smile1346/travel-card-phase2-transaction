using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Swashbuckle.AspNetCore.Annotations;

namespace KYCRegistrationRequestModel;

public class CustomerAddress
{
    [JsonPropertyName("addLine1")]
    public string AddLine1 { get; set; }

    [JsonPropertyName("country")]
    public string Country { get; set; }
}

[SwaggerSchema("The collection of primary contact details for the customer such as name and address.")]
public class CustomerContact
{
    [JsonPropertyName("addLine1")]
    public string AddLine1 { get; set; }

    [JsonPropertyName("addLine2")]
    public string AddLine2 { get; set; }

    [JsonPropertyName("addLine3")]
    public string AddLine3 { get; set; }

    [JsonPropertyName("addLine4")]
    public string AddLine4 { get; set; }

    [JsonPropertyName("addressType")]
    [SwaggerSchema("Type of address associated with a customer's profile. Possible value: “Business” for business / office address or “Home” for personal address.")]
    public string AddressType { get; set; }

    [JsonPropertyName("city")]
    public string City { get; set; }

    [JsonPropertyName("country")]
    public string Country { get; set; }

    [JsonPropertyName("dob")]
    public object Dob { get; set; }

    [JsonPropertyName("email1")]
    public string Email1 { get; set; }

    [JsonPropertyName("firstName")]
    public string FirstName { get; set; }

    [JsonPropertyName("gender")]
    public object Gender { get; set; }

    [JsonPropertyName("lastName")]
    public string LastName { get; set; }

    [JsonPropertyName("latitude")]
    public double Latitude { get; set; }

    [JsonPropertyName("longitude")]
    public double Longitude { get; set; }

    [JsonPropertyName("nationality")]
    public object Nationality { get; set; }

    [JsonPropertyName("postalCode")]
    public string PostalCode { get; set; }

    [JsonPropertyName("primary")]
    public bool Primary { get; set; }

    [JsonPropertyName("referralCode")]
    public string ReferralCode { get; set; }

    [JsonPropertyName("state")]
    public string State { get; set; }
}

public class CustomerIdentifierDTO
{
    [JsonPropertyName("customerId")]
    public int CustomerId { get; set; }

    [JsonPropertyName("identifierId")]
    [SwaggerSchema("Type of customer identifier. Possible value: 31 for referral phone number.")]
    public int IdentifierId { get; set; }

    [JsonPropertyName("value")]
    public string Value { get; set; }
}

public class Root
{
    // [JsonPropertyName("walletProviderId")]
    // [Required]
    // public string WalletProviderId { get; set; }

    [JsonPropertyName("customerAddresses")]
    [SwaggerSchema("A list of additional addresses that may be used by the customer such as billing or delivery.")]
    public List<CustomerAddress> CustomerAddresses { get; set; }

    [JsonPropertyName("customerContact")]
    public CustomerContact CustomerContact { get; set; }

    [JsonPropertyName("customerIdentifierDTO")]
    [SwaggerSchema("A list of objects for official identification documents such as driver's license or passport.")]
    public List<CustomerIdentifierDTO> CustomerIdentifierDTO { get; set; }

    [JsonPropertyName("mobileNumber")]
    [Required]
    [SwaggerSchema("**Example: 64272448805.** The customer's mobile phone number consists of 11 digits, with the first 2 digits representing the country code, followed by the phone number of 9 digits. This is the primary identifier of the customer. ")]
    public string MobileNumber { get; set; }

    [JsonPropertyName("otp")]
    // [Required]
    [SwaggerSchema("**Example: 13678.** An OTP to validate an unrecognised device.")]
    public string Otp { get; set; }

    [JsonPropertyName("pin")]
    // [Required]
    [SwaggerSchema("**Example: 13345.** The customer's PIN")]
    public string Pin { get; set; }
}


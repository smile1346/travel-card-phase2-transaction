using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Swashbuckle.AspNetCore.Annotations;

namespace PatchCustomerModel;

// Root myDeserializedClass = JsonSerializer.Deserialize<Root>(myJsonResponse);
[SwaggerSchema("The collection of primary contact details for the custommer such as name and address.")]
public class CustomerContact
{
    [JsonPropertyName("addLine1")]
    public string AddLine1 { get; set; }

    [JsonPropertyName("addLine2")]
    public string AddLine2 { get; set; }

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

public class Root
{
    [JsonPropertyName("customerId")]
    [Required]
    public string CustomerId { get; set; }

    [JsonPropertyName("customerContact")]
    [Required]
    public CustomerContact CustomerContact { get; set; }

    [JsonPropertyName("customerIdentifierDTO")]
    [SwaggerSchema("Values for official identification documents such as driver's license or passport. The identifier IDs come from Customer Identifier Types")]
    public List<CustomerIdentifierDTO> CustomerIdentifierDTO { get; set; }

    [JsonPropertyName("pin")]
    [Required]
    [SwaggerSchema("The customer's PIN")]
    public string PIN { get; set; }

    [JsonPropertyName("otp")]
    [SwaggerSchema("An OTP to validate an unrecognised device, required when a new device is detected.")]
    public string OTP { get; set; }

    [JsonPropertyName("customerAddresses")]
    [SwaggerSchema("A list of additional addresses that may be used by the customer such as billing or delivery.")]
    public List<CustomerAddress> CustomerAddresses { get; set; }
}

public class CustomerIdentifierDTO
{
    [JsonPropertyName("customerId")]
    public int CustomerId { get; set; }

    [JsonPropertyName("identifierId")]
    public int IdentifierId { get; set; }

    [JsonPropertyName("value")]
    public string Value { get; set; }
}

public class CustomerAddress
{
    [JsonPropertyName("addLine1")]
    public string AddLine1 { get; set; }

    [JsonPropertyName("country")]
    public string Country { get; set; }
}

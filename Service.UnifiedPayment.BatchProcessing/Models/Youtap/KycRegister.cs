using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.Json.Serialization;
namespace ModelsYoutap;

public struct CustomerInfo
{
    [DefaultValue("phone_number")]
    [JsonPropertyName("mobileNumber")]
    public string MobileNumber { get; set; }

    [DefaultValue("Business")]
    [JsonPropertyName("customerContact")]
    public CustomerContactInfo CustomerContact { get; set; }

    [JsonPropertyName("customerIdentifierDTO")]
    public List<CustomerIdentifierDTO> CustomerIdentifierDTO { get; set; }

    [DefaultValue("112233")]
    public string Pin { get; set; }

    [DefaultValue("010203")]
    public string Otp { get; set; }

    [JsonPropertyName("customerAddresses")]
    public List<CustomerAddress> CustomerAddresses { get; set; }
}

public struct CustomerContactInfo
{
    [DefaultValue("Business")]
    [JsonPropertyName("addressType")]
    public string AddressType { get; set; }

    [DefaultValue("street")]
    [JsonPropertyName("addLine1")]
    public string AddLine1 { get; set; }

    [DefaultValue("line2")]
    [JsonPropertyName("addLine2")]
    public string AddLine2 { get; set; }

    [DefaultValue("Nyaungdon")]
    [JsonPropertyName("addLine3")]
    public string AddLine3 { get; set; }

    [DefaultValue("line4")]
    [JsonPropertyName("addLine4")]
    public string AddLine4 { get; set; }

    [DefaultValue("Maubin")]
    public string City { get; set; }

    [DefaultValue("MM")]
    public string Country { get; set; }

    [DefaultValue(null)]
    public DateTime? Dob { get; set; }

    [DefaultValue("[email]")]
    [JsonPropertyName("email1")]
    public string Email1 { get; set; }

    [DefaultValue("John")]
    [JsonPropertyName("firstName")]
    public string FirstName { get; set; }

    [DefaultValue("Smith")]
    [JsonPropertyName("lastName")]
    public string LastName { get; set; }

    [DefaultValue(null)]
    public string Gender { get; set; }

    [DefaultValue("")]
    [JsonPropertyName("postalCode")]
    public string PostalCode { get; set; }

    [DefaultValue(true)]
    public bool Primary { get; set; }

    [DefaultValue("Ayeyarwady")]
    public string State { get; set; }

    [DefaultValue("")]
    [JsonPropertyName("referralCode")]
    public string ReferralCode { get; set; }

    [DefaultValue(-36.8474976)]
    public double Latitude { get; set; }

    [DefaultValue(174.7685493)]
    public double Longitude { get; set; }

    [DefaultValue(null)]
    public string Nationality { get; set; }
}

public struct CustomerIdentifierDTO
{
    [DefaultValue(0)]
    [JsonPropertyName("customerId")]
    public int CustomerId { get; set; }

    [DefaultValue(31)]
    [JsonPropertyName("identifierId")]
    public int IdentifierId { get; set; }

    [DefaultValue("aaa6L9BiD")]
    public string Value { get; set; }
}

public struct CustomerAddress
{
    [JsonPropertyName("addLine1")]
    public string AddLine1 { get; set; }

    [DefaultValue("Wales")]
    public string Country { get; set; }
}

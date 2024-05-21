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
    [SwaggerSchema("Date of birth in `yyyy-MM-dd` format")]
    public string Dob { get; set; }

    [JsonPropertyName("email1")]
    public string Email1 { get; set; }

    [JsonPropertyName("firstName")]
    [Required]
    public string FirstName { get; set; }

    [JsonPropertyName("gender")]
    [SwaggerSchema("M = Male, F = Female, NA = Not Specified")]
    public string Gender { get; set; }

    [JsonPropertyName("lastName")]
    [Required]
    public string LastName { get; set; }

    [JsonPropertyName("latitude")]
    public double Latitude { get; set; }

    [JsonPropertyName("longitude")]
    public double Longitude { get; set; }

    [JsonPropertyName("nationality")]
    public string Nationality { get; set; }

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
    // [SwaggerSchema("Type of customer identifier. Possible value: 31 for referral phone number.")]
    [SwaggerSchema(@"| ID | Description | Code | Type |
|-----|-------------|------|------|
| 1   | Passport    | PASS | TEXT |
| 2   | Drivers Licence | DRIV | TEXT |
| 4   | National ID | NATI | TEXT |
| 5   | Organization | ORG  | TEXT |
| 6   | Selfie | IMAGEO | IMAGE |
| 7   | Employment ID | EMID | TEXT |
| 8   | Social ID | WELF | TEXT |
| 9   | Social Card Image | SOCRD | IMAGE |
| 10  | Signature | SIGNT | IMAGE |
| 11  | Other | OTHER | IMAGE |
| 12  | Mothers Maiden Name | MMN  | TEXT |
| 13  | Birth Place | BTHPL | TEXT |
| 14  | Other ID | OTHID | TEXT |
| 16  | Passport Image | PSSPT | IMAGE |
| 17  | Drivers License Image | DRLIC | IMAGE |
| 18  | National ID Image | NATIM | IMAGE |
| 19  | Voter ID | VOTID | TEXT |
| 20  | GSIS/SSS | GSIS | TEXT |
| 21  | Tax ID No | TIN | TEXT |
| 22  | Business Registration ID | BREGO | TEXT |
| 23  | Secretary Cert | SCERT | TEXT |
| 24  | Voter ID Image | VOTIM | IMAGE |
| 25  | GSIS/SSS Image | GSISS | IMAGE |
| 26  | Tax ID Image | TAXIM | IMAGE |
| 27  | Province | PROV | TEXT |
| 28  | Barangay | BARA | TEXT |
| 29  | Postcode | POST | TEXT |
| 30  | First School | SCHO | TEXT |
| 31  | Referral Phone Number | REFN | TEXT |
| 32  | On Behalf of | OBHO | TEXT |
| 33  | Bank Name | BANK | TEXT |
| 35  | Bank Short Code | BCODE | TEXT |
| 41  | Security IMAGE | SECPH | IMAGE |
| 42  | Proof of Address | PROFA | IMAGE |
| 43  | Proof of Income | PROFI | IMAGE |
| 44  | Source of Funds | SRCFU | TEXT |
| 48  | Business Picture | BSPIC | IMAGE |
| 52  | Social Card Image Back | SOCBK | IMAGE |
| 53  | Other Id Image Back | OTHBK | IMAGE |
| 55  | Drivers Image Back | DRLBK | IMAGE |
| 56  | National Id Image Back | NATBK | IMAGE |
| 57  | Voter Id Image Back | VOTBK | IMAGE |
| 58  | GSIS/SSS Image Back | GSIBK | IMAGE |
| 59  | Tax ID Image Back | TAXBK | IMAGE |
| 60  | Visa Image | VISA | IMAGE |
| 61  | Visa ID | VSAID | TEXT |
| 62  | Business Registration Image | BREIM | IMAGE |
| 64  | Drivers Licence Version | DRIVV | TEXT |
| 65  | Trading Name | TRDNM | TEXT |
| 66  | Bank Verification No | BVNO | TEXT |
| 67  | Business Registration Image 2 | BREI2 | IMAGE |
| 68  | Employer Name | EMPRN | TEXT |
| 80  | Marital Status | MARST | TEXT |
| 81  | Number of Children | NCHLD | TEXT |
| 83  | Account Manager | ACCMG | TEXT |
| 85  | Profile Pic | PRFLP | IMAGE |")]
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
    [Required]
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

    [JsonPropertyName("mobMonPin")]
    // [Required]
    [SwaggerSchema("**Example: 13345.** The customer's PIN")]
    public string MobMonPin { get; set; }

    [JsonPropertyName("type")]
    [Required]
    [SwaggerSchema(@"| Account Type (DB Code)| Description |
|-----|-----|
| MCHNT   | Merchant   |
| MWLT   | Mobile Wallet   |
| OPRT   | Operator   |
| BUSI   | Business   |
| PURSE   | Purse   |
| SINGL   | Single-use   |")]
    public string Type { get; set; }
}


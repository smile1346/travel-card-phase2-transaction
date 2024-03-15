
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Swashbuckle.AspNetCore.Annotations;

namespace KYCConfirmationModel;

public class Root
{
    [JsonPropertyName("mobileNumber")]
    [Required]
    [SwaggerSchema("**Example: 64272448805.** The customer's mobile phone number. This is the primary identifier of the customer.")]
    public string MobileNumber { get; set; }

    [JsonPropertyName("terminalId")]
    [Required]
    [SwaggerSchema("**Example: 8af8770a27cfd182 (Android), 7946DA4E-8429-423C-B405-B3FC77914E3E (iOS).** The device identifier to be associated with the OTP. When the customer uses the same msisdn with a different device it will require another OTP.")]
    public string TerminalId { get; set; }
}
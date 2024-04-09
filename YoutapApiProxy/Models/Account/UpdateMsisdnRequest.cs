using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Swashbuckle.AspNetCore.Annotations;

namespace UpdateMsisdnRequestModel;
public class Root
{
    [JsonPropertyName("oldMsisdn")]
    [Required]
    [SwaggerSchema("The old mobile number\n\nFormat: Country code + Mobile Number (remove leading zero)")]
    public string OldMsisdn { get; set; }

    [JsonPropertyName("newMsisdn")]
    [Required]
    [SwaggerSchema("The new mobile number\n\nFormat: Country code + Mobile Number (remove leading zero)")]
    public string NewMsisdn { get; set; }
}


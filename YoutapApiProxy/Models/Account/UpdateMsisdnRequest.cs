using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace UpdateMsisdnRequestModel;
public class Root
{
    [JsonPropertyName("oldMsisdn")]
    [Required]
    public string OldMsisdn { get; set; }

    [JsonPropertyName("newMsisdn")]
    [Required]
    public string NewMsisdn { get; set; }
}


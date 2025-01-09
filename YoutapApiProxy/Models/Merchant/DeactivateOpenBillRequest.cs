using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DeactivateOpenBillRequest;
public class Root
{
    [Required]
    [JsonPropertyName("billReference")]
    public string BillReference { get; set; }
}
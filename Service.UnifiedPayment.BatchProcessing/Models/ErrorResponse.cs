using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace ErrorResponse;

[DataContract]
public class Detail
{
    [DataMember(Name = "errorcode")]
    [JsonPropertyName("errorcode")]
    public required string ErrorCode { get; set; }
}

[DataContract]
public class Fault
{
    [DataMember(Name = "faultstring")]
    [JsonPropertyName("faultstring")]
    public required string FaultString { get; set; }

    [DataMember(Name = "detail")]
    [JsonPropertyName("detail")]
    public required Detail Detail { get; set; }
}

[DataContract]
public class Root
{
    [DataMember(Name = "fault")]
    [JsonPropertyName("fault")]
    public required Fault Fault { get; set; }
}


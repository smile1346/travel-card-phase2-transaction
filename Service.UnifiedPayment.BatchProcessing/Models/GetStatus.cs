using System.ComponentModel;
using System.Runtime.Serialization;

[DataContract]
public struct GetStatus
{
    [DataMember(Name = "InitgPty", IsRequired = true)]
    [DefaultValue("473dfdbc-4ec2-4379-bd5e-d7ae08b60c8e")]
    public required string InitgPty { get; set; }

    [DataMember(Name = "EndToEndId", IsRequired = true)]
    [DefaultValue("217o984kd78937")]
    public required string EndToEndId { get; set; }
}

namespace Models;

public class AnyGatewayResponse : AnyGatewayBaseResponse
{
    public string? LookupRef { get; set; }
    public string? BankInvNo { get; set; }
}
public class ConfirmTransferResponse : AnyGatewayBaseResponse
{
    public string? BankInvNo { get; set; }
}
public class AccountValidationResponse : AnyGatewayBaseResponse
{
    public string? LookupRef { get; set; }
}
public class AnyGatewayBaseResponse
{
    public required string ResponseCode { get; set; }
    public required string ResponseMesg { get; set; }

}
namespace Handlers;
using Swashbuckle.AspNetCore.Filters;

public class AccountValidationRequestExamples : IMultipleExamplesProvider<string>
{
    public IEnumerable<SwaggerExample<string>> GetExamples()
    {
        yield return SwaggerExample.Create("Account Validation", File.ReadAllText("examples/AccountValidationRequest.json"));
        yield return SwaggerExample.Create("Confirm Transfer", File.ReadAllText("examples/ConfirmTransferRequest.json"));
    }
}

public class AnyGatewayResponseExamples : IMultipleExamplesProvider<string>
{
    public IEnumerable<SwaggerExample<string>> GetExamples()
    {
        yield return SwaggerExample.Create("Account Validation Success", File.ReadAllText("examples/AccountValidationResponse.json"));
        yield return SwaggerExample.Create("Confirm Transfer Success", File.ReadAllText("examples/ConfirmTransferResponse.json"));
    }
}

public class Camt054Examples : IMultipleExamplesProvider<string>
{
    public IEnumerable<SwaggerExample<string>> GetExamples()
    {
        yield return SwaggerExample.Create("Status: BOOK", File.ReadAllText("examples/camt054.earthport.book.json"));
        yield return SwaggerExample.Create("Status: INFO", File.ReadAllText("examples/camt054.earthport.info.json"));
    }
}

public class InternalServerErrorResponse : IMultipleExamplesProvider<ErrorResponse.Root>
{
    public IEnumerable<SwaggerExample<ErrorResponse.Root>> GetExamples()
    {
        yield return SwaggerExample.Create("Internal Server Error", new ErrorResponse.Root
        {
            Fault = new ErrorResponse.Fault
            {
                FaultString = "We encountered an internal error",
                Detail = new ErrorResponse.Detail
                {
                    ErrorCode = "steps.servicecallout.ExecutionFailed"
                }
            }
        });
    }
}

public class UnauthorizedResponse : IMultipleExamplesProvider<ErrorResponse.Root>
{
    public IEnumerable<SwaggerExample<ErrorResponse.Root>> GetExamples()
    {
        yield return SwaggerExample.Create("Access Token expired", new ErrorResponse.Root
        {
            Fault = new ErrorResponse.Fault
            {
                FaultString = "Access Token expired",
                Detail = new ErrorResponse.Detail
                {
                    ErrorCode = "keymanagement.service.access_token_expired"
                }
            }
        });
    }
}

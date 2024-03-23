namespace Examples;
using Swashbuckle.AspNetCore.Filters;

public class KYCRegistrationPOSTRequestExample : IMultipleExamplesProvider<string>
{
    public IEnumerable<SwaggerExample<string>> GetExamples()
    {
        yield return SwaggerExample.Create("Register", File.ReadAllText("examples/KYCRegistrationPOSTRequest.json"));
    }
}

public class KYCRegistrationPATCHRequestExample : IMultipleExamplesProvider<string>
{
    public IEnumerable<SwaggerExample<string>> GetExamples()
    {
        yield return SwaggerExample.Create("Patch Customer", File.ReadAllText("examples/KYCRegistrationPATCHRequest.json"));
    }
}

public class BillPaymentElectricTrainRequestExample : IMultipleExamplesProvider<string>
{
    public IEnumerable<SwaggerExample<string>> GetExamples()
    {
        yield return SwaggerExample.Create("Electric Train", File.ReadAllText("examples/BillPaymentRequest_ElectricTrain.json"));
        yield return SwaggerExample.Create("BillPayment", File.ReadAllText("examples/BillPaymentRequest.json"));
    }
}

public class BillPaymentRequestExample : IMultipleExamplesProvider<string>
{
    public IEnumerable<SwaggerExample<string>> GetExamples()
    {
        yield return SwaggerExample.Create("BillPayment", File.ReadAllText("examples/BillPaymentRequest.json"));
    }
}


public class CreateAccountRequestExample : IMultipleExamplesProvider<string>
{
    public IEnumerable<SwaggerExample<string>> GetExamples()
    {
        yield return SwaggerExample.Create("Create Account", File.ReadAllText("examples/CreateAccountRequest.json"));
    }
}

public class UpdateAccountRequestExample : IMultipleExamplesProvider<string>
{
    public IEnumerable<SwaggerExample<string>> GetExamples()
    {
        yield return SwaggerExample.Create("Update Account", File.ReadAllText("examples/UpdateAccountRequest.json"));
    }
}

public class GeneralTransactionRequestExample : IMultipleExamplesProvider<string>
{
    public IEnumerable<SwaggerExample<string>> GetExamples()
    {
        yield return SwaggerExample.Create("Deposit", File.ReadAllText("examples/GeneralTransactionDepositRequest.json"));
        yield return SwaggerExample.Create("Withdrawal", File.ReadAllText("examples/GeneralTransactionWithdrawalRequest.json"));
    }
}

public class UpdateMsisdnRequestExample : IMultipleExamplesProvider<string>
{
    public IEnumerable<SwaggerExample<string>> GetExamples()
    {
        yield return SwaggerExample.Create("Update MSISDN", File.ReadAllText("examples/UpdateMsisdnRequest.json"));
    }
}
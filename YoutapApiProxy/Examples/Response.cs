namespace Examples;
using Swashbuckle.AspNetCore.Filters;

public class GetUserInfoResponseExample : IMultipleExamplesProvider<string>
{
    public IEnumerable<SwaggerExample<string>> GetExamples()
    {
        yield return SwaggerExample.Create("Get User Info", File.ReadAllText("examples/GetUserInfoResponse.json"));
    }
}

public class GetUserInfoResponseNotFoundExample : IMultipleExamplesProvider<string>
{
    public IEnumerable<SwaggerExample<string>> GetExamples()
    {
        yield return SwaggerExample.Create("Cannot find account id for msisdn", File.ReadAllText("examples/GetUserInfoResponse_NotFound.json"));
    }
}

public class KYCConfirmationResponseExample : IMultipleExamplesProvider<string>
{
    public IEnumerable<SwaggerExample<string>> GetExamples()
    {
        yield return SwaggerExample.Create("KYC Confirmation", File.ReadAllText("examples/KYCConfirmationResponse.json"));
    }
}

public class BillPaymentResponseSuccessExample : IMultipleExamplesProvider<string>
{
    public IEnumerable<SwaggerExample<string>> GetExamples()
    {
        yield return SwaggerExample.Create("Successful Instant BillPayment", File.ReadAllText("examples/BillPaymentResponse_Successful.json"));
        yield return SwaggerExample.Create("Electric Train", File.ReadAllText("examples/BillPaymentResponse_ElectricTrain.json"));
    }
}

public class BillPaymentResponseDelayedExample : IMultipleExamplesProvider<string>
{
    public IEnumerable<SwaggerExample<string>> GetExamples()
    {
        yield return SwaggerExample.Create("Delayed Payment", File.ReadAllText("examples/BillPaymentResponse_Delayed.json"));
    }
}

public class BillPaymentResponseInsufficientFundsExample : IMultipleExamplesProvider<string>
{
    public IEnumerable<SwaggerExample<string>> GetExamples()
    {
        yield return SwaggerExample.Create("Insufficent Funds", File.ReadAllText("examples/BillPaymentResponse_InsufficientFunds.json"));
    }
}

public class BillPaymentResponseTooManyRequestsExample : IMultipleExamplesProvider<string>
{
    public IEnumerable<SwaggerExample<string>> GetExamples()
    {
        yield return SwaggerExample.Create("Duplicated request", File.ReadAllText("examples/BillPaymentResponse_TooManyRequests.json"));
    }
}

public class GetPendingDelayedPaymentsResponseExample : IMultipleExamplesProvider<string>
{
    public IEnumerable<SwaggerExample<string>> GetExamples()
    {
        yield return SwaggerExample.Create("Get Pending Delayed Payments", File.ReadAllText("examples/GetPendingDelayedPaymentsResponse.json"));
    }
}

public class GetTransactionHistoryResponseExample : IMultipleExamplesProvider<string>
{
    public IEnumerable<SwaggerExample<string>> GetExamples()
    {
        yield return SwaggerExample.Create("Get Transaction History", File.ReadAllText("examples/GetTransactionHistoryResponse.json"));
    }
}

public class GetTransactionLimitsResponseExample : IMultipleExamplesProvider<string>
{
    public IEnumerable<SwaggerExample<string>> GetExamples()
    {
        yield return SwaggerExample.Create("Get fees for everything", File.ReadAllText("examples/GetTransactionLimitsResponse.json"));
    }
}

public class GetAvailableWalletTypesResponseExample : IMultipleExamplesProvider<string>
{
    public IEnumerable<SwaggerExample<string>> GetExamples()
    {
        yield return SwaggerExample.Create("Get Available Wallet Types", File.ReadAllText("examples/GetAvailableWalletTypesResponse.json"));
    }
}

public class GetQuickAccountsResponseExample : IMultipleExamplesProvider<string>
{
    public IEnumerable<SwaggerExample<string>> GetExamples()
    {
        yield return SwaggerExample.Create("Get Quick Accounts", File.ReadAllText("examples/GetQuickAccountsResponse_Current.json"));
    }
}

public class GetSpecificAccountResponseExample : IMultipleExamplesProvider<string>
{
    public IEnumerable<SwaggerExample<string>> GetExamples()
    {
        yield return SwaggerExample.Create("Get Specific Account", File.ReadAllText("examples/GetSpecificAccountResponse.json"));
    }
}

public class CreateAccountResponseSuccessExample : IMultipleExamplesProvider<string>
{
    public IEnumerable<SwaggerExample<string>> GetExamples()
    {
        yield return SwaggerExample.Create("Successful Create Account", File.ReadAllText("examples/CreateAccountResponse_Successful.json"));
    }
}

public class CreateAccountResponseNotFoundExample : IMultipleExamplesProvider<string>
{
    public IEnumerable<SwaggerExample<string>> GetExamples()
    {
        yield return SwaggerExample.Create("Invalid Wallet Type Error", File.ReadAllText("examples/CreateAccountResponse_NotFound.json"));
    }
}

public class UpdateAccountResponseSuccessExample : IMultipleExamplesProvider<string>
{
    public IEnumerable<SwaggerExample<string>> GetExamples()
    {
        yield return SwaggerExample.Create("Successful Update Account", File.ReadAllText("examples/UpdateAccountResponse_Successful.json"));
    }
}

public class UpdateAccountResponseNotFoundExample : IMultipleExamplesProvider<string>
{
    public IEnumerable<SwaggerExample<string>> GetExamples()
    {
        yield return SwaggerExample.Create("Invalid Account Id", File.ReadAllText("examples/UpdateAccountResponse_NotFound.json"));
    }
}

public class GetLinkedExternalAccountsResponseExample : IMultipleExamplesProvider<string>
{
    public IEnumerable<SwaggerExample<string>> GetExamples()
    {
        yield return SwaggerExample.Create("Invalid Account Id", File.ReadAllText("examples/GetLinkedExternalAccountsResponse.json"));
    }
}

public class KYCRegistrationPOSTResponseExample : IMultipleExamplesProvider<string>
{
    public IEnumerable<SwaggerExample<string>> GetExamples()
    {
        yield return SwaggerExample.Create("Successfully Create Customer", File.ReadAllText("examples/KYCRegistrationPOSTResponse_New.json"));
    }
}

public class GeneralTransactionResponseSuccessExample : IMultipleExamplesProvider<string>
{
    public IEnumerable<SwaggerExample<string>> GetExamples()
    {
        yield return SwaggerExample.Create("Successful Deposit", File.ReadAllText("examples/GeneralTransactionDepositResponse_Successful.json"));
    }
}

public class GeneralTransactionResponseErrorExample : IMultipleExamplesProvider<string>
{
    public IEnumerable<SwaggerExample<string>> GetExamples()
    {
        yield return SwaggerExample.Create("Transaction date is not current", File.ReadAllText("examples/GeneralTransactionDepositResponse_DateNotCurrent.json"));
        // yield return SwaggerExample.Create("Must provide OTP", File.ReadAllText("examples/GeneralTransactionWithdrawalResponse_MustProvideOTP.json"));
    }
}

public class GeneralTransactionResponseTooManyRequestsExample : IMultipleExamplesProvider<string>
{
    public IEnumerable<SwaggerExample<string>> GetExamples()
    {
        yield return SwaggerExample.Create("Duplicated request", File.ReadAllText("examples/GeneralTransactionDepositResponse_TooManyRequests.json"));
    }
}

public class WebhookExample : IMultipleExamplesProvider<string>
{
    public IEnumerable<SwaggerExample<string>> GetExamples()
    {
        yield return SwaggerExample.Create("LOW_BALANCE", File.ReadAllText("examples/Webhook_LowBalance.json"));
        yield return SwaggerExample.Create("CASHIN", File.ReadAllText("examples/Webhook_CashIn.json"));
    }
}

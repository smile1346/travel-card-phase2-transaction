using Controllers;

struct Router
{
    public static void AddRoutes(WebApplication app)
    {
        var wallet = app.MapGroup("wallet");
        var v1 = wallet.MapGroup("v1");

        v1.MapGet("customers/{custId}", KYC.GetUserInfo).WithTags(["Customer Profile"]); // /v3/kyc/{custId}
        v1.MapPost("customers/registration", KYC.KYCRegistration).WithTags(["Customer Profile"]); // /v2/kyc/registration
        v1.MapPatch("customers/registration", KYC.PatchCustomer).WithTags(["Customer Profile"]); // /v3/kyc/registration
        v1.MapPost("customers/verify-otp", KYC.KYCConfirmation).WithTags(["Customer Profile"]); // /v2/kyc/confirmation

        v1.MapGet("customers/{custId}/accounts", Account.GetQuickAccounts).WithTags(["Wallet Account"]); // /wallet/v2/accounts/customer/{custId}/quick-accounts
        v1.MapGet("customers/{custId}/accounts/{accountId}", Account.GetSpecificAccount).WithTags(["Wallet Account"]); // "/wallet/v2/customers/{custId}/accounts/{accountId}" ?
        v1.MapPost("customers/{custId}/accounts", Account.CreateAccount).WithTags(["Wallet Account"]); // /wallet/v2/customers/{custId}/accounts
        v1.MapPut("customers/{custId}/accounts/{accountId}", Account.UpdateAccount).WithTags(["Wallet Account"]); // /wallet/v2/customers/{custId}/accounts/{accountId}
        v1.MapPut("consumer-device/accounts/{accountId}", Account.UpdateMsisdn).WithTags(["Wallet Account"]); // /consumer-device/account/{accountId}

        v1.MapPost("payments/transit-payment", Payment.PayForTransit).WithTags(["Payment"]); // /emoney/v3/billpayment
        v1.MapPost("payments/wallet-payment", Payment.PayForPass).WithTags(["Payment"]); // /emoney/v3/billpayment

        v1.MapGet("customers/{custId}/accounts/{accountId}/history", TransactionHistory.GetTransactionHistory).WithTags(["Transaction History"]); // /history/wallet/v4/{custId}/{accountId}/summary

        v1.MapPost("general-transaction", Integration.DepositWithdrawal).WithTags(["Integration"]); // /external-partners/v1/general-transaction

        // app.MapPost("partners-callback-server/users/{accountId}/notify", Notifications.Webhook).WithTags(["Notifications"]);
    }
}

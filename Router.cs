using Controllers;

struct Router
{

    public static void AddRoutes(WebApplication app)
    {
        var wallet = app.MapGroup("wallet");
        var v1 = wallet.MapGroup("v1");

        v1.MapGet("customers/{msisdn}", KYC.GetUserInfo).WithTags(["Customer Profile"]); // /v3/kyc/{msisdn}
        v1.MapPost("customers/registration", KYC.KYCRegistration).WithTags(["Customer Profile"]); // /v2/kyc/registration

        v1.MapGet("merchants/{msisdn}", KYC.GetUserInfoMerchant).WithTags(["Merchant Profile"]); // /v3/kyc/{msisdn}
        v1.MapPost("merchants/registration", KYC.KYCRegistrationMerchant).WithTags(["Merchant Profile"]); // /v2/kyc/registration
                                                                                                          // v1.MapPatch("customers/registration", KYC.PatchCustomer).WithTags(["Customer Profile"]); // /v3/kyc/registration
                                                                                                          // v1.MapPost("customers/verify-otp", KYC.KYCConfirmation).WithTags(["Customer Profile"]); // /v2/kyc/confirmation

        v1.MapGet("customers/{customerId}/accounts", Account.GetQuickAccounts).WithTags(["Wallet Account"]); // /wallet/v2/accounts/customer/{custId}/quick-accounts
        // v1.MapGet("customers/{customerId}/linked-external-accounts", Account.GetLinkedExternalAccounts).WithTags(["Wallet Account"]); // /customers/v2/{custId}/linked-external-accounts

        // v1.MapGet("customers/{custId}/accounts/{accountId}", Account.GetSpecificAccount).WithTags(["Wallet Account"]); // "/wallet/v2/customers/{custId}/accounts/{accountId}" ?
        // v1.MapPost("customers/{custId}/accounts", Account.CreateAccount).WithTags(["Wallet Account"]); // /wallet/v2/customers/{custId}/accounts
        // v1.MapPut("customers/{custId}/accounts/{accountId}", Account.UpdateAccount).WithTags(["Wallet Account"]); // /wallet/v2/customers/{custId}/accounts/{accountId}
        v1.MapPut("consumer-device/accounts/{accountId}", Account.UpdateMsisdn).WithTags(["Wallet Account"]); // /consumer-device/account/{accountId}

        v1.MapPost("payments/transit-payment", Payment.PayForTransit).WithTags(["Payment"]); // /emoney/v3/billpayment
        v1.MapPost("payments/wallet-payment", Payment.PayForGoods).WithTags(["Payment"]); // /emoney/v3/billpayment
        v1.MapPost("payments/merchants/{merchantId}/payment-reversal", Payment.ReversePayment).WithTags(["Payment"]); // /emoney/v3/merchants/{merchantId}/reversal

        v1.MapGet("customers/{customerId}/accounts/{accountId}/history", TransactionHistory.GetTransactionHistory).WithTags(["Transaction History"]); // /history/wallet/v4/{custId}/{accountId}/summary

        v1.MapPost("general-transaction", Integration.GeneralTransaction).WithTags(["Integration"]); // /external-partners/v1/general-transaction

        app.MapPost("partners-callback-endpoint", Notifications.Webhook).WithTags(["Notifications"]);

        v1.MapPost("qr-payments/merchants/{merchantId}/wallets/{accountId}/dynamic-qr-code", Merchant.CreateOpenBill).WithTags(["QR Payment"]); // /open-bill-api/v1/accounts/{accountId}/open-bills
        v1.MapPost("qr-payments/consumers/{customerId}/wallets/{accountId}/csb-qr-payment", Consumer.PayByMerchantToken).WithTags(["QR Payment"]); // /emoney/v3/consumers/{accountId}/payment
        v1.MapPost("qr-payments/merchants/{merchantId}/wallets/{accountId}/dynamic-qr-code/deactivate", Merchant.DeactivateOpenBill).WithTags(["QR Payment"]); // /open-bill-api/v1/deactivate/{accountId}

        v1.MapPost("qr-payments/consumers/{customerId}/wallets/{accountId}/dynamic-qr-code", Consumer.GetQRString).WithTags(["QR Payment"]); // /v3/wallets/{custId}/token
        v1.MapPost("qr-payments/merchants/{merchantId}/wallets/{accountId}/bsc-qr-payment", Merchant.PayByConsumerToken).WithTags(["QR Payment"]); // /merchants/{merchantId}/pay-by-consumer-token
    }
}

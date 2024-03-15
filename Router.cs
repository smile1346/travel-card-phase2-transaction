using System.Net;
using Controllers;
using Handlers;
using Microsoft.AspNetCore.Mvc;

struct Router
{
    public static void AddRoutes(WebApplication app)
    {
        // var v3 = app.MapGroup("v3");
        // var v1 = app.MapGroup("v1");

        // var kycV3 = v3.MapGroup("kyc").WithTags(["Customer Profile"]);
        // var kycv1 = v1.MapGroup("kyc").WithTags(["Customer Profile"]);



        // app.MapGet("kyc/configuration", KYC.GetKYCConfiguration).WithTags(["Customer Profile"]);

        app.MapGet("wallet/v1/customers/{custId}", KYC.GetUserInfo).WithTags(["Customer Profile"]);
        app.MapPost("wallet/v1/customers/registration", KYC.Register).WithTags(["Customer Profile"]);
        app.MapPatch("wallet/v1/customers/registration", KYC.PatchCustomer).WithTags(["Customer Profile"]);
        app.MapPost("wallet/v1/customers/verify-otp", KYC.KYCConfirmation).WithTags(["Customer Profile"]);

        app.MapGet("wallet/v1/customers/{custId}/accounts", Account.GetQuickAccounts).WithTags(["Wallet Account"]);
        app.MapGet("wallet/v1/customers/{custId}/accounts/{accountId}", Account.GetSpecificAccount).WithTags(["Wallet Account"]);
        app.MapPost("wallet/v1/customers/{custId}/accounts", Account.CreateAccount).WithTags(["Wallet Account"]);
        app.MapPut("wallet/v1/customers/{custId}/accounts/{accountId}", Account.UpdateAccount).WithTags(["Wallet Account"]);
        // app.MapGet("customers/v1/{custId}/linked-external-accounts", Account.GetLinkedExternalAccounts).WithTags(["Wallet Account"]);

        app.MapPost("wallet/v1/payments/transit-payment", Payment.PayForTransit).WithTags(["Payment"]);
        app.MapPost("wallet/v1/payments/wallet-payment", Payment.PayForPass).WithTags(["Payment"]);

        app.MapGet("wallet/v1/customers/{custId}/accounts/{accountId}/history", TransactionHistory.GetTransactionHistory).WithTags(["Transaction History"]);

        app.MapPost("wallet/v1/general-transaction", Integration.Topup).WithTags(["Integration"]);
        // app.MapGet("emoney/v3/consumers/{custId}/transfer/delayed/pending", TransactionHistory.GetPendingDelayedPayments).WithTags(["Transaction History"]);
        // app.MapGet("/customers/v1/{custId}/reports/statement-{YYYY}-{MM}.pdf", TransactionHistory.GetTransactionStatementPDF).WithTags(["Transaction History"]);
        // app.MapGet("/customers/v1/{custId}/reports/statement-{YYYY}-{MM}.csv", TransactionHistory.GetTransactionStatementCSV).WithTags(["Transaction History"]);


        // app.MapGet("/management/credittransfercharge", Config.GetTransactionLimits).WithTags(["Config API"]);
        // app.MapGet("/wallet/types", Config.GetAvailableWalletTypes).WithTags(["Config API"]);


        // var customerWalletProfile = app.MapGroup("/customer-wallet-profile").WithTags(["Customer Wallet Profile"]);
        // customerWalletProfile.MapPost("", CustomerWalletProfile.Create);
        // customerWalletProfile.MapGet("{customerWalletProfileId}", CustomerWalletProfile.Get);
        // app.MapPut("/customer-wallet-profile/{customerWalletProfileId}", CustomerWalletProfile.UpdateKyc);
        // customerWalletProfile.MapPost("{customerWalletProfileId}/pin", CustomerWalletProfile.CreatePin);
        // customerWalletProfile.MapPut("{customerWalletProfileId}/pin", CustomerWalletProfile.UpdatePin);

        // var walletAccount = app.MapGroup("/wallet-account").WithTags(["Wallet Account"]).WithDescription("Depends on customer wallet profile");
        // walletAccount.MapPost("", WalletAccount.CreateWallet);
        // walletAccount.MapGet("customers/{customerId}/accounts", WalletAccount.GetWallets);
        // walletAccount.MapGet("customers/{walletAccountId}/transactions", WalletAccount.GetTransactionList);
        // walletAccount.MapGet("customers/{customerId}/{walletAccountId}/transaction", WalletAccount.GetTransaction);

        // var walletProvider = app.MapGroup("wallet-provider").WithTags(["Wallet Provider"]).WithDescription("We are responsible for enrolling wallet providers");
        // walletProvider.MapGet("", WalletProvider.GetWalletProviders);
        // walletProvider.MapGet("{walletProviderId}", WalletProvider.GetWalletProvider);
        // walletProvider.MapPost("", WalletProvider.CreateWalletProvider);
    }
}
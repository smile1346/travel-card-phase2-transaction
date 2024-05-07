using Microsoft.AspNetCore.Mvc;
using System.Net;
using Swashbuckle.AspNetCore.Annotations;

using Swashbuckle.AspNetCore.Filters;
using Examples;
using System.Net.Mime;
using System.ComponentModel;
using HttpRequests;

namespace Controllers;

readonly partial struct Account
{
    // OK
    [ProducesResponseType(typeof(GetQuickAccountsResponseModel.Root[]), (int)HttpStatusCode.OK)]
    [SwaggerResponseExample((int)HttpStatusCode.OK, typeof(GetQuickAccountsResponseExample))]
    // Internal Server Error
    [ProducesResponseType(typeof(ClientErrorResponseModel.Root), (int)HttpStatusCode.InternalServerError)]

    [SwaggerOperation(Summary = "Get Accounts", Description = @"
This endpoint retreives all the accounts linked to the customer using the custId. Customers often need to see an overview of their accounts and balances, so this endpoint allows them to see statuses, IDs, balances, types, and other pieces of data concerning the health of their wallet.

This API is useful for the Payment because it contains all of the IDs that they need to transfer money from one account to another, whether it's one of their own or somebody else's.")]
    public static async Task GetQuickAccounts(HttpContext context,
    BBLClientBasedAccessTokenClient tokenClient,
    /*[DefaultValue("1040")]*/[SwaggerParameter("CustomerId - Unique identifier for the customer, returned from registration API")] string customerId,
    [FromHeader(Name = "x-jws-signature")][SwaggerParameter("JSON Web Signature with detached payload (JWS-Detached) used for message integrity verification.\n\n**Empty payload must be signed for GET requests**")] string signature)
    {
        await AuthorizedHttpClient.RerouteWithAccessTokenWriteBodyAsync($"/wallet/v2/accounts/customer/{customerId}/quick-accounts", context, tokenClient);
    }
}

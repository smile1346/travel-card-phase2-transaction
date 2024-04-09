using Microsoft.AspNetCore.Mvc;
using System.Net;
using Swashbuckle.AspNetCore.Annotations;

using Swashbuckle.AspNetCore.Filters;
using Examples;
using System.Net.Mime;
using HttpRequests;
using System.ComponentModel;
using System.Text.Json;

namespace Controllers;

readonly partial struct Account
{
    // OK
    [ProducesResponseType(typeof(GetQuickAccountsResponseModel.Root), (int)HttpStatusCode.OK)]
    [SwaggerResponseExample((int)HttpStatusCode.OK, typeof(GetSpecificAccountResponseExample))]
    // Internal Server Error
    [ProducesResponseType(typeof(ClientErrorResponseModel.Root), (int)HttpStatusCode.InternalServerError)]

    [SwaggerOperation(Summary = "Get a specific account", Description = @"
This endpoint retreives an account by id linked to the customer using the custId. Customers often need to see an overview of their accounts and balances, so this endpoint allows them to see statuses, IDs, balances, types, and other pieces of data concerning the health of their wallet.

This API is useful for the Payment because it contains all of the IDs that they need to transfer money from one account to another, whether it's one of their own or somebody else's.")]
    public static async Task<GetQuickAccountsResponseModel.Root> GetSpecificAccount(HttpContext context,
    BBLClientBasedAccessTokenClient tokenClient,
    /*[DefaultValue("1040")]*/[SwaggerParameter("The ID of the customer.")] string custId,
    /*[DefaultValue("1021")]*/[SwaggerParameter("The ID of the account.")] string accountId,
    [FromHeader(Name = "x-jws-signature")][SwaggerParameter("JSON Web Signature with detached payload (JWS-Detached) used for message integrity verification.\n\n**Empty payload must be signed for GET requests**")] string signature)
    {
        // var response = await AuthorizedHttpClient.RequestWithAccessTokenAsync(new HttpMethod(context.Request.Method), $"/wallet/v2/customers/{custId}/accounts/{accountId}", context.Request.Body, tokenClient, null, null);
        // var str = await response.Content.ReadAsStringAsync();

        // var accounts = JsonSerializer.Deserialize<GetQuickAccountsResponseModel.Root[]>(str);

        // return accounts?.FirstOrDefault(account => account.AccountId == accountId)!;
        return null;
    }
}

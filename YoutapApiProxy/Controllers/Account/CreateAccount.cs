using Microsoft.AspNetCore.Mvc;
using System.Net;
using Swashbuckle.AspNetCore.Annotations;

using Swashbuckle.AspNetCore.Filters;
using Examples;
using System.Net.Mime;
using HttpRequests;
using System.ComponentModel;

namespace Controllers;

readonly partial struct Account
{
    // OK
    [ProducesResponseType(typeof(CreateAccountResponseSuccessModel.Root), (int)HttpStatusCode.OK)]
    [SwaggerResponseExample((int)HttpStatusCode.OK, typeof(CreateAccountResponseSuccessExample))]
    // Not Found
    [ProducesResponseType(typeof(ClientErrorResponseModel.Root), (int)HttpStatusCode.NotFound)]
    [SwaggerResponseExample((int)HttpStatusCode.NotFound, typeof(CreateAccountResponseNotFoundExample))]
    // Internal Server Error
    [ProducesResponseType(typeof(ServerErrorResponseModel.Root), (int)HttpStatusCode.InternalServerError)]
    // Request Body
    [Consumes(typeof(CreateAccountRequestModel.Root), MediaTypeNames.Application.Json)]
    [SwaggerRequestExample(typeof(CreateAccountRequestModel.Root), typeof(CreateAccountRequestExample))]

    [SwaggerOperation(Summary = "Create Account", Description = @"
Consumers can sometimes have new accounts created, usually to allow them to conveniently keep balances separate or to have wallets of different types. This endpoint is how that is achieved.

Wallet types are primarily used to define minimum and maximum balances for each type.
Wallet Types.

The colour is simply an aesthetic choice for how to display that account in the app.")]
    public static async Task<string> CreateAccount(HttpContext context,
    PasswordBasedAccessTokenClient tokenClient,
    /*[DefaultValue("1040")]*/[SwaggerParameter("The ID of the customer.")] string custId,
    [FromHeader(Name = "x-jws-signature")][SwaggerParameter("JSON Web Signature with detached payload (JWS-Detached) used for message integrity verification.")] string? signature)
    {
        return await AuthorizedHttpClient.RerouteWithAccessTokenReturnStringAsync($"/wallet/v2/customers/{custId}/accounts", context, tokenClient, null);
    }

}

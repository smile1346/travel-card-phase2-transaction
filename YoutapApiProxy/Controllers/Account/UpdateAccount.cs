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
    [ProducesResponseType(typeof(UpdateAccountResponseSuccessModel.Root), (int)HttpStatusCode.OK)]
    [SwaggerResponseExample((int)HttpStatusCode.OK, typeof(UpdateAccountResponseSuccessExample))]
    // Not Found
    [ProducesResponseType(typeof(ClientErrorResponseModel.Root), (int)HttpStatusCode.NotFound)]
    [SwaggerResponseExample((int)HttpStatusCode.NotFound, typeof(UpdateAccountResponseNotFoundExample))]
    // Internal Server Error
    [ProducesResponseType(typeof(ClientErrorResponseModel.Root), (int)HttpStatusCode.InternalServerError)]
    // Request Body
    [Consumes(typeof(UpdateAccountRequestModel.Root), MediaTypeNames.Application.Json)]
    [SwaggerRequestExample(typeof(UpdateAccountRequestModel.Root), typeof(UpdateAccountRequestExample))]

    [SwaggerOperation(Summary = "Update Account", Description = @"As always a customer may have made a mistake when entering some information for their new account. In this case the account type can't be changed, but their custom display name and colour are mutable.")]
    public static async Task<string> UpdateAccount(HttpContext context,
    BBLClientBasedAccessTokenClient tokenClient,
    /*[DefaultValue("1040")]*/[SwaggerParameter("The ID of the customer.")] string custId,
    /*[DefaultValue("1021")]*/[SwaggerParameter("The ID of the account.")] string accountId,
    [FromHeader(Name = "x-jws-signature")][SwaggerParameter("JSON Web Signature with detached payload (JWS-Detached) used for message integrity verification.")] string signature)
    {
        return await AuthorizedHttpClient.RerouteWithAccessTokenReturnStringAsync($"/wallet/v2/customers/{custId}/accounts/{accountId}", context, tokenClient, null);
    }

}

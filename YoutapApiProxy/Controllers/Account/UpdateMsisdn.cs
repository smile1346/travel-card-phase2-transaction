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
    // Internal Server Error
    [ProducesResponseType(typeof(ClientErrorResponseModel.Root), (int)HttpStatusCode.InternalServerError)]
    // Request Body
    [Consumes(typeof(UpdateMsisdnRequestModel.Root), MediaTypeNames.Application.Json)]
    [SwaggerRequestExample(typeof(UpdateMsisdnRequestModel.Root), typeof(UpdateMsisdnRequestExample))]

    [SwaggerOperation(Summary = "Update mobile number", Description = @"Update MSISDN")]
    public static async Task<string> UpdateMsisdn(HttpContext context,
    BBLClientBasedAccessTokenClient tokenClient,
    /*[DefaultValue("1021")]*/[SwaggerParameter("The ID of the account.")] string accountId,
    [FromHeader(Name = "x-jws-signature")][SwaggerParameter("JSON Web Signature with detached payload (JWS-Detached) used for message integrity verification.")] string signature)
    {
        return await AuthorizedHttpClient.RerouteWithAccessTokenReturnStringAsync($"/consumer-device/account/{accountId}", context, tokenClient, null);
    }

}

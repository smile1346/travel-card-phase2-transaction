using Microsoft.AspNetCore.Mvc;
using System.Net;
using Swashbuckle.AspNetCore.Annotations;

using Swashbuckle.AspNetCore.Filters;
using Examples;
using System.Net.Mime;
using System.ComponentModel;
using HttpRequests;

namespace Controllers;

readonly partial struct KYC
{
    // OK
    [ProducesResponseType(typeof(UserInfoModel.Root), (int)HttpStatusCode.OK)]
    [SwaggerResponseExample((int)HttpStatusCode.OK, typeof(GetUserInfoResponseExample))]

    // Not Found
    [ProducesResponseType(typeof(ClientErrorResponseModel.Root), (int)HttpStatusCode.NotFound)]
    [SwaggerResponseExample((int)HttpStatusCode.NotFound, typeof(GetUserInfoResponseNotFoundExample))]

    // Internal Server Error
    [ProducesResponseType(typeof(ClientErrorResponseModel.Root), (int)HttpStatusCode.InternalServerError)]
    [SwaggerOperation(Summary = "Get user info with mobile number", Description = @"
This endpoint is used to get user KYC details with mobile number, including;

        - Status
        - Addresses and other contact information
        - Account details (including IDs for other requests)
        - Previously submitted identification documents
        - KYC tier requirements")]
    public static async Task GetUserInfo(HttpContext context,
    BBLClientBasedAccessTokenClient tokenClient,
    /*[DefaultValue("1040")]*/[SwaggerParameter("Mobile number of the customer.")] string msisdn,
    [FromHeader(Name = "x-jws-signature")][SwaggerParameter("JSON Web Signature with detached payload (JWS-Detached) used for message integrity verification.\n\n**Empty payload must be signed for GET requests**")] string signature)
    {
        await AuthorizedHttpClient.RerouteWithAccessTokenWriteBodyAsync($"/v3/kyc/{msisdn}", context, tokenClient);
    }

}

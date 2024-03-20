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
    // Internal Server Error
    [ProducesResponseType(typeof(ServerErrorResponseModel.Root), (int)HttpStatusCode.InternalServerError)]
    [SwaggerOperation(Summary = "Get User Info", Description = @"
This endpoint is used to get user KYC details, including;

        - Status
        - Addresses and other contact information
        - Account details (including IDs for other requests)
        - Previously submitted identification documents
        - KYC tier requirements")]
    public static async Task<string> GetUserInfo(HttpContext context,
    PasswordBasedAccessTokenClient tokenClient,
    [DefaultValue("1040")][SwaggerParameter("The ID of the customer.")] string custId)
    {
        return await AuthorizedHttpClient.RerouteWithAccessTokenReturnStringAsync($"/v3/kyc/{custId}", context, tokenClient);
    }

}

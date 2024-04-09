using Microsoft.AspNetCore.Mvc;
using System.Net;
using Swashbuckle.AspNetCore.Annotations;

using Swashbuckle.AspNetCore.Filters;
using Examples;
using System.Net.Mime;
using HttpRequests;

namespace Controllers;

readonly partial struct KYC
{
    // Request Body
    [Consumes(typeof(KYCConfirmationModel.Root), MediaTypeNames.Application.Json)]
    [SwaggerRequestExample(typeof(KYCConfirmationModel.Root), typeof(KYCConfirmationResponseExample))]
    // Internal Server Error
    [ProducesResponseType(typeof(ClientErrorResponseModel.Root), (int)HttpStatusCode.InternalServerError)]

    [SwaggerOperation(Summary = "KYC Confirmation", Description = @"Sends an OTP to the phone number, if valid. The validity period of the OTP is provided in the response.")]
    public static async Task<string> KYCConfirmation(HttpContext context,
    DefaultAccessTokenClient tokenClient,
    [FromHeader(Name = "x-jws-signature")][SwaggerParameter("JSON Web Signature with detached payload (JWS-Detached) used for message integrity verification.")] string signature)
    {
        return await AuthorizedHttpClient.RerouteWithAccessTokenReturnStringAsync("/v2/kyc/confirmation", context, tokenClient,null);
    }

}

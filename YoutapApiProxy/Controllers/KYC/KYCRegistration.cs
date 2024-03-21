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
    [Consumes(typeof(KYCRegistrationModel.Root), MediaTypeNames.Application.Json)]
    [SwaggerRequestExample(typeof(KYCRegistrationModel.Root), typeof(KYCRegistrationPOSTRequestExample))]
    // OK
    [ProducesResponseType(typeof(KYCRegistrationResponseModel.Root), (int)HttpStatusCode.OK)]
    [SwaggerResponseExample((int)HttpStatusCode.OK, typeof(KYCRegistrationPOSTResponse))]
    // Internal Server Error
    [ProducesResponseType(typeof(ServerErrorResponseModel.Root), (int)HttpStatusCode.InternalServerError)]

    [SwaggerOperation(Summary = "Register", Description = @"
Registers a new customer, including contact details and msisdn. Most fields are nullable in case the customer hasn't supplied that information, but the phone number is required.

Mandatory: Call KYC Confirmation to send OTP to users phone. Then request from user and supply in OTP field to validate registration.")]
    public static async Task<string> KYCRegistration(HttpContext context,
    DefaultAccessTokenClient tokenClient,
    [FromHeader(Name = "x-jws-signature")][SwaggerParameter("JSON Web Signature with detached payload (JWS-Detached) used for message integrity verification.")] string signature)
    {
        return await AuthorizedHttpClient.RerouteWithAccessTokenReturnStringAsync("/v2/kyc/registration", context, tokenClient);
    }

}

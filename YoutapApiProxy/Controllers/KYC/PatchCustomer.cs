using Microsoft.AspNetCore.Mvc;
using System.Net;
using Swashbuckle.AspNetCore.Annotations;

using Swashbuckle.AspNetCore.Filters;
using Examples;
using HttpRequests;
using System.Net.Mime;
using System.ComponentModel;

namespace Controllers;

readonly partial struct KYC
{
    // OK
    // [ProducesResponseType(typeof(KYCRegistrationModel.Root), (int)HttpStatusCode.OK)]
    // Internal Server Error
    [ProducesResponseType(typeof(ServerErrorResponseModel.Root), (int)HttpStatusCode.InternalServerError)]
    // Request Body
    [Consumes(typeof(PatchCustomerModel.Root), MediaTypeNames.Application.Json)]
    [SwaggerRequestExample(typeof(PatchCustomerModel.Root), typeof(KYCRegistrationPATCHRequestExample))]

    [SwaggerOperation(Summary = "Patch Customer", Description = @"Updates an existing customer registration.")]
    public static async Task<string> PatchCustomer(HttpContext context,
    ClientCredentialsBasedAccessTokenClient tokenClient,
    [FromHeader(Name = "x-jws-signature")][SwaggerParameter("JSON Web Signature with detached payload (JWS-Detached) used for message integrity verification.")] string signature,
    [DefaultValue("1040")][SwaggerParameter("The ID of the customer.")] string customerId)
    {
        return await AuthorizedHttpClient.RerouteWithAccessTokenReturnStringAsync("/v3/kyc/registration", context, tokenClient);
    }

}

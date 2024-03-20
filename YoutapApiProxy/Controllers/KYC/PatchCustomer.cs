using Microsoft.AspNetCore.Mvc;
using System.Net;
using Swashbuckle.AspNetCore.Annotations;

using Swashbuckle.AspNetCore.Filters;
using Examples;

namespace Controllers;

readonly partial struct KYC
{
    // OK
    // [ProducesResponseType(typeof(KYCRegistrationModel.Root), (int)HttpStatusCode.OK)]
    [SwaggerRequestExample(typeof(PatchCustomerModel.Root), typeof(KYCRegistrationPATCHRequestExample))]
    [SwaggerOperation(Summary = "Patch Customer", Description = @"Updates an existing customer registration.")]
    public static IResult PatchCustomer([SwaggerParameter("The ID of the customer.")] string customerId, PatchCustomerModel.Root payload /*[FromHeader(Name = "x-jws-signature")] [SwaggerParameter("JSON Web Signature (JWS) used for message integrity verification.")] string signature*/)
    {
        return Results.Ok();
    }

}

using Microsoft.AspNetCore.Mvc;
using System.Net;
using Swashbuckle.AspNetCore.Annotations;
using Models;
using Swashbuckle.AspNetCore.Filters;

namespace Controllers;

readonly partial struct KYC
{
    [SwaggerOperation(Summary = "Get KYC configuration", Description = @"
/kyc/configuration is the endpoint to get several pieces of
        configuration, but the important details for the customer are found in
        the kyc.registration namespace. This lists the pieces of required
        identification or other configurable values to let the wallet know what
        to ask the user for in order to upgrade their KYC level and access more
        features of the platform. This is a highly flexible endpoint and can
        supply keys and values as required.

It is not restricted by a JWT, but requires a Basic authentication header.")]
    public static IResult GetKYCConfiguration([FromQuery(Name = "namespace")] string ns = "kyc.custregistration")
    {
        return Results.Ok();
    }

}

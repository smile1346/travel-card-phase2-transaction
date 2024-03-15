using Microsoft.AspNetCore.Mvc;
using System.Net;
using Swashbuckle.AspNetCore.Annotations;
using Models;
using Swashbuckle.AspNetCore.Filters;
using Examples;

namespace Controllers;

readonly partial struct KYC
{
    // OK

    [SwaggerRequestExample(typeof(KYCRegistrationModel.Root), typeof(KYCRegistrationPOSTRequestExample))]
    [ProducesResponseType(typeof(KYCRegistrationResponseModel.Root), (int)HttpStatusCode.OK)]
    [SwaggerResponseExample((int)HttpStatusCode.OK, typeof(KYCRegistrationPOSTResponse))]
    [SwaggerOperation(Summary = "Register", Description = @"
Registers a new customer, including contact details and msisdn. Most fields are nullable in case the customer hasn't supplied that information, but the phone number is required.

Mandatory: Call KYC Confirmation to send OTP to users phone. Then request from user and supply in OTP field to validate registration.")]
    public static IResult Register(KYCRegistrationModel.Root payload /*[FromHeader(Name = "x-jws-signature")] [SwaggerParameter("JSON Web Signature (JWS) used for message integrity verification.")] string signature*/)
    {
        return Results.Ok();
    }

}

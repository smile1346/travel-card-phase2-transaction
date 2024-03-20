using Microsoft.AspNetCore.Mvc;
using System.Net;
using Swashbuckle.AspNetCore.Annotations;

using Swashbuckle.AspNetCore.Filters;
using Examples;
using System.Net.Mime;

namespace Controllers;

readonly partial struct Account
{
    // OK
    [ProducesResponseType(typeof(CreateAccountResponseSuccessModel.Root), (int)HttpStatusCode.OK)]
    [SwaggerResponseExample((int)HttpStatusCode.OK, typeof(CreateAccountResponseSuccessExample))]

    [ProducesResponseType(typeof(ErrorResponseModel.Root), (int)HttpStatusCode.NotFound)]
    [SwaggerResponseExample((int)HttpStatusCode.NotFound, typeof(CreateAccountResponseNotFoundExample))]

    [SwaggerRequestExample(typeof(CreateAccountRequestModel.Root), typeof(CreateAccountRequestExample))]

    [SwaggerOperation(Summary = "Create Account", Description = @"
Consumers can sometimes have new accounts created, usually to allow them to conveniently keep balances separate or to have wallets of different types. This endpoint is how that is achieved.

Wallet types are primarily used to define minimum and maximum balances for each type.
Wallet Types.

The colour is simply an aesthetic choice for how to display that account in the app.")]
    public static IResult CreateAccount([SwaggerParameter("The ID of the customer.")] string custId, CreateAccountRequestModel.Root payload /*[FromHeader(Name = "x-jws-signature")] [SwaggerParameter("JSON Web Signature (JWS) used for message integrity verification.")] string signature*/)
    {
        var res = File.ReadAllText(@"examples\CreateAccountRequest.json");
        return Results.Text(res, MediaTypeNames.Application.Json);
    }

}

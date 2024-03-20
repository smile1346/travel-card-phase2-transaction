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
    [ProducesResponseType(typeof(UpdateAccountResponseSuccessModel.Root), (int)HttpStatusCode.OK)]
    [SwaggerResponseExample((int)HttpStatusCode.OK, typeof(CreateAccountResponseSuccessExample))]

    [ProducesResponseType(typeof(ErrorResponseModel.Root), (int)HttpStatusCode.NotFound)]
    [SwaggerResponseExample((int)HttpStatusCode.NotFound, typeof(UpdateAccountResponseNotFoundExample))]

    [SwaggerRequestExample(typeof(UpdateAccountRequestModel.Root), typeof(UpdateAccountRequestExample))]

    [SwaggerOperation(Summary = "Update Account", Description = @"As always a customer may have made a mistake when entering some information for their new account. In this case the account type can't be changed, but their custom display name and colour are mutable.")]
    public static IResult UpdateAccount([SwaggerParameter("The ID of the customer.")] string custId,[SwaggerParameter("The ID of the account.")] string accountId, UpdateAccountRequestModel.Root payload /*[FromHeader(Name = "x-jws-signature")] [SwaggerParameter("JSON Web Signature (JWS) used for message integrity verification.")] string signature*/)
    {
        var res = File.ReadAllText(@"examples\CreateAccountResponse_Successful.json");
        return Results.Text(res, MediaTypeNames.Application.Json);
    }

}

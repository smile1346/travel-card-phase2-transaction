using Microsoft.AspNetCore.Mvc;
using System.Net;
using Swashbuckle.AspNetCore.Annotations;
using Models;
using Swashbuckle.AspNetCore.Filters;
using Examples;
using System.Net.Mime;

namespace Controllers;

readonly partial struct Account
{
    // OK
    [ProducesResponseType(typeof(GetLinkedExternalAccountsResponseModel.Root[]), (int)HttpStatusCode.OK)]
    [SwaggerResponseExample((int)HttpStatusCode.OK, typeof(GetLinkedExternalAccountsResponseExample))]

    [SwaggerOperation(Summary = "Get linked external accounts", Description = @"""External accounts"" can be linked to a customer's wallet through the Customer Management System. The wallet can then see which accounts have been linked using this endpoint.")]
    public static IResult GetLinkedExternalAccounts([SwaggerParameter("The ID of the customer.")] string custId)
    {
        var res = File.ReadAllText(@"examples\GetLinkedExternalAccountsResponse.json");
        return Results.Text(res, MediaTypeNames.Application.Json);
    }

}

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
    [ProducesResponseType(typeof(GetQuickAccountsResponseModel.Root[]), (int)HttpStatusCode.OK)]
    [SwaggerResponseExample((int)HttpStatusCode.OK, typeof(GetQuickAccountsResponseExample))]
    [SwaggerOperation(Summary = "Get Accounts", Description = @"
This endpoint retreives all the accounts linked to the customer using the custId. Customers often need to see an overview of their accounts and balances, so this endpoint allows them to see statuses, IDs, balances, types, and other pieces of data concerning the health of their wallet.

This API is useful for the Payment because it contains all of the IDs that they need to transfer money from one account to another, whether it's one of their own or somebody else's.")]
    public static IResult GetQuickAccounts([SwaggerParameter("The ID of the customer.")] string custId)
    {
        var res = File.ReadAllText(@"examples\GetQuickAccountsResponse.json");
        return Results.Text(res, MediaTypeNames.Application.Json);
    }

    [ProducesResponseType(typeof(GetQuickAccountsResponseModel.Root), (int)HttpStatusCode.OK)]
    [SwaggerResponseExample((int)HttpStatusCode.OK, typeof(GetSpecificAccountResponseExample))]
    [SwaggerOperation(Summary = "Get a specific account", Description = @"
This endpoint retreives an account by id linked to the customer using the custId. Customers often need to see an overview of their accounts and balances, so this endpoint allows them to see statuses, IDs, balances, types, and other pieces of data concerning the health of their wallet.

This API is useful for the Payment because it contains all of the IDs that they need to transfer money from one account to another, whether it's one of their own or somebody else's.")]
    public static IResult GetSpecificAccount([SwaggerParameter("The ID of the customer.")] string custId, [SwaggerParameter("The ID of the account.")] string accountId)
    {
        var res = File.ReadAllText(@"examples\GetSpecificAccountResponse.json");
        return Results.Text(res, MediaTypeNames.Application.Json);
    }
}

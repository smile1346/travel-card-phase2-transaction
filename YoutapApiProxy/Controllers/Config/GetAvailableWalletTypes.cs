using Microsoft.AspNetCore.Mvc;
using System.Net;
using Swashbuckle.AspNetCore.Annotations;

using Swashbuckle.AspNetCore.Filters;
using Examples;
using System.Net.Mime;

namespace Controllers;

readonly partial struct Config
{
    // OK
    [ProducesResponseType(typeof(GetTransactionLimitsResponseModel.Root[]), (int)HttpStatusCode.OK)]
    [SwaggerResponseExample((int)HttpStatusCode.OK, typeof(GetAvailableWalletTypesResponseExample))]
    [SwaggerOperation(Summary = "Get Available Wallet Types", Description = @"This endpoint retrieves active wallet types on the platform.")]
    public static IResult GetAvailableWalletTypes()
    {
        var res = File.ReadAllText(@"examples\GetAvailableWalletTypesResponse.json");
        return Results.Text(res, MediaTypeNames.Application.Json);
    }

}

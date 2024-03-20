using Microsoft.AspNetCore.Mvc;
using System.Net;
using Swashbuckle.AspNetCore.Annotations;

using Swashbuckle.AspNetCore.Filters;
using Examples;
using System.Net.Mime;

namespace Controllers;

readonly partial struct KYC
{
    // OK
    [ProducesResponseType(typeof(UserInfoModel.Root), (int)HttpStatusCode.OK)]
    [SwaggerResponseExample((int)HttpStatusCode.OK, typeof(GetUserInfoResponseExample))]
    [SwaggerOperation(Summary = "Get User Info", Description = @"
This endpoint is used to get user KYC details, including;

        - Status
        - Addresses and other contact information
        - Account details (including IDs for other requests)
        - Previously submitted identification documents
        - KYC tier requirements")]
    public static IResult GetUserInfo([SwaggerParameter("The ID of the customer.")] string custId)
    {
        var res = File.ReadAllText(@"examples\UserInfoResponse.json");
        return Results.Text(res, MediaTypeNames.Application.Json);
    }

}

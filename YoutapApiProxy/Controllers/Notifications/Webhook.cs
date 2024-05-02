using Microsoft.AspNetCore.Mvc;
using System.Net;
using Swashbuckle.AspNetCore.Annotations;

using Swashbuckle.AspNetCore.Filters;
using Examples;
using System.Net.Mime;
using HttpRequests;

namespace Controllers;

readonly partial struct Notifications
{
    // OK
    [ProducesResponseType(typeof(WebhookModel.Root), (int)HttpStatusCode.OK)]
    [SwaggerResponseExample((int)HttpStatusCode.OK, typeof(WebhookExample))]

    [SwaggerOperation(Summary = "(not an API endpont - see documentation description)", Description = @"
Examples of webhook requests that will be sent to partner's callback url upon specific events.

These examples are to show what events look like when they are sent to webhook endpoints.

This request is not supposed to describe functionality of a specific endpoint within our API.")]
    public static IResult Webhook(/* string accountId */)
    {
        var result = File.ReadAllText(@"examples/Webhook_LowBalance.json");
        return Results.Text(result, MediaTypeNames.Application.Json);
    }

}

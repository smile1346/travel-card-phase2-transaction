using Microsoft.AspNetCore.Mvc;
using System.Net;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.Filters;
using Examples;
using System.Net.Mime;
using System.Web;
using System.Text.Json.Serialization;
using System.Net.Http.Headers;
using System.ComponentModel;

namespace Controllers;

public class TokenResponse
{
    [JsonPropertyName("access_token")]
    public string AccessToken { get; set; }

    [JsonPropertyName("refresh_token")]
    public string RefreshToken { get; set; }

    [JsonPropertyName("scope")]
    public string Scope { get; set; }

    [JsonPropertyName("token_type")]
    public string TokenType { get; set; }

    [JsonPropertyName("expires_in")]
    public int ExpiresIn { get; set; }
}

public class AccessTokenResponsePassword
{
    public static async Task<string> GetAccessToken()
    {
        // Assuming you have a way to get the current time, for example:
        DateTime currentTime = DateTime.UtcNow;

        // Check if the current time is before the expiration time
        if (currentTime < AccessTokenExpirationTime)
        {
            Console.WriteLine("Token is still valid");
            // Access token is still valid, return it
            return CurrentAccessToken;
        }
        else
        {
            Console.WriteLine("Getting a new token...");

            var formData = new Dictionary<string, string>
            {
                { "grant_type", "password" },
                { "username", "278668662" },
                { "password", "112233"}
            };

            var content = new FormUrlEncodedContent(formData);

            //Basic Authentication
            var authenticationString = $"rabbit-consumer-1:cf55af0a-3931-4e38-9830-b117778b2a7b";
            var base64EncodedAuthenticationString = Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes(authenticationString));

            // Access token expired or doesn't exist, request a new one
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", base64EncodedAuthenticationString);

            var response = await client.PostAsync(Documentation.AUTH_URI, content);
            var responseBody = await response.Content.ReadFromJsonAsync<TokenResponse>();

            // Update the expiration time and current access token
            AccessTokenExpirationTime = currentTime.AddSeconds(responseBody.ExpiresIn);
            CurrentAccessToken = responseBody.AccessToken;

            // Return the new access token
            return responseBody.AccessToken;
        }
    }

    // These fields are assumed to be accessible from within the class.
    private static string CurrentAccessToken = null; // Stores the current access token
    private static DateTime AccessTokenExpirationTime = DateTime.MinValue; // Stores the expiration time of the access token
}

readonly partial struct TransactionHistory
{
    // OK
    [ProducesResponseType(typeof(GetTransactionHistoryResponse.Root), (int)HttpStatusCode.OK)]
    [SwaggerResponseExample((int)HttpStatusCode.OK, typeof(GetTransactionHistoryResponseExample))]

    [SwaggerOperation(Summary = "Get Transaction History", Description = @"This endpoint retrieves the transaction history summary of an account filtering using the period [from - to] , sort direction and ordering property")]
    public static async Task<string> GetTransactionHistory(HttpContext ctx,
    [DefaultValue("1040")][SwaggerParameter("The ID of the customer.")] string custId,
    [DefaultValue("1021")][SwaggerParameter("The ID of the account.")] string accountId,
    [SwaggerParameter("The type of the account.")] string? accountType,
    [SwaggerParameter("The type of the client.")] string? clientType,
    [SwaggerParameter("The IDs of the accounts.")] string? accountIds,
    [SwaggerParameter("The end date of the transaction history range.")] string? to,
    [SwaggerParameter("The start date of the transaction history range.")] string? from,
    [SwaggerParameter("The size of each page.")] string? pageSize,
    [SwaggerParameter("The page number.")] string? page,
    [SwaggerParameter("The property to order by.")] string? orderProperty,
    [SwaggerParameter("The direction of sorting (ascending or descending).")] string? sortDirection,
    [SwaggerParameter("Indicates whether to include interest and tax transactions.")] string? includeInterestAndTaxTransactions)
    {
        var uriBuilder = new UriBuilder(Documentation.GATEWAY_URI)
        {
            Path = $"/history/wallet/v4/{custId}/{accountId}/summary"
        };

        var query = HttpUtility.ParseQueryString(uriBuilder.Query);

        if (accountType != null)
            query["accountType"] = accountType;
        if (clientType != null)
            query["clientType"] = clientType;
        if (accountIds != null)
            query["accountIds"] = accountIds;
        if (to != null)
            query["to"] = to;
        if (from != null)
            query["from"] = from;
        if (pageSize != null)
            query["pageSize"] = pageSize;
        if (page != null)
            query["page"] = page;
        if (orderProperty != null)
            query["orderProperty"] = orderProperty;
        if (sortDirection != null)
            query["sortDirection"] = sortDirection;
        if (includeInterestAndTaxTransactions != null)
            query["includeInterestAndTaxTransactions"] = includeInterestAndTaxTransactions;

        uriBuilder.Query = query.ToString();

        var accessToken = await AccessTokenResponsePassword.GetAccessToken();
        Console.WriteLine(accessToken);

        Security.InsecureHttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
        var response = await Security.InsecureHttpClient.GetAsync(uriBuilder.Uri);

        string responseBody = await response.Content.ReadAsStringAsync();

        ctx.Response.StatusCode = (int)response.StatusCode;
        ctx.Response.ContentType = response.Content.Headers.ContentType?.MediaType;

        return responseBody;
    }
}

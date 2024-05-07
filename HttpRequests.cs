using System.Net;
using System.Net.Http.Headers;
using System.Net.Mime;
using System.Text.Json.Serialization;
using Microsoft.IdentityModel.Tokens;

namespace HttpRequests;

struct TokenResponse
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

interface IAccessTokenClient
{
    Task<string> GetAccessToken();
}

class AccessTokenClient
{
    private static readonly HttpClient HttpClient = new(new HttpClientHandler()
    {
        Proxy = new WebProxy(AuthorizedHttpClient.PROXY_URL, AuthorizedHttpClient.PROXY_PORT)
        // ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true
    });

    private static async Task<TokenResponse> RequestAccessToken(string clientId, string clientSecret, Dictionary<string, string> formData)
    {
        var request = new HttpRequestMessage(HttpMethod.Post, AuthorizedHttpClient.AUTH_URI)
        {
            Content = new FormUrlEncodedContent(formData)
        };

        var b64 = Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes($"{clientId}:{clientSecret}"));
        request.Headers.Authorization = new AuthenticationHeaderValue("Basic", b64);

        var response = await HttpClient.SendAsync(request);
        if (!response.IsSuccessStatusCode)
        {
            var str = await response.Content.ReadAsStringAsync();
            if (str.IsNullOrEmpty())
                throw new Exception($"Getting Access Token - {response.StatusCode} {response.ReasonPhrase}");

            Console.WriteLine(str);
            throw new Exception($"Getting Access Token - {response.StatusCode} {response.ReasonPhrase}: {str}");
        }

        return await response.Content.ReadFromJsonAsync<TokenResponse>();
    }

    // public static async Task<TokenResponse> RequestAccessToken(string clientId, string clientSecret, string username, string password)
    // {
    //     var formData = new Dictionary<string, string>
    //         {
    //             { "grant_type", "password" },
    //             { "username", username },
    //             { "password", password}
    //         };

    //     return await RequestAccessToken(clientId, clientSecret, formData);
    // }

    public static async Task<TokenResponse> RequestAccessToken(string clientId, string clientSecret)
    {
        var formData = new Dictionary<string, string>
            {
                { "grant_type", "client_credentials" },
            };

        return await RequestAccessToken(clientId, clientSecret, formData);
    }

}

class DefaultAccessTokenClient(string clientId, string clientSecret) : IAccessTokenClient
{
    public async Task<string> GetAccessToken()
    {
        // Assuming you have a way to get the current time, for example:
        DateTime currentTime = DateTime.UtcNow;

        // Check if the current time is before the expiration time
        if (currentTime < AccessTokenExpirationTime)
        {
            Console.WriteLine("Access token is still valid");
            // Access token is still valid, return it
            return CurrentAccessToken!;
        }
        else
        {
            Console.WriteLine("Getting a new access token...");

            var tokenResponse = await AccessTokenClient.RequestAccessToken(clientId, clientSecret);

            // Update the expiration time and current access token
            AccessTokenExpirationTime = currentTime.AddSeconds(tokenResponse.ExpiresIn);
            CurrentAccessToken = tokenResponse.AccessToken;

            // Return the new access token
            return CurrentAccessToken;
        }
    }

    // These fields are assumed to be accessible from within the class.
    private string? CurrentAccessToken = null; // Stores the current access token
    private DateTime AccessTokenExpirationTime = DateTime.MinValue; // Stores the expiration time of the access token
}

class BBLClientBasedAccessTokenClient(string clientId, string clientSecret) : IAccessTokenClient
{
    public async Task<string> GetAccessToken()
    {
        // Assuming you have a way to get the current time, for example:
        DateTime currentTime = DateTime.UtcNow;

        // Check if the current time is before the expiration time
        if (currentTime < AccessTokenExpirationTime)
        {
            Console.WriteLine("Access token is still valid");
            // Access token is still valid, return it
            return CurrentAccessToken!;
        }
        else
        {
            Console.WriteLine("Getting a new access token...");

            var tokenResponse = await AccessTokenClient.RequestAccessToken(clientId, clientSecret);

            // Update the expiration time and current access token
            AccessTokenExpirationTime = currentTime.AddSeconds(tokenResponse.ExpiresIn);
            CurrentAccessToken = tokenResponse.AccessToken;

            // Return the new access token
            return CurrentAccessToken;
        }
    }

    // These fields are assumed to be accessible from within the class.
    private string? CurrentAccessToken = null; // Stores the current access token
    private DateTime AccessTokenExpirationTime = DateTime.MinValue; // Stores the expiration time of the access token
}

// class PasswordBasedAccessTokenClient(string clientId, string clientSecret) : IAccessTokenClient
// {
//     // Dictionary to store access tokens and expiration times for each user
//     private readonly Dictionary<string, (string AccessToken, DateTime ExpirationTime)> userTokens = [];

//     public async Task<string> GetAccessToken(string? username)
//     {
//         if (username == null)
//             throw new ArgumentNullException(nameof(username), "Username cannot be null");

//         DateTime currentTime = DateTime.UtcNow;

//         // Check if the user exists in the dictionary and if the token is still valid
//         if (userTokens.TryGetValue(username, out var userToken) && currentTime < userToken.ExpirationTime)
//         {
//             Console.WriteLine($"Access token for user '{username}' is still valid");
//             return userToken.AccessToken;
//         }

//         Console.WriteLine($"Getting a new access token for user '{username}'...");

//         var tokenResponse = await AccessTokenClient.RequestAccessToken(clientId, clientSecret, username, "112233");

//         // Update or add the access token for the user
//         userTokens[username] = (tokenResponse.AccessToken, currentTime.AddSeconds(tokenResponse.ExpiresIn));

//         return tokenResponse.AccessToken;

//     }
// }

class AuthorizedHttpClient
{
    public static readonly Uri GATEWAY_URI = new("https://gateway.test.youtap-azuredev.net");
    public static readonly Uri AUTH_URI = new("https://auth.test.youtap-azuredev.net/uaa/oauth/token");
    public static readonly string PROXY_URL = "10.136.134.2";
    public static readonly int PROXY_PORT = 8080;

    private static readonly HttpClient HttpClient = new(new HttpClientHandler()
    {
        Proxy = new WebProxy(PROXY_URL, PROXY_PORT)
        // ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true
    });

    // public static async Task<string> ReturnHttpResponseAsStringAsync(HttpContext context, HttpResponseMessage response)
    // {
    //     context.Response.StatusCode = (int)response.StatusCode;
    //     context.Response.ContentType = response.Content.Headers.ContentType?.MediaType;

    //     return await response.Content.ReadAsStringAsync();
    // }

    // public static async Task<string> RerouteWithAccessTokenWriteBodyAsync<T>(string relativeGatewayPath, HttpContext context, T tokenClient) where T : IAccessTokenClient
    // {
    //     var response = await GetWithAccessTokenAsync(relativeGatewayPath, tokenClient);
    //     return await ReturnHttpResponseAsStringAsync(context, response);
    // }

    // public static async Task<HttpResponseMessage> GetWithAccessTokenAsync<T>(string relativeGatewayPath, T tokenClient) where T : IAccessTokenClient
    // {
    //     var uri = new Uri(GATEWAY_URI, relativeGatewayPath);
    //     return await GetWithAccessTokenAsync<T>(uri, tokenClient);
    // }

    // public static async Task<string> RerouteWithAccessTokenWriteBodyAsync<T>(Uri uri, HttpContext context, T tokenClient) where T : IAccessTokenClient
    // {
    //     var response = await GetWithAccessTokenAsync(uri, tokenClient);
    //     return await ReturnHttpResponseAsStringAsync(context, response);
    // }

    // public static async Task<HttpResponseMessage> GetWithAccessTokenAsync<T>(Uri uri, T tokenClient) where T : IAccessTokenClient
    // {
    //     HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await tokenClient.GetAccessToken());
    //     return await HttpClient.GetAsync(uri);
    // }

    // public static async Task<string> RerouteWithAccessTokenWriteBodyAsync<T>(string relativeGatewayPath, HttpContext context, T tokenClient, string? username) where T : IAccessTokenClient
    // {
    //     var response = await RequestWithAccessTokenAsync(new HttpMethod(context.Request.Method), relativeGatewayPath + context.Request.QueryString, context.Request.Body, tokenClient, username, "EN");
    //     return await ReturnHttpResponseAsStringAsync(context, response);
    // }

    public static async Task RerouteWithAccessTokenWriteBodyAsync<T>(string relativeGatewayPath, HttpContext context, T tokenClient) where T : IAccessTokenClient
    {
        var response = await RequestWithAccessTokenAsync(new HttpMethod(context.Request.Method), relativeGatewayPath + context.Request.QueryString, context.Request.Body, tokenClient, context.Request.Headers);

        context.Response.StatusCode = (int)response.StatusCode;

        foreach (var header in response.Headers)
            context.Response.Headers[header.Key] = header.Value.ToArray();

        foreach (var header in response.Content.Headers)
            context.Response.Headers[header.Key] = header.Value.ToArray();

        context.Response.Headers.Remove("transfer-encoding");

        await response.Content.CopyToAsync(context.Response.Body);
    }

    // public static async Task<string> RerouteWithAccessTokenReturnStringAsync<T>(string relativeGatewayPath, HttpContext context, T tokenClient) where T : IAccessTokenClient
    // {
    //     var response = await RequestWithAccessTokenAsync(new HttpMethod(context.Request.Method), relativeGatewayPath + context.Request.QueryString, context.Request.Body, tokenClient, context.Request.Headers);
    //     return await ReturnHttpResponseAsStringAsync(context, response);
    // }

    public static async Task<HttpResponseMessage> RequestWithAccessTokenAsync<T>(HttpMethod method, string relativeGatewayPath, Stream stream, T tokenClient, IHeaderDictionary originalHeaders) where T : IAccessTokenClient
    {
        var uri = new Uri(GATEWAY_URI, relativeGatewayPath);
        return await RequestWithAccessTokenAsync(method, uri, stream, tokenClient, originalHeaders);
    }

    // public static async Task<string> RerouteWithAccessTokenWriteBodyAsync<T>(Uri uri, HttpContext context, T tokenClient) where T : IAccessTokenClient
    // {
    //     var response = await RequestWithAccessTokenAsync(new HttpMethod(context.Request.Method), uri, context.Request.Body, tokenClient);
    //     return await ReturnHttpResponseAsStringAsync(context, response);
    // }

    public static async Task<HttpResponseMessage> RequestWithAccessTokenAsync<T>(HttpMethod method, Uri uri, Stream stream, T tokenClient, IHeaderDictionary originalHeaders) where T : IAccessTokenClient
    {
        var request = new HttpRequestMessage(method, uri);

        foreach (var header in originalHeaders)
            foreach (var value in header.Value)
                try
                {
                    request.Headers.Add(header.Key, value);
                }
                catch { }

        request.Headers.Host = uri.Authority;
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", await tokenClient.GetAccessToken());

        if (method == HttpMethod.Get || method == HttpMethod.Delete || method == HttpMethod.Trace || method == HttpMethod.Head)
            return await HttpClient.SendAsync(request);

        using var content = new StreamContent(stream);
        foreach (var header in originalHeaders)
            foreach (var value in header.Value)
                try
                {
                    content.Headers.Add(header.Key, value);
                }
                catch { }

        request.Content = content;

        return await HttpClient.SendAsync(request);
    }
}

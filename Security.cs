using System.Net;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;

struct Security
{
    static readonly bool IsDevelopmentEnvironment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development";
    public static readonly HttpClient InsecureHttpClient = new(new HttpClientHandler()
    {
        //ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true
    });

    public static void AddAuthorization(WebApplicationBuilder builder)
    {
        builder.Services.AddAuthorization();
        builder.Services.AddAuthorizationBuilder()
          .AddPolicy("admin", policy =>
                policy
                    .RequireRole("admin")
                    /* .RequireClaim("scope", "STPPayment") */);
    }
    public static void AddJwt(WebApplicationBuilder builder)
    {
        IdentityModelEventSource.ShowPII = true;
        builder.Services.AddAuthentication().AddJwtBearer(o =>
        {
            o.Backchannel = InsecureHttpClient;
            o.Authority = Environment.GetEnvironmentVariable("ISSUER_URI");
            o.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                //ValidIssuer = Environment.GetEnvironmentVariable("VALID_ISSUER") ?? Environment.GetEnvironmentVariable("ISSUER_URI"),
                ValidAudience = "account"
            };

            if (IsDevelopmentEnvironment)
                o.RequireHttpsMetadata = false;
        });
    }
    public const string issuer = "b2b";
    public const string audience = "b2b";
    public const string signingKey = "lVKq0AVlUWqoD6nzNpCXyPNxujGa8pLcOPK5Fq5RM4o66DHtD7h9ogDYAdLBT9FxfINX1lPXQBqY6nuMzOkI2wxU4AlpdlOIvG0ejacAizyXbWPeVpR3pExjFiwzxNd3";
    public static void AddLocalJwt(WebApplicationBuilder builder)
    {
        builder.Services.AddAuthentication(options =>
        {
            /* options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme; */
        }).AddJwtBearer(o =>
        {
            o.TokenValidationParameters = new TokenValidationParameters
            {
                ValidIssuer = issuer,
                ValidAudience = audience,
                IssuerSigningKey = new SymmetricSecurityKey
                    (Encoding.UTF8.GetBytes(signingKey)),
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true
            };
        });
    }

    public static void AddCors(WebApplicationBuilder builder)
    {
        builder.Services.AddCors(options =>
        {
            options.AddDefaultPolicy(
                policy =>
                {
                    policy.WithOrigins("*")
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .SetPreflightMaxAge(TimeSpan.FromSeconds(7200));
                });
        });
    }
}

readonly struct AdminSafeListMiddleware(RequestDelegate next)
{
    readonly string? safelist = Environment.GetEnvironmentVariable("WALLET_IP_WHITELIST", EnvironmentVariableTarget.Machine);
    public async Task Invoke(HttpContext context)
    {
        if (context.Request.Method != HttpMethod.Get.Method)
        {
            if (!safelist.IsNullOrEmpty())
            {
                var ips = safelist!.Split(';');
                var _safelist = new byte[ips.Length][];
                for (var i = 0; i < ips.Length; i++)
                {
                    _safelist[i] = IPAddress.Parse(ips[i]).GetAddressBytes();
                }

                var remoteIp = context.Connection.RemoteIpAddress;
                // logger.LogDebug("Request from Remote IP address: {RemoteIp}", remoteIp);

                var bytes = remoteIp!.GetAddressBytes();
                var badIp = true;

                foreach (var address in _safelist)
                {
                    if (address.SequenceEqual(bytes))
                    {
                        badIp = false;
                        break;
                    }
                }

                if (badIp)
                {
                    // logger.LogWarning(
                    //     "Forbidden Request from Remote IP address: {RemoteIp}", remoteIp);

                    context.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                    await context.Response.Body.WriteAsync(Encoding.UTF8.GetBytes($"Forbidden Request from Remote IP address: {remoteIp}"));

                    return;
                }
            }
        }

        await next.Invoke(context);
    }
}
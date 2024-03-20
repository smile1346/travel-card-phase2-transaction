using System.Text.Json.Serialization;

// ISOSchema.GenerateDataModel(@"schemas/pain.001.001.07.json", "pain.001.001.07", "pain_001_001_07");
// ISOSchema.GenerateDataModel(@"schemas/pain.001.001.03.json", "pain.001.001.03", "pain_001_001_03");
// ISOSchema.GenerateDataModel(@"schemas/pain.002.001.03.json", "pain.002.001.03", "pain_002_001_03");
// ISOSchema.GenerateDataModel(@"schemas/camt.054.001.02.json", "camt.054.001.02", "camt_054_001_02");

var builder = WebApplication.CreateBuilder();

// var x = new pain_002_001_03_json.PaymentTransactionInformation25
// {
//     StsRsnInf = new List<pain_002_001_03_json.StatusReasonInformation8>
//     {
//         new pain_002_001_03_json.StatusReasonInformation8
//         {
//             Rsn = new pain_002_001_03_json.StatusReason6Choice
//             {
//                 Cd = ExternalStatusReason1Code.AGNT.ToString()
//             },
//             AddtlInf = new List<string> { "Invalid Account Number" }
//         }
//     }
// };


// var y = JsonConvert.SerializeObject(x, Formatting.Indented, new JsonSerializerSettings
// {
//     NullValueHandling = NullValueHandling.Ignore,
//     Converters = new List<JsonConverter> { new StringEnumConverter() }
// });
// Console.WriteLine(y);

// Monitoring.AddOpenTelemetry(builder);
// Monitoring.AddLogging(builder);

builder.WebHost.ConfigureKestrel(o => o.AddServerHeader = false);

Security.AddJwt(builder);
Security.AddAuthorization(builder);
Security.AddCors(builder);

Documentation.AddSwagger(builder);

// builder.Services.AddControllers().AddJsonOptions(options =>
//     {
//         options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
//     });

var app = builder.Build();
Configuration.AddConfiguration(app);

// app.MapGet("/user", (ClaimsPrincipal user) =>
// {
//     return user.FindFirstValue("client_id");
// }).RequireAuthorization();

// app.MapPost("/token", async (HttpContext ctx, string clientId = "scg", string clientSecret = "8P0dHD9cDZBz4tUpvuygT1F9Xzx54QsC") =>
// {
//     var formData = new Dictionary<string, string>
//     {
//         { "grant_type", "client_credentials" },
//         { "client_id", clientId },
//         { "client_secret", clientSecret}
//     };
//     var content = new FormUrlEncodedContent(formData);

//     var response = await Security.InsecureHttpClient.PostAsync(Environment.GetEnvironmentVariable("ISSUER_URI") + "/protocol/openid-connect/token", content);
//     string responseBody = await response.Content.ReadAsStringAsync();

//     ctx.Response.StatusCode = (int)response.StatusCode;
//     ctx.Response.ContentType = response.Content.Headers.ContentType?.MediaType;
//     return responseBody;
// });

/* app.MapPost("/security/token", (String? apiKey, String? apiSecret, String corporateId = "ABC") =>
{
    var key = Encoding.ASCII.GetBytes(Security.signingKey);
    var tokenDescriptor = new SecurityTokenDescriptor
    {
        Subject = new ClaimsIdentity(new[]
        {
                new Claim("Id", Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Sub, corporateId),
                //new Claim(JwtRegisteredClaimNames.Email, "admin"),
                new Claim(JwtRegisteredClaimNames.Jti,
                Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Role, "client"),
                new Claim("scope", "STPPayment"),
             }),
        Expires = DateTime.UtcNow.AddMinutes(5),
        Issuer = Security.issuer,
        Audience = Security.audience,
        SigningCredentials = new SigningCredentials
        (new SymmetricSecurityKey(key),
        SecurityAlgorithms.HmacSha512Signature)
    };
    var tokenHandler = new JwtSecurityTokenHandler();
    var token = tokenHandler.CreateToken(tokenDescriptor);
    var stringToken = tokenHandler.WriteToken(token);
    return "Bearer " + stringToken;
}); */

Router.AddRoutes(app);
// Console.WriteLine("Application is now listening...");
app.Run();

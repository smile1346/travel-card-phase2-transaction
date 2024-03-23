using System.Reflection;
using System.Runtime.Serialization;
using Examples;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using Swashbuckle.AspNetCore.SwaggerGen;

readonly struct Documentation
{
  public static void UseSwagger(WebApplication app)
  {
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
      //c.DocumentTitle = serviceName;
      c.InjectStylesheet("/swagger.css");
    });
  }
  public static void AddSwagger(WebApplicationBuilder builder)
  {
    builder.Services.AddEndpointsApiExplorer();


    builder.Services.AddSwaggerExamplesFromAssemblyOf<KYCRegistrationPOSTRequestExample>();

    builder.Services.AddSwaggerGenNewtonsoftSupport();
    builder.Services.AddSwaggerGen(options =>
    {
      options.DocumentFilter<BasePathDocumentFilter>();
      options.DocumentFilter<OrderTagsDocumentFilter>();
      // options.SchemaFilter<IsRequiredSchemaFilter>();
      options.ExampleFilters();
      options.EnableAnnotations();
      options.SwaggerDoc("v1", new OpenApiInfo
      {
        Title = "BBL x Youtap API Management",
        Version = "v1.0",
        Description = @"This collection is secured using OAuth 2.0 tokens with a client_credentials grant type.

The app must acquire a token by posting a request to https://[domain]/oauth2/token with token_endpoint_auth_method of private_key_jwt and the client key signed as a jwt in client_assertion, as well as the key id. The client key is the provided customer key. The grant type, key ID, and client key can be supplied upon integration with a specific environment.

The token can be refreshed upon expiry, or a new one acquired if the user is inactive for too long.

Subsequent requests to restricted endpoints must contain the supplied token (a JWT), and whether the user is allowed to access the endpoint is determined based on claims inserted into the token upon its creation. For example, a user's token will claim to belong to them using their account ID. Every request to resources that belong to specific accounts will be checked against the account ID claim in the auth token, and if it doesn't match the request is rejected. Although not all JWTs require a signature and can be tampered with, our ones are verified using a non-default algorithm that only accepts it if it is signed with our own signing key.

Additionally, the token is how the front-end knows what the customer ID is so that it can be used in requests such as Get User Info. The app can decode the token and extract the customer ID claim. This allows us to keep personally identifiable information such as the MSISDN out of the request paths, thereby keeping customer information private."
      });

      options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
      {
        Description = "OAuth2 Grant Type client_credentials using private_key_jwt method, requires client key in the client_assertion field.",
        Type = SecuritySchemeType.OAuth2,
        Flows = new OpenApiOAuthFlows
        {
          ClientCredentials = new OpenApiOAuthFlow
          {
            // AuthorizationUrl = new Uri("http://localhost:4200/login"),
            TokenUrl = new Uri("https://api-uatpartner.bangkokbank.com/oauth2/token")
          }
        }
      });

      options.AddSecurityRequirement(new OpenApiSecurityRequirement{
                    {
                        new OpenApiSecurityScheme{
                            Reference = new OpenApiReference{
                                Id = "Bearer", //The name of the previously defined security scheme.
                                Type = ReferenceType.SecurityScheme
                            }
                        },new List<string>{"Bearer"}
                    }
                });

      options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
      {
        Description = @"Authorization header using the Bearer scheme.
                      Enter your access token in the text input below.
                      Example: 'eyJraWQiOiJlZWQ1ZWMyN...190rMJGj4NQuZqY57pluw'",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer"
      });

      options.AddSecurityRequirement(new OpenApiSecurityRequirement()
          {
        {
          new OpenApiSecurityScheme
          {
            Reference = new OpenApiReference
              {
                Type = ReferenceType.SecurityScheme,
                Id = "oauth2"
              },
              Scheme = "oauth2",
              Name = "oauth2",
              In = ParameterLocation.Header,

          },
            new List<string>{"oauth2"}
          }
            });

      options.CustomSchemaIds(type => type.FullName);
    });
  }
}

class OrderTagsDocumentFilter : IDocumentFilter
{
  private readonly List<OpenApiTag> openApiTags = [
    new OpenApiTag { Name = "Customer Profile", Description = "Customer Wallet Profile API provides the basic requests for accessing and managing all of the essential customer information. With its multi-tenant support, wallet providers are empowered to access their respective customer profiles securely." },
    new OpenApiTag { Name = "Wallet Account", Description = "The Wallet Account serves as the central hub for administering various aspects of wallet accounts, offering a suite of endpoints tailored to handle account creation, modification, and retrieval tasks." },
    new OpenApiTag { Name = "Transaction History", Description = "Every custom wants to know at one point or another how much they have sent and received in the past. The Transaction History can also let the customer about upcoming payments or download transaction summary documents." },
    new OpenApiTag { Name = "Payment", Description = @"The Payment API contains a comprehensive set of endpoints tailored to
      facilitate various payment transactions, accommodating a range of business concepts.
      Whether it's a general use case like make wallet payment to merchant or a specific scenario
      to meet diverse payment needs across different contexts.

For most payments there are limits or regulations in place. This includes, but is not limited to, account balance minimum and maximum balances and maximum transfer values. These limits reduce potential liability if a customer was to load too much value into a single wallet. They are also a layer within our anti-money laundering requirements because customers can't transfer excessively large amounts of money at once." },
    new OpenApiTag { Name = "Integration", Description = "Integration between the wallet system and banking system or partner."},
    // new OpenApiTag { Name = "Notifications", Description = "Notify events."}
  ];

  public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
  {
    swaggerDoc.Tags = openApiTags;
  }
}


class BasePathDocumentFilter : IDocumentFilter
{
  public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
  {
    swaggerDoc.Servers = new List<OpenApiServer>
    {
      new() {
        Description = "UAT",
        Url = "https://api-uatpartner.bangkokbank.com"
      },
      new() {
        Description = "PROD",
        Url = "https://api.bangkokbank.com"
      }
    };
  }
}

// class IsRequiredSchemaFilter : ISchemaFilter
// {
//   public void Apply(OpenApiSchema model, SchemaFilterContext context)
//   {
//     if (model?.Properties == null || context == null)
//     {
//       return;
//     }

//     var propertyInfoList = context.Type.GetProperties();

//     foreach (var entry in model.Properties)
//     {
//       entry.Value.Nullable = false;

//       var propertyName = entry.Key;
//       var property = propertyInfoList.FirstOrDefault(p => p.Name == propertyName);

//       if (property != null)
//       {
//         var dataMemberAttribute = property.GetCustomAttribute<DataMemberAttribute>();

//         if (dataMemberAttribute != null && dataMemberAttribute.IsRequired)
//         {
//           // Flag the property as required
//           model.Required.Add(propertyName);
//         }
//       }
//     }
//   }
// }

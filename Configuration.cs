using Microsoft.AspNetCore.HttpOverrides;

struct Configuration
{
    public static void AddConfiguration(WebApplication app)
    {
        app.UseForwardedHeaders(new ForwardedHeadersOptions
        {
            ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
        });

        app.UseCors();
        app.UseStaticFiles();

        if (app.Environment.IsDevelopment())
        {
            Documentation.UseSwagger(app);
            app.UseDeveloperExceptionPage();
        }
        else
        {
            Documentation.UseSwagger(app);
            app.UseDeveloperExceptionPage();
            //app.UseExceptionHandler("/Error");
            app.UseHsts();
        }

        // if (Monitoring.metricsExporter.Equals("prometheus", StringComparison.OrdinalIgnoreCase))
        //     app.UseOpenTelemetryPrometheusScrapingEndpoint();

        app.UseAuthentication();
        app.UseAuthorization();
    }
}

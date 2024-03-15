using System.Diagnostics.Metrics;
using OpenTelemetry.Instrumentation.AspNetCore;
using OpenTelemetry.Logs;
using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

struct Monitoring
{
    public const string SERVICE_NAME = "payment-manager";
    public const string SERVICE_VERSION = "v1";

    static readonly string tracingExporter = "otlp";
    public static readonly string metricsExporter = "prometheus";
    static readonly string logExporter = "otlp";
    static readonly string histogramAggregation = "exponential";
    public static Tracer tracer = TracerProvider.Default.GetTracer(SERVICE_NAME);

    static readonly Action<ResourceBuilder> configureResource = r => r.AddService(
                serviceName: SERVICE_NAME,
                serviceVersion: SERVICE_VERSION,
                serviceInstanceId: Environment.MachineName
    );

    public static void AddOpenTelemetry(WebApplicationBuilder appBuilder)
    {

        appBuilder.Services.AddOpenTelemetry()
            .ConfigureResource(configureResource)
            .WithTracing(builder =>
            {
                // Ensure the TracerProvider subscribes to any custom ActivitySources.
                builder
                    .AddSource(SERVICE_NAME)
                    .SetSampler(new AlwaysOnSampler())
                    .AddHttpClientInstrumentation()
                    .AddAspNetCoreInstrumentation();

                // Use IConfiguration binding for AspNetCore instrumentation options.
                // appBuilder.Services.Configure<AspNetCoreInstrumentationOptions>(appBuilder.Configuration.GetSection("AspNetCoreInstrumentation"));
                // Use IConfiguration binding for AspNetCore instrumentation options.
                appBuilder.Services.Configure<AspNetCoreTraceInstrumentationOptions>(appBuilder.Configuration.GetSection("AspNetCoreInstrumentation"));

                switch (tracingExporter)
                {
                    /* case "zipkin":
                        builder.AddZipkinExporter();

                        builder.ConfigureServices(services =>
                        {
                            // Use IConfiguration binding for Zipkin exporter options.
                            services.Configure<ZipkinExporterOptions>(appBuilder.Configuration.GetSection("Zipkin"));
                        });
                        break; */

                    case "otlp":
                        builder.AddOtlpExporter(otlpOptions =>
                        {
                            // Use IConfiguration directly for Otlp exporter endpoint option.
                            otlpOptions.Endpoint = new Uri(Environment.GetEnvironmentVariable("OTLP_GRPC_ENDPOINT") ?? "http://localhost:4317");
                        });
                        break;

                    default:
                        builder.AddConsoleExporter();
                        break;
                }
            }).WithMetrics(builder =>
            {
                // Metrics

                // Ensure the MeterProvider subscribes to any custom Meters.
                builder
                    .AddMeter(SERVICE_NAME)
#if EXPOSE_EXPERIMENTAL_FEATURES
            .SetExemplarFilter(new TraceBasedExemplarFilter())
#endif
                    .AddRuntimeInstrumentation()
                    .AddHttpClientInstrumentation()
                    .AddAspNetCoreInstrumentation();

                switch (histogramAggregation)
                {
                    case "exponential":
                        builder.AddView(instrument =>
                        {
                            return instrument.GetType().GetGenericTypeDefinition() == typeof(Histogram<>)
                                ? new Base2ExponentialBucketHistogramConfiguration()
                                : null;
                        });
                        break;
                    default:
                        // Explicit bounds histogram is the default.
                        // No additional configuration necessary.
                        break;
                }

                switch (metricsExporter)
                {
                    case "prometheus":
                        builder.AddPrometheusExporter();
                        break;
                    case "otlp":
                        builder.AddOtlpExporter(otlpOptions =>
                        {
                            // Use IConfiguration directly for Otlp exporter endpoint option.
                            otlpOptions.Endpoint = new Uri(Environment.GetEnvironmentVariable("OTLP_GRPC_ENDPOINT") ?? "http://localhost:4317");
                        });
                        break;
                    default:
                        builder.AddConsoleExporter();
                        break;
                }
            });
    }

    public static void AddLogging(WebApplicationBuilder appBuilder)
    {
        appBuilder.Logging.ClearProviders();
        // Configure OpenTelemetry Logging.
        appBuilder.Logging.AddOpenTelemetry(options =>
        {
            // Note: See appsettings.json Logging:OpenTelemetry section for configuration.

            var resourceBuilder = ResourceBuilder.CreateDefault();
            configureResource(resourceBuilder);
            options.SetResourceBuilder(resourceBuilder);

            switch (logExporter)
            {
                case "otlp":
                    options.AddOtlpExporter(otlpOptions =>
                    {
                        // Use IConfiguration directly for Otlp exporter endpoint option.
                        otlpOptions.Endpoint = new Uri(Environment.GetEnvironmentVariable("OTLP_GRPC_ENDPOINT") ?? "http://localhost:4317");
                    });
                    break;
                default:
                    // Clear default logging providers used by WebApplication host.
                    options.AddConsoleExporter();
                    break;
            }
        });
    }
}

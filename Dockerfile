FROM mcr.microsoft.com/dotnet/sdk:8.0-alpine AS publisher
WORKDIR /app
COPY *.csproj .

ENV DOTNET_NOLOGO=false
ENV DOTNET_CLI_TELEMETRY_OPTOUT=true

RUN dotnet restore

COPY . .

RUN dotnet publish -c Release -o /publish --no-restore

# --------------

FROM mcr.microsoft.com/dotnet/aspnet:8.0-alpine
#RUN wget https://github.com/dapr/cli/releases/latest/download/dapr_linux_amd64.tar.gz
#RUN tar -xf ./dapr_linux_amd64.tar.gz -C .
#RUN ./dapr init --slim
#COPY components components

# Install the agent
#RUN apt-get update && apt-get install -y wget ca-certificates gnupg \
#&& echo 'deb http://apt.newrelic.com/debian/ newrelic non-free' | tee /etc/apt/sources.list.d/newrelic.list \
#&& wget https://download.newrelic.com/548C16BF.gpg \
#&& apt-key add 548C16BF.gpg \
#&& apt-get update \
#&& apt-get install -y newrelic-dotnet-agent \
#&& rm -rf /var/lib/apt/lists/*

# Enable the agent
#ENV CORECLR_ENABLE_PROFILING=1 \
#CORECLR_PROFILER={36032161-FFC0-4B61-B559-F6C5D41BAE5A} \
#CORECLR_NEWRELIC_HOME=/usr/local/newrelic-dotnet-agent \
#CORECLR_PROFILER_PATH=/usr/local/newrelic-dotnet-agent/libNewRelicProfiler.so \
#NEW_RELIC_LICENSE_KEY=eu01xxfada1bf77f15b62d478145f71ced46NRAL \
#NEW_RELIC_APP_NAME=bokboon-event

ENV DOTNET_NOLOGO=true
ENV DOTNET_CLI_TELEMETRY_OPTOUT=true

HEALTHCHECK --interval=5m --timeout=3s --start-period=10s --retries=1 \
  CMD curl --fail http://localhost:8080/health || exit 1

COPY --from=publisher /publish /

EXPOSE 8080
ENTRYPOINT ["dotnet", "app.dll"]
#ENTRYPOINT ./dapr run --app-id payment-manager --app-port 8080 --resources-path components --config components/collector-config.yaml --placement-host-address placement:50006 --dapr-grpc-port 50001 -- dotnet app.dll

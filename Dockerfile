FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build

WORKDIR /src
COPY FinTracker.Domain/FinTracker.Domain.csproj     FinTracker.Domain/
COPY FinTracker.Parser/FinTracker.Parser.csproj     FinTracker.Parser/
COPY FinTracker.Data/FinTracker.Data.csproj         FinTracker.Data/
COPY FinTracker.API/FinTracker.API.csproj           FinTracker.API/
COPY FinTracker.Backend.slnx                        ./

RUN dotnet restore FinTracker.Backend.slnx

COPY . .

RUN dotnet publish FinTracker.API/FinTracker.API.csproj \
    --configuration Release \
    --output /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS runtime

WORKDIR /app

COPY --from=build /app/publish .

EXPOSE 8080

ENV ASPNETCORE_URLS="http://+:8080" \
    ASPNETCORE_ENVIRONMENT="Production"
    
ENTRYPOINT ["dotnet", "FinTracker.API.dll"]

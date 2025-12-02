# Build stage
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

# Copy csproj files and restore dependencies
COPY LinkedTracker.Api/LinkedTracker.Api.csproj LinkedTracker.Api/
COPY LinkedTracker.Data/LinkedTracker.Data.csproj LinkedTracker.Data/
RUN dotnet restore LinkedTracker.Api/LinkedTracker.Api.csproj

# Copy everything else and build
COPY LinkedTracker.Api/ LinkedTracker.Api/
COPY LinkedTracker.Data/ LinkedTracker.Data/
WORKDIR /src/LinkedTracker.Api
RUN dotnet build -c Release -o /app/build

# Publish stage
FROM build AS publish
RUN dotnet publish -c Release -o /app/publish /p:UseAppHost=false

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS runtime
WORKDIR /app
EXPOSE 80
EXPOSE 443
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LinkedTracker.Api.dll"]

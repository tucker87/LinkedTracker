# API
FROM mcr.microsoft.com/dotnet/sdk as build
COPY ./LinkedTracker.Api/ ./src
WORKDIR /src
RUN dotnet build -o /app
RUN dotnet publish -o /publish
 
FROM mcr.microsoft.com/dotnet/aspnet as base
COPY --from=build  /publish /app
WORKDIR /app
ENTRYPOINT ["dotnet", "DotNet.Docker.dll"]

#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

COPY ["travel-services.sln". "travel-services.sln"]
COPY ["src/Services/Flight/Flight.API/Flight.API.csproj", "src/Services/Flight/Flight.API/"]
COPY ["BuildingBlocks/Logging/Common.Logging/Common.Logging.csproj", "BuildingBlocks/Logging/Common.Logging/"]

COPY ["docker-compose.dcproj","docker-compose.dcproj"]

COPY ["NuGet.config","NuGet.config"]

RUN dotnet restore "travel-services.sln"

COPY . .
WORKDIR /src/Services/Flight/Flight.API
RUN dotnet publish --no-restore -c Release -o /app

FROM build AS publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Flight.API.dll"]

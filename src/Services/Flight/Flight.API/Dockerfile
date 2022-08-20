#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Flight.API/Flight.API.csproj", "Flight.API/"]
RUN dotnet restore "Flight.API/Flight.API.csproj"
COPY . .
WORKDIR "/src/Flight.API"
RUN dotnet build "Flight.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Flight.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Flight.API.dll"]
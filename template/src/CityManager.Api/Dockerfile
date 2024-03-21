FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["CityManager.Api/CityManager.Api.csproj", "CityManager.Api/"]
COPY ["CityManager.Application/CityManager.Application.csproj", "CityManager.Application/"]
COPY ["CityManager.Domain/CityManager.Domain.csproj", "CityManager.Domain/"]
COPY ["CityManager.Infrastructure/CityManager.Infrastructure.csproj", "CityManager.Infrastructure/"]
RUN dotnet restore "CityManager.Api/CityManager.Api.csproj"
COPY . .
WORKDIR "/src/CityManager.Api"
RUN dotnet build "CityManager.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CityManager.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CityManager.Api.dll"]

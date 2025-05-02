# Consulte https://aka.ms/customizecontainer para aprender a personalizar su contenedor de depuración y cómo Visual Studio usa este Dockerfile para compilar sus imágenes para una depuración más rápida.

# Esta fase se usa cuando se ejecuta desde VS en modo rápido (valor predeterminado para la configuración de depuración)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081


# Esta fase se usa para compilar el proyecto de servicio
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["PRG.WebMarket.Backend.WebApi/PRG.WebMarket.Backend.WebApi.csproj", "PRG.WebMarket.Backend.WebApi/"]
COPY ["PRG.WebMarket.Backend.Business/PRG.WebMarket.Backend.Business.csproj", "PRG.WebMarket.Backend.Business/"]
COPY ["PRG.WebMarket.Backend.Application/PRG.WebMarket.Backend.Application.csproj", "PRG.WebMarket.Backend.Application/"]
COPY ["PRG.WebMarket.Backend.Domain/PRG.WebMarket.Backend.Domain.csproj", "PRG.WebMarket.Backend.Domain/"]
COPY ["PRG.WebMarket.Backend.Infrastructure/PRG.WebMarket.Backend.Infrastructure.csproj", "PRG.WebMarket.Backend.Infrastructure/"]
RUN dotnet restore "./PRG.WebMarket.Backend.WebApi/PRG.WebMarket.Backend.WebApi.csproj"
COPY . .
WORKDIR "/src/PRG.WebMarket.Backend.WebApi"
RUN dotnet build "./PRG.WebMarket.Backend.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Esta fase se usa para publicar el proyecto de servicio que se copiará en la fase final.
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./PRG.WebMarket.Backend.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Esta fase se usa en producción o cuando se ejecuta desde VS en modo normal (valor predeterminado cuando no se usa la configuración de depuración)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PRG.WebMarket.Backend.WebApi.dll"]
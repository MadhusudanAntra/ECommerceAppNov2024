#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
ENV ECommerceDb="Data Source=host.docker.internal,1433;Initial Catalog=ECommerceDb;User ID=SA;Password=Secure@123;Trust Server Certificate=True"

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["EcommerceApp.WebAPiApp/EcommerceApp.WebAPiApp.csproj", "EcommerceApp.WebAPiApp/"]
COPY ["ECommerceApp.Infrastructure/ECommerceApp.Infrastructure.csproj", "ECommerceApp.Infrastructure/"]
COPY ["ECommerceApp.ApplicationCore/ECommerceApp.ApplicationCore.csproj", "ECommerceApp.ApplicationCore/"]
RUN dotnet restore "./EcommerceApp.WebAPiApp/EcommerceApp.WebAPiApp.csproj"
COPY . .
WORKDIR "/src/EcommerceApp.WebAPiApp"
RUN dotnet build "./EcommerceApp.WebAPiApp.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./EcommerceApp.WebAPiApp.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EcommerceApp.WebAPiApp.dll"]
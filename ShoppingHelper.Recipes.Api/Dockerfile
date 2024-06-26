#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["ShoppingHelper.Recipes.Api/ShoppingHelper.Recipes.Api.csproj", "ShoppingHelper.Recipes.Api/"]
RUN dotnet restore "./ShoppingHelper.Recipes.Api/ShoppingHelper.Recipes.Api.csproj"
COPY . .
WORKDIR "/src/ShoppingHelper.Recipes.Api"
RUN dotnet build "./ShoppingHelper.Recipes.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./ShoppingHelper.Recipes.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=true

FROM mcr.microsoft.com/dotnet/runtime-deps:8.0 AS final
WORKDIR /app
EXPOSE 8080
COPY --from=publish /app/publish .
ENTRYPOINT ["./ShoppingHelper.Recipes.Api"]
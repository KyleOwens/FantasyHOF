# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080


# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["FantasyHOF/FantasyHOF.csproj", "FantasyHOF/"]
COPY ["FantasyHOF.Application/FantasyHOF.Application.csproj", "FantasyHOF.Application/"]
COPY ["FantasyHOF.Domain/FantasyHOF.Domain.csproj", "FantasyHOF.Domain/"]
COPY ["FantasyHOF.EntityFramework/FantasyHOF.EntityFramework.csproj", "FantasyHOF.EntityFramework/"]
COPY ["FantasyHOF.Infrastructure/FantasyHOF.Infrastructure.csproj", "FantasyHOF.Infrastructure/"]
COPY ["FantasyHOF.ESPN/FantasyHOF.ESPN.csproj", "FantasyHOF.ESPN/"]
COPY ["FantasyHOF.GraphQL/FantasyHOF.GraphQL.csproj", "FantasyHOF.GraphQL/"]
RUN dotnet restore "./FantasyHOF/FantasyHOF.csproj"
COPY . .
WORKDIR "/src/FantasyHOF"
RUN dotnet build "./FantasyHOF.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./FantasyHOF.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FantasyHOF.dll"]
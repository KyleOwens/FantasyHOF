FROM node:20-alpine AS frontend-build
WORKDIR /app

COPY frontend/package*.json ./
RUN npm ci

COPY fonrtend/ ./
RUN npm run build

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

COPY ["backend/FantasyHOF/FantasyHOF.csproj", "FantasyHOF/"]
COPY ["backend/FantasyHOF.Application/FantasyHOF.Application.csproj", "FantasyHOF.Application/"]
COPY ["backend/FantasyHOF.Domain/FantasyHOF.Domain.csproj", "FantasyHOF.Domain/"]
COPY ["backend/FantasyHOF.EntityFramework/FantasyHOF.EntityFramework.csproj", "FantasyHOF.EntityFramework/"]
COPY ["backend/FantasyHOF.Infrastructure/FantasyHOF.Infrastructure.csproj", "FantasyHOF.Infrastructure/"]
COPY ["backend/FantasyHOF.ESPN/FantasyHOF.ESPN.csproj", "FantasyHOF.ESPN/"]
COPY ["backend/FantasyHOF.GraphQL/FantasyHOF.GraphQL.csproj", "FantasyHOF.GraphQL/"]

RUN dotnet restore "./FantasyHOF/FantasyHOF.csproj"

COPY backend/ .
WORKDIR "/src/FantasyHOF"
RUN dotnet build "./FantasyHOF.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./FantasyHOF.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app


COPY --from=publish /app/publish .
COPY --from=frontend-build /app/dist ./wwwroot

ENV ASPNETCORE_URLS=http://+:${PORT:-8080}
ENV ASPNETCORE_ENVIRONMENT=Production

ENTRYPOINT ["dotnet", "FantasyHOF.dll"]
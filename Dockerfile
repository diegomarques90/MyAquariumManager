FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY ["MyAquariumManager.Web/MyAquariumManager.Web.csproj", "MyAquariumManager.Web/"]
COPY ["MyAquariumManager.Application/MyAquariumManager.Application.csproj", "MyAquariumManager.Application/"]
COPY ["MyAquariumManager.Core/MyAquariumManager.Core.csproj", "MyAquariumManager.Core/"]
COPY ["MyAquariumManager.Infrastructure/MyAquariumManager.Infrastructure.csproj", "MyAquariumManager.Infrastructure/"]

RUN dotnet restore "MyAquariumManager.Web/MyAquariumManager.Web.csproj"

COPY . .
WORKDIR "/src/MyAquariumManager.Web"
RUN dotnet build "MyAquariumManager.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MyAquariumManager.Web.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MyAquariumManager.Web.dll"]
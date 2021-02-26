FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/NerdStore.Sales.Api/NerdStore.Sales.Api.csproj", "src/NerdStore.Sales.Api/"]
RUN dotnet restore "src\NerdStore.Sales.Api\NerdStore.Sales.Api.csproj"
COPY . .
WORKDIR "/src/src/NerdStore.Sales.Api"
RUN dotnet build "NerdStore.Sales.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "NerdStore.Sales.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NerdStore.Sales.Api.dll"]

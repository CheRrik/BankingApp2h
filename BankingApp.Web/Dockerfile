FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["BankingApp.Web/BankingApp.Web.csproj", "BankingApp.Web/"]
RUN dotnet restore "BankingApp.Web/BankingApp.Web.csproj"
COPY . .
WORKDIR "/src/BankingApp.Web"
RUN dotnet build "BankingApp.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BankingApp.Web.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BankingApp.Web.dll"]

FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["YourivanderStar/YourivanderStar.csproj", "YourivanderStar/"]
RUN dotnet restore "YourivanderStar/YourivanderStar.csproj"
COPY . .
WORKDIR "/src/YourivanderStar"
RUN dotnet build "YourivanderStar.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "YourivanderStar.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "YourivanderStar.dll"]

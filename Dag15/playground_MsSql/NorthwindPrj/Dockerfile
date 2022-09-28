FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Northwind/Northwind.csproj", "Northwind/"]
RUN dotnet restore "Northwind/Northwind.csproj"
COPY . .
WORKDIR "/src/Northwind"
RUN dotnet build "Northwind.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Northwind.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Northwind.dll"]

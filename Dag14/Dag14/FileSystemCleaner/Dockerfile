FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["FileSystemCleaner/FileSystemCleaner.csproj", "FileSystemCleaner/"]
RUN dotnet restore "FileSystemCleaner/FileSystemCleaner.csproj"
COPY . .
WORKDIR "/src/FileSystemCleaner"
RUN dotnet build "FileSystemCleaner.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FileSystemCleaner.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FileSystemCleaner.dll"]

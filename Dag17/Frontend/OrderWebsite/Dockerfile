FROM mcr.microsoft.com/dotnet/aspnet
WORKDIR /app
COPY ./obj/docker/publish .
ENTRYPOINT ["dotnet", "OrderWebsite.dll"]
cd CASwebsite || exit 1
dotnet build -c Release
dotnet publish -c Release -o obj/docker/publish --no-build .
dotnet build -c Release
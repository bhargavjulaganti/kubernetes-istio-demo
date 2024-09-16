FROM mcr.microsoft.com/dotnet/sdk:8.0 AS publish

WORKDIR /app

COPY . ./

RUN dotnet restore demo-api/demo-api.csproj
RUN dotnet publish demo-api/demo-api.csproj -c Release -o publish/

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS deploy

WORKDIR /app

EXPOSE 80

COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "demo-api.dll"]


# docker build -t your-dockerhub-username/demo-api:latest .





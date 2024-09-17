FROM mcr.microsoft.com/dotnet/sdk:8.0 AS publish

WORKDIR /app

COPY . ./

RUN dotnet restore mockapi/mockapi.csproj
RUN dotnet publish mockapi/mockapi.csproj -c Release -o publish/

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS deploy

WORKDIR /app

EXPOSE 80

COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "mockapi.dll"]

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS publish
WORKDIR /src

COPY . .
RUN dotnet publish "src/fkd.pay.api" -c Release -o /app/publish
FROM mcr.microsoft.com/dotnet/core/aspnet

FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
COPY --from=publish /app/publish .

#EXPOSE 80
#ENTRYPOINT ["dotnet", "fkd.pay.api.dll"]
CMD ASPNETCORE_URLS=http://*:$PORT dotnet fkd.pay.api.dll
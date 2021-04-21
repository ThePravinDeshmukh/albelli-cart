FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src1
COPY . .
RUN dotnet restore
RUN dotnet publish -c release -o /app

FROM mcr.microsoft.com/dotnet/aspnet:3.1
WORKDIR /app
COPY --from=build /app .
EXPOSE 5000
ENTRYPOINT ["dotnet", "Albellicart.dll"]
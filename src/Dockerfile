FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY . .
RUN ls
RUN dotnet restore
RUN dotnet publish -c release -o /app

FROM mcr.microsoft.com/dotnet/aspnet:3.1
WORKDIR /app
RUN ls
COPY --from=build /app .
EXPOSE 5000
ENTRYPOINT ["dotnet", "Albellicart.dll"]
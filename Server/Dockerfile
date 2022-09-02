#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Server/CRUDApplication.Server.csproj", "Server/"]
COPY ["Client/CRUDApplication.Client.csproj", "Client/"]
COPY ["Shared/CRUDApplication.Shared.csproj", "Shared/"]
RUN dotnet restore "Server/CRUDApplication.Server.csproj"
COPY . .
WORKDIR "/src/Server"
RUN dotnet build "CRUDApplication.Server.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CRUDApplication.Server.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CRUDApplication.Server.dll"]

CMD ASPNETCORE_URLS=http://*:$PORT dotnet CRUDApplication.dll
#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["wsdlclient/wsdlclient.csproj", "wsdlclient/"]
RUN dotnet restore "wsdlclient/wsdlclient.csproj"
COPY . .
WORKDIR "/src/wsdlclient"
RUN dotnet build "wsdlclient.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "wsdlclient.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "wsdlclient.dll"]
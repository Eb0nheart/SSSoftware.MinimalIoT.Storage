#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["SSSoftware.MinimalIoT.Storage/SSSoftware.MinimalIoT.Storage.csproj", "SSSoftware.MinimalIoT.Storage/"]
RUN dotnet restore "SSSoftware.MinimalIoT.Storage/SSSoftware.MinimalIoT.Storage.csproj"
COPY . .
WORKDIR "/src/SSSoftware.MinimalIoT.Storage"
RUN dotnet build "SSSoftware.MinimalIoT.Storage.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SSSoftware.MinimalIoT.Storage.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SSSoftware.MinimalIoT.Storage.dll"]
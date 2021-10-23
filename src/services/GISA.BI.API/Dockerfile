#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["src/services/GISA.BI.API/GISA.BI.API.csproj", "src/services/GISA.BI.API/"]
RUN dotnet restore "src/services/GISA.BI.API/GISA.BI.API.csproj"
COPY . .
WORKDIR "/src/src/services/GISA.BI.API"
RUN dotnet build "GISA.BI.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GISA.BI.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GISA.BI.API.dll"]
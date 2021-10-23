#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["src/web/GISA.WebApp.MVC/GISA.WebApp.MVC.csproj", "src/web/GISA.WebApp.MVC/"]
RUN dotnet restore "src/web/GISA.WebApp.MVC/GISA.WebApp.MVC.csproj"
COPY . .
WORKDIR "/src/src/web/GISA.WebApp.MVC"
RUN dotnet build "GISA.WebApp.MVC.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GISA.WebApp.MVC.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GISA.WebApp.MVC.dll"]
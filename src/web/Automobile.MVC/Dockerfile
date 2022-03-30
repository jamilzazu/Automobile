#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["./web/Automobile.MVC/Automobile.MVC.csproj", "web/Automobile.MVC/"]
COPY ["./building blocks/Automobile.Core/Automobile.Core.csproj", "building blocks/Automobile.WebAPI.Core/"]
COPY ["./building blocks/Automobile.WebAPI.Core/Automobile.WebAPI.Core.csproj", "building blocks/Automobile.WebAPI.Core/"]

RUN dotnet restore "web/Automobile.MVC/Automobile.MVC.csproj"
COPY . .
WORKDIR "web/Automobile.MVC"
RUN dotnet build "Automobile.MVC.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Automobile.MVC.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Automobile.MVC.dll"]
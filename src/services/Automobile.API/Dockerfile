#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["./services/Automobile.API/Automobile.API.csproj", "services/Automobile.API/"]
COPY ["./services/Automobile.Integracao/Automobile.Integracao.csproj", "services/Automobile.Integracao/"]
COPY ["./building blocks/Automobile.Core/Automobile.Core.csproj", "building blocks/Automobile.Core/"]
COPY ["./building blocks/Automobile.MessageBus/Automobile.MessageBus.csproj", "building blocks/Automobile.MessageBus/"]
COPY ["./services/Automobile.Application/Automobile.Application.csproj", "services/Automobile.Application/"]
COPY ["./building blocks/Automobile.Database.SqlServer/Automobile.Database.SqlServer.csproj", "building blocks/Automobile.Database.SqlServer/"]
COPY ["./services/Automobile.Domain/Automobile.Domain.csproj", "services/Automobile.Domain/"]
COPY ["./services/Automobile.Infra.EF/Automobile.Infra.EF.csproj", "services/Automobile.Infra.EF/"]
COPY ["./building blocks/Automobile.WebAPI.Core/Automobile.WebAPI.Core.csproj", "building blocks/Automobile.WebAPI.Core/"]
RUN dotnet restore "services/Automobile.API/Automobile.API.csproj"
COPY . .
WORKDIR "services/Automobile.API"
RUN dotnet build "Automobile.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Automobile.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Automobile.API.dll"]
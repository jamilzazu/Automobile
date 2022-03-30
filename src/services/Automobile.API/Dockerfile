#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/services/Automobile.API/Automobile.API.csproj", "src/services/Automobile.API/"]
COPY ["src/services/Automobile.Integracao/Automobile.Integracao.csproj", "src/services/Automobile.Integracao/"]
COPY ["src/building blocks/Automobile.Core/Automobile.Core.csproj", "src/building blocks/Automobile.Core/"]
COPY ["src/building blocks/Automobile.MessageBus/Automobile.MessageBus.csproj", "src/building blocks/Automobile.MessageBus/"]
COPY ["src/services/Automobile.Application/Automobile.Application.csproj", "src/services/Automobile.Application/"]
COPY ["src/building blocks/Automobile.Database.SqlServer/Automobile.Database.SqlServer.csproj", "src/building blocks/Automobile.Database.SqlServer/"]
COPY ["src/services/Automobile.Domain/Automobile.Domain.csproj", "src/services/Automobile.Domain/"]
COPY ["src/services/Automobile.Infra.EF/Automobile.Infra.EF.csproj", "src/services/Automobile.Infra.EF/"]
COPY ["src/building blocks/Automobile.WebAPI.Core/Automobile.WebAPI.Core.csproj", "src/building blocks/Automobile.WebAPI.Core/"]
RUN dotnet restore "src/services/Automobile.API/Automobile.API.csproj"
COPY . .
WORKDIR "/src/src/services/Automobile.API"
RUN dotnet build "Automobile.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Automobile.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Automobile.API.dll"]
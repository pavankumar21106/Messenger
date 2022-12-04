#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Messenger.API.csproj", "."]
COPY ["../MessengerService/Messenger.Application.csproj", "../MessengerService/"]
COPY ["../Messenger.Domain/Messenger.Domain.csproj", "../Messenger.Domain/"]
COPY ["../Messenger.Entities/Messenger.Entities.csproj", "../Messenger.Entities/"]
COPY ["../MessengerInfrastructure/Messenger.Infrastructure.csproj", "../MessengerInfrastructure/"]
COPY ["../Messenger.DBContext/Messenger.DBContext.csproj", "../Messenger.DBContext/"]
RUN dotnet restore "./Messenger.API.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "Messenger.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Messenger.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Messenger.API.dll"]

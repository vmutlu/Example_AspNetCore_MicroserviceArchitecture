#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-focal AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0-focal AS build
WORKDIR /src
COPY ["Microservice.Auth.API/Microservice.Auth.API.csproj", "Microservice.Auth.API/"]
RUN dotnet restore "Microservice.Auth.API/Microservice.Auth.API.csproj"
COPY . .
WORKDIR "/src/Microservice.Auth.API"
RUN dotnet build "Microservice.Auth.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Microservice.Auth.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Microservice.Auth.API.dll"]

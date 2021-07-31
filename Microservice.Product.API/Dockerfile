#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-focal AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0-focal AS build
WORKDIR /src
COPY ["Microservice.Product.API/Microservice.Product.API.csproj", "Microservice.Product.API/"]
RUN dotnet restore "Microservice.Product.API/Microservice.Product.API.csproj"
COPY . .
WORKDIR "/src/Microservice.Product.API"
RUN dotnet build "Microservice.Product.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Microservice.Product.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Microservice.Product.API.dll"]

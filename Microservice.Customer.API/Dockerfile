#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-focal AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0-focal AS build
WORKDIR /src
COPY ["Microservice.Customer.API/Microservice.Customer.API.csproj", "Microservice.Customer.API/"]
RUN dotnet restore "Microservice.Customer.API/Microservice.Customer.API.csproj"
COPY . .
WORKDIR "/src/Microservice.Customer.API"
RUN dotnet build "Microservice.Customer.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Microservice.Customer.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Microservice.Customer.API.dll"]

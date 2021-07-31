#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-focal AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0-focal AS build
WORKDIR /src
COPY ["Microservice.APIGateway/Microservice.APIGateway.csproj", "Microservice.APIGateway/"]
RUN dotnet restore "Microservice.APIGateway/Microservice.APIGateway.csproj"
COPY . .
WORKDIR "/src/Microservice.APIGateway"
RUN dotnet build "Microservice.APIGateway.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Microservice.APIGateway.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Microservice.APIGateway.dll"]

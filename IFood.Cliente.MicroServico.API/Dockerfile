#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["IFood.Cliente.MicroServico.API/IFood.Cliente.MicroServico.API.csproj", "IFood.Cliente.MicroServico.API/"]
COPY ["IFood.Cliente.Domain/IFood.Cliente.Domain.csproj", "IFood.Cliente.Domain/"]
COPY ["IFood.Cliente.Services/IFood.Cliente.Services.csproj", "IFood.Cliente.Services/"]
COPY ["IFood.Cliente.Repository/IFood.Cliente.Repository.csproj", "IFood.Cliente.Repository/"]
RUN dotnet restore "IFood.Cliente.MicroServico.API/IFood.Cliente.MicroServico.API.csproj"
COPY . .
WORKDIR "/src/IFood.Cliente.MicroServico.API"
RUN dotnet build "IFood.Cliente.MicroServico.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "IFood.Cliente.MicroServico.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "IFood.Cliente.MicroServico.API.dll"]
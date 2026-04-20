# =========================
# Imagem base (runtime)
# =========================
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 5004

# =========================
# Build da aplicação
# =========================
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copia a solution
COPY ["AppControleMantec.sln", "."]

# Copia os projetos (IMPORTANTE: nomes iguais aos seus)
COPY ["AppControleMantec.API/AppControleMantec.API.csproj", "AppControleMantec.API/"]
COPY ["AppControleMantec.Application/AppControleMantec.Application.csproj", "AppControleMantec.Application/"]
COPY ["AppControleMantec.Domain/AppControleMantec.Domain.csproj", "AppControleMantec.Domain/"]
COPY ["AppControleMantec.Domain.Test/AppControleMantec.Domain.Test.csproj", "AppControleMantec.Domain.Test/"]
COPY ["AppControleMantec.Infra.Data.Mongo/AppControleMantec.Infra.Data.Mongo.csproj", "AppControleMantec.Infra.Data.Mongo/"]
COPY ["AppControleMantec.Infra.IoC/AppControleMantec.Infra.IoC.csproj", "AppControleMantec.Infra.IoC/"]

# Restaura dependências
RUN dotnet restore

# Copia todo o restante do código
COPY . .

# Define projeto principal (API)
WORKDIR "/src/AppControleMantec.API"

# Build
RUN dotnet build "AppControleMantec.API.csproj" -c Release -o /app/build

# =========================
# Publish
# =========================
FROM build AS publish
RUN dotnet publish "AppControleMantec.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

# =========================
# Imagem final
# =========================
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "AppControleMantec.API.dll"]

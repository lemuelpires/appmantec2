# Imagem base do ASP.NET para execução do container final
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 5004

# Imagem SDK do .NET para construção e publicação da aplicação
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copia o arquivo de solução e os arquivos .csproj de cada camada
COPY ["sigmaBack.sln", "."]
COPY ["sigmaBack.API/sigmaBack.API.csproj", "sigmaBack.API/"]
COPY ["sigmaBack.Application/sigmaBack.Application.csproj", "sigmaBack.Application/"]
COPY ["sigmaBack.Domain/sigmaBack.Domain.csproj", "sigmaBack.Domain/"]
COPY ["sigmaBack.Domain.Test/sigmaBack.Domain.Test.csproj", "sigmaBack.Domain.Test/"]
COPY ["sigmaback.Infra.Data/sigmaback.Infra.Data.csproj", "sigmaback.Infra.Data/"]
COPY ["sigmaBack.Infra.IoC/sigmaBack.Infra.IoC.csproj", "sigmaBack.Infra.IoC/"]

# Restaura as dependências do projeto
RUN dotnet restore

# Copia o restante do código para o contexto de build
COPY . .
WORKDIR "/src/sigmaBack.API"

# Compila a aplicação
RUN dotnet build "sigmaBack.API.csproj" -c Release -o /app/build

# Etapa de publicação da aplicação
FROM build AS publish
RUN dotnet publish "sigmaBack.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Imagem final que usará a publicação para executar a aplicação
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

# Comando de inicialização do container
ENTRYPOINT ["dotnet", "sigmaBack.API.dll"]
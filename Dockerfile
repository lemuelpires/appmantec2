FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copia apenas os projetos
COPY ["AppControleMantec.API/AppControleMantec.API.csproj", "AppControleMantec.API/"]
COPY ["AppControleMantec.Application/AppControleMantec.Application.csproj", "AppControleMantec.Application/"]
COPY ["AppControleMantec.Domain/AppControleMantec.Domain.csproj", "AppControleMantec.Domain/"]
COPY ["AppControleMantec.Infra.Data.Mongo/AppControleMantec.Infra.Data.Mongo.csproj", "AppControleMantec.Infra.Data.Mongo/"]
COPY ["AppControleMantec.Infra.IoC/AppControleMantec.Infra.IoC.csproj", "AppControleMantec.Infra.IoC/"]

RUN dotnet restore "AppControleMantec.API/AppControleMantec.API.csproj"

# Copia o restante
COPY . .

WORKDIR "/src/AppControleMantec.API"
RUN dotnet publish -c Release -o /app/publish

# Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "AppControleMantec.API.dll"]
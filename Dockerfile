# Etapa 1 — build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copia o csproj e restaura dependências
COPY *.csproj ./
RUN dotnet restore

# Copia o restante do código
COPY . ./
RUN dotnet publish -c Release -o out

# Etapa 2 — runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app

COPY --from=build /app/out .

# Porta padrão da API
EXPOSE 8080

# Comando para subir a API
ENTRYPOINT ["dotnet", "MinhaApi31.dll"]

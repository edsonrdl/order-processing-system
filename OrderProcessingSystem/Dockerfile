# Etapa 1: Construção
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /app

# Copiar todos os arquivos para o contêiner
COPY . ./

# Restaurar as dependências
RUN dotnet restore

# Publicar a aplicação como self-contained para Linux
RUN dotnet publish "./OrderProcessingSystem.csproj" -c Release -r linux-x64 --self-contained true --output /app/publish

# Etapa 2: Execução
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish ./

# Expor a porta desejada
EXPOSE 80

# Comando de entrada para iniciar o aplicativo (se for self-contained)
ENTRYPOINT ["./OrderProcessingSystem"]

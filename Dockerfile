# Define a imagem base com .NET SDK e Node.js
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Instala Node.js
RUN apt-get update && apt-get install -y curl \
    && curl -sL https://deb.nodesource.com/setup_18.x | bash - \
    && apt-get install -y nodejs

# Define o diretório de trabalho dentro do contêiner
WORKDIR /app

# Copia os arquivos de projeto para o diretório de trabalho
COPY backend/GerenciadorClientes.Api/GerenciadorClientes.Api.csproj backend/GerenciadorClientes.Api/
COPY backend/GerenciadorClientes.Application/GerenciadorClientes.Application.csproj backend/GerenciadorClientes.Application/
COPY backend/GerenciadorClientes.Domain/GerenciadorClientes.Domain.csproj backend/GerenciadorClientes.Domain/
COPY backend/GerenciadorClientes.Infrastructure/GerenciadorClientes.Infrastructure.csproj backend/GerenciadorClientes.Infrastructure/
COPY frontend/gerenciador-clientes.frontend/package.json frontend/gerenciador-clientes.frontend/
COPY frontend/gerenciador-clientes.frontend/package-lock.json frontend/gerenciador-clientes.frontend/

# Restaura as dependências dos projetos
RUN dotnet restore backend/GerenciadorClientes.Api/GerenciadorClientes.Api.csproj

# Copia todo o código-fonte para o diretório de trabalho
COPY . ./

# Instala dependências do frontend e constrói o frontend
WORKDIR /app/frontend/gerenciador-clientes.frontend
RUN npm install
RUN npm run build

# Retorna ao diretório de trabalho original e publica o projeto principal
WORKDIR /app
RUN dotnet publish backend/GerenciadorClientes.Api/GerenciadorClientes.Api.csproj -c Release -o out

# Define a imagem base para a aplicação
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime

# Define o diretório de trabalho dentro do contêiner
WORKDIR /app

# Copia os arquivos publicados para o diretório de trabalho
COPY --from=build /app/out ./

# Define o comando de inicialização da aplicação
ENTRYPOINT ["dotnet", "GerenciadorClientes.Api.dll"]

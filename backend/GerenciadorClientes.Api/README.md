# GerenciadorClientes API

Este projeto é uma implementação de uma API de gerenciamento de clientes seguindo os princípios do Domain-Driven Design (DDD) e Command Query Responsibility Segregation (CQRS).

## Tecnologias Utilizadas

- **.NET 8**: Framework utilizado para o desenvolvimento da aplicação.
- **Entity Framework Core**: Para interagir com o banco de dados relacional (SQL Server LocalDB).
- **MongoDB**: Banco de dados NoSQL local utilizado para leitura.
- **MediatR**: Para mensageria interna e implementação do padrão CQRS.
- **Swagger**: Para documentação e testes da API.
- **SQL Server LocalDB**: Banco de dados relacional para facilitar a execução local.
- **FluentValidation**: Para validação de comandos e consultas.
- **SPA (Single Page Application)**: Implementação de frontend utilizando Angular.

## Arquitetura

- **Domain**: Contém as entidades de domínio e eventos.
- **Application**: Contém comandos, consultas, manipuladores e interfaces de repositório de leitura.
- **Infrastructure**: Contém a implementação dos repositórios e contextos de dados.
- **API**: Camada de apresentação, contém os controladores.
- **Frontend**: Implementação de Single Page Application (SPA) para interação com a API.

### Funcionalidades

- **Cadastro de Clientes**: Inclui operações de criação, leitura, atualização e exclusão (CRUD).
- **CQRS Implementado**: Separação clara entre operações de escrita e leitura.
- **Mensageria Interna**: Utilização do MediatR para comunicação entre componentes da aplicação para sincronizar dados entre o banco de escrita e leitura.
- **Validação com FluentValidation**: Validações de comandos de entrada.
- **Interface SPA**: Interface de usuário moderna e reativa utilizando o framework de SPA Angular.

## Executando o Projeto

### Pré-requisitos

- **.NET 8 SDK**: [Download .NET 8](https://dotnet.microsoft.com/download/dotnet/8.0)
- **MongoDB**: Instale e execute uma instância local do MongoDB [Download MongoDB](https://www.mongodb.com/try/download/community)
- **Node.js**: Para executar a aplicação SPA [Download Node.js](https://nodejs.org/)

### Configuração

### Instalar o `dotnet-ef` e criar banco sql server local

Para utilizar as ferramentas do Entity Framework Core, é necessário instalar a ferramenta `dotnet-ef` globalmente:

```sh
dotnet tool install --global dotnet-ef

E após executar o comando:

```sh
dotnet ef database update



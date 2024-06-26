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
- **Karma e Jasmine**: Frameworks de teste para a frontend Angular.
- **NSubstitute e xUnit**: Para testes unitários no backend.

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

### Instalar o `dotnet-ef` e criar banco SQL Server local

Para utilizar as ferramentas do Entity Framework Core, é necessário instalar a ferramenta `dotnet-ef` globalmente:

```sh
dotnet tool install --global dotnet-ef
```

E após executar o comando:
```sh
dotnet ef database update
```

## Estrutura do Projeto
GerenciadorClientes/
│
├── backend/
│   ├── GerenciadorClientes.API/
│   │   ├── Controllers/
│   │   ├── Program.cs
│   │   └── ...
│   ├── GerenciadorClientes.Application/
│   │   ├── Commands/
│   │   ├── Queries/
│   │   ├── EventHandlers/
│   │   └── ...
│   ├── GerenciadorClientes.Domain/
│   │   ├── Entities/
│   │   ├── Events/
│   │   ├── IRepositories/
│   │   └── ...
│   ├── GerenciadorClientes.Infrastructure/
│   │   ├── Data/
│   │   ├── Repositories/
│   │   └── ...
│   └── GerenciadorClientes.Tests/
│       ├── Application/
│       │   ├── Commands/
│       │   ├── Queries/
│       │   ├── EventHandlers/
│       │   └── ...
│
├── frontend/
│   ├── gerenciador-clientes.frontend/
│       ├── src/
│       │   ├── app/
│       │   │   ├── components/
│       │   │   │   ├── cliente-form/
│       │   │   │   ├── cliente-list/
│       │   │   ├── models/
│       │   │   ├── services/
│       │   │   └── ...
│       │   ├── assets/
│       │   ├── environments/
│       │   ├── index.html
│       │   └── main.ts
│
└── README.md

## Back-end

O backend é desenvolvido utilizando .NET 8, seguindo os princípios do Domain-Driven Design (DDD) e CQRS. Utilizamos Entity Framework Core para interação com o banco de dados SQL Server LocalDB e MongoDB para a leitura. A comunicação entre componentes é feita utilizando MediatR.

### Testes Unitários

Os testes unitários para comandos, consultas e manipuladores de eventos são implementados utilizando xUnit e NSubstitute para mock. Estes testes garantem a integridade das operações de criação, leitura, atualização e exclusão (CRUD) e a correta publicação de eventos.

### Executando os Testes

Para executar os testes unitários, utilize o seguinte comando no diretório do projeto de testes:

```sh
dotnet test
```

## Front-end

O front-end é uma Single Page Application (SPA) desenvolvida em Angular. Utilizamos Karma e Jasmine para implementar e executar testes unitários para garantir a qualidade do código.

### Estrutura do Front-end

O front-end é organizado em componentes, serviços e modelos para facilitar a manutenção e a escalabilidade da aplicação.

### Executando a Aplicação

Para executar a aplicação front-end, utilize os seguintes comandos:

```sh
npm install
ng serve
```

Executando os Testes
Para executar os testes unitários do front-end, utilize o seguinte comando:

```sh
ng test
```

## Informações Complementares
Uso da Biblioteca SpaProxy
Utilizamos a biblioteca Microsoft.AspNetCore.SpaProxy para facilitar o desenvolvimento da aplicação. Esta biblioteca permite redirecionar solicitações de uma aplicação ASP.NET Core para uma aplicação SPA em execução, permitindo desenvolvimento e depuração mais simples e integrados.

Estrutura do Projeto
Todo o código do backend e frontend está contido em uma única solução, organizada em pastas backend e frontend para facilitar a navegação e a manutenção.

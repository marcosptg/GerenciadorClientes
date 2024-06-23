# GerenciadorClientes API

Este projeto � uma implementa��o de uma API de gerenciamento de clientes seguindo os princ�pios do Domain-Driven Design (DDD) e Command Query Responsibility Segregation (CQRS).

## Tecnologias Utilizadas

- **.NET 8**: Framework utilizado para o desenvolvimento da aplica��o.
- **Entity Framework Core**: Para interagir com o banco de dados relacional (SQL Server LocalDB).
- **MongoDB**: Banco de dados NoSQL local utilizado para leitura.
- **MediatR**: Para mensageria interna e implementa��o do padr�o CQRS.
- **Swagger**: Para documenta��o e testes da API.
- **SQL Server LocalDB**: Banco de dados relacional para facilitar a execu��o local.
- **FluentValidation**: Para valida��o de comandos e consultas.
- **SPA (Single Page Application)**: Implementa��o de frontend utilizando Angular.

## Arquitetura

- **Domain**: Cont�m as entidades de dom�nio e eventos.
- **Application**: Cont�m comandos, consultas, manipuladores e interfaces de reposit�rio de leitura.
- **Infrastructure**: Cont�m a implementa��o dos reposit�rios e contextos de dados.
- **API**: Camada de apresenta��o, cont�m os controladores.
- **Frontend**: Implementa��o de Single Page Application (SPA) para intera��o com a API.

### Funcionalidades

- **Cadastro de Clientes**: Inclui opera��es de cria��o, leitura, atualiza��o e exclus�o (CRUD).
- **CQRS Implementado**: Separa��o clara entre opera��es de escrita e leitura.
- **Mensageria Interna**: Utiliza��o do MediatR para comunica��o entre componentes da aplica��o para sincronizar dados entre o banco de escrita e leitura.
- **Valida��o com FluentValidation**: Valida��es de comandos de entrada.
- **Interface SPA**: Interface de usu�rio moderna e reativa utilizando o framework de SPA Angular.

## Executando o Projeto

### Pr�-requisitos

- **.NET 8 SDK**: [Download .NET 8](https://dotnet.microsoft.com/download/dotnet/8.0)
- **MongoDB**: Instale e execute uma inst�ncia local do MongoDB [Download MongoDB](https://www.mongodb.com/try/download/community)
- **Node.js**: Para executar a aplica��o SPA [Download Node.js](https://nodejs.org/)

### Configura��o

### Instalar o `dotnet-ef` e criar banco sql server local

Para utilizar as ferramentas do Entity Framework Core, � necess�rio instalar a ferramenta `dotnet-ef` globalmente:

```sh
dotnet tool install --global dotnet-ef

E ap�s executar o comando:

```sh
dotnet ef database update



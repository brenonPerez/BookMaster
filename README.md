# BookMaster
## Sobre o projeto
API desenvolvida em .NET 8 adotando príncipios de ***Domain-Driven Design (DDD)*** e ***SOLID*** para uma solução estruturada e eficaz no gerenciamento de livros. O objetivo principal da API é permitir a criação, edição e exclusão de livros, armazenando dados de forma segura em um banco de dados ***MySQL***.

A API segue os padrões ***REST***, utilizando métodos ***HTTP*** adequados para garantir comunicação simples e eficiente. Para facilitar a exploração e o teste dos endpoints, a API conta com uma ***documentação Swagger*** interativa.

## Funcionalidades
- **Cadastro de livros**: Registre um novo livro com nome, autor, editora, ano e resumo.
- **Edição de livros**: Atualize os dados de um livro existente.
- **Exclusão de livros**: Remova um livro do sistema.
- **Consulta de livro**: Pesquise livros pelo seu id.
- **Consulta de livros**: Pesquise livros pelo nome, autor ou editora.
- **Execução automática de migrações**: As migrações são aplicadas automaticamente ao iniciar o projeto.

## Tecnologias Utilizadas
- **.NET 8**
- **Entity Framework Core**
- **MySQL**
- **AutoMapper**
- **Swagger**

### Construido com

![Windows-Badge]
![.Net-Badge]
![MySQL]
![Visual-Studio]
![Swagger-Badge]

## Configuração do Projeto
### Requisitos
- Visual Studio 2022+ ou Visual Studio Code
- Windows 10+ ou Linux/MacOS com [.NET SDK 8.0][net-sdk-link] instalado
- MySQL Server

### Instalação e Execução
1. Clone o repositório:
 ```sh
    git clone https://github.com/brenonPerez/BookMaster.git
 ```

2. Configure a string de conexão do banco de dados no arquivo `appsettings.Development.json`.

3. Execute a API:
```sh
   dotnet run
```

4. Acesse a documentação Swagger para testar os endpoints:
```
   https://localhost:5001/swagger/index.html
```

## Arquitetura do Projeto
O projeto está dividido em três camadas principais:

### 1. **Camada de Infraestrutura (`BookMaster.Infrastructure`)**
- Responsável pelo acesso aos dados.
- Implementa o Entity Framework Core para interagir com o MySQL.
- Contém repositórios abstratos para manipulação de entidades.

### 2. **Camada de Aplicação (`BookMaster.Application`)**
- Contém os casos de uso (UseCases) que representam as regras de negócio.
- Utiliza AutoMapper para transformar entidades em DTOs.

### 3. **Camada de API (`BookMaster.Api`)**
- Exponibiliza os endpoints REST para interação com os livros.
- Implementa filtros globais para tratamento de exceções.

## Estrutura de Diretórios
```
BookMaster/
│── BookMaster.Api/                 # Camada de API
│   ├── Controllers/                # Controladores da API
│   ├── Filters/                    # Filtros globais para exceções
│   ├── Program.cs                  # Configuração principal da API
│
│── BookMaster.Application/         # Camada de Aplicação
│   ├── AutoMapper/                 # Configurações do AutoMapper
│   ├── UseCases/Books/             # Casos de uso para livros
│
│── BookMaster.Domain/              # Domínio da aplicação
│   ├── Entities/                   # Entidades do domínio
│   ├── Repositories/               # Interfaces para repositórios
│
│── BookMaster.Infrastructure/      # Infraestrutura e persistência
│   ├── DataAccess/                 # Configuração do EF Core
│   ├── Migrations/                 # Migrações do banco de dados
│
│── BookMaster.sln                  # Solução do projeto
```

## Endpoints Disponíveis
### Criar um novo livro
```
POST /api/books
```
**Corpo da requisição:**
```json
{
  "title": "O Senhor dos Anéis",
  "author": "J.R.R. Tolkien",
  "publisher": "HarperCollins",
  "year": 1954,
  "summary": "Uma história épica sobre a jornada de um hobbit."
}
```
### Consultar livros por filtros
```
GET /api/books/search?title=O Senhor dos Anéis
```
### Consultar livro por ID
```
GET /api/books/{id}
```
### Atualizar um livro
```
PUT /api/books/{id}
```
**Corpo da requisição:**
```json
{
  "title": "O Hobbit",
  "author": "J.R.R. Tolkien",
  "publisher": "HarperCollins",
  "year": 1937,
  "summary": "A jornada de Bilbo Bolseiro."
}
```
### Excluir um livro
```
DELETE /api/books/{id}
```


<!-- LINKS -->
[net-sdk-link]: https://dotnet.microsoft.com/en-us/download/dotnet/8.0

<!-- BADGES -->
[Windows-Badge]: https://img.shields.io/badge/Windows-blue?style=for-the-badge&logo=windows

[.Net-Badge]: https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white

[MySQL]: https://img.shields.io/badge/MySQL-005C84?style=for-the-badge&logo=mysql&logoColor=white

[Visual-Studio]: https://img.shields.io/badge/Visual_Studio-5C2D91?style=for-the-badge&logo=visual%20studio&logoColor=white

[Swagger-Badge]: https://img.shields.io/badge/SWAGGER-darkgreen?style=for-the-badge&logo=swagger


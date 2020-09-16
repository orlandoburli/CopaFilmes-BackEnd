# Projeto CopaFilmes - Backend
  
## Projetos
  * **Movies.API** - É o projeto que contém a API do projeto.
  * **Movies.UnitTests** - Projeto que contém os testes unitários da API.


## Requisitos

  * DotNet Core 3.1
  * Visual Studio (projeto foi desenvolvido com a versão 8.7.6 for MAC) **(opcional)**

## Como executar

  Primeiramente, baixar as dependências usando o NuGet (deve estar na pasta raiz do solução):
  ```
  dotnet restore
  ```

  Depois, compilar a solução com o comando abaixo (deve estar na pasta raiz do solução):
  ```
  dotnet build
  ```

  Depois, para executar o projeto como desenvolvedor:

   ```
  dotnet run --project Movies.API/Movies.API.csproj
  ```

  Para ver a api em funcionamento, acesse o endereço https://localhost:5001/api/movies

## Testes automatizados

  Para rodar os testes automatizados, execute (deve estar na pasta raiz da solução):

  ```
  dotnet test
  ```

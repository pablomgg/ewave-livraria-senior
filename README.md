# Processo Seletivo Sênior - Ewave

![](https://cdn.discordapp.com/attachments/690570572341444608/799833200913940520/Vanilla-6.3s-280px.gif)

Prova seletiva para cargo de senior na Ewave do Brasil. 
Foi escolhido o tema da livraria ToDo.

------------

## Funcionalidades

- #### Instituição de Ensino
    Permite consultar, criar, alterar e mudar a situação de um cadastro. 
    *Obrigatorio para criar um usuário.
- #### Usuario
    Permite consultar, criar, alterar e mudar a situação de um cadastro.
- #### Autor
    Permite consultar, criar, alterar e mudar a situação de um cadastro.
    *Obrigatorio para criar um livro.
- #### Gênero
    Permite consultar, criar, alterar e mudar a situação de um cadastro.
    *Obrigatorio para criar um livro.
- #### Livro
    Permite consultar, criar, alterar e mudar a situação de um cadastro.
- #### Empréstimo
    Permite consultar, criar e devolver um livro.

------------

## Como instalar
**Antes de qualquer coisa, prepare o ambiente de desenvolvimento** 
* Instale o [Git](https://git-scm.com/downloads "git")
* Instale o [Docker](https://app.dbdesigner.net/signup "docker")
* Certifique-se também que as portas `5555`, `64978` e `1433` estão liberadas.
 
------------

## Executando o Projeto
* Faça um clone do projeto
* Acesse o mesmo
* Rode o comando docker.
 ```sh
git clone https://github.com/pablomorigi/ewave-livraria-senior.git
cd ewave-livraria-senior
docker-compose up --build
 ```

**Após a finalização do build, o link poderá ser acessado para front-end clicando [aqui](http://localhost:5555/ "front") e para o swagger clicando [aqui](http://localhost:64978/swagger/ "swagger")**

## Tecnologias usadas no projeto

### Front-end

- Angular 9
- RxJS
- Ngx-bootstrap
- Angular Material

### Back-end

- .Net Core 3.1
- EntityFramework
- DDD
- UnitOfWork pattern
- Repository pattern
- Service pattern
- Dapper
- Test de unidade
- Swagger
- Conteinerização
- SQL

## Features a serem implementadas
#### Frond-end

- UX
- Componentização
- Responsividade

#### Back-end

- Testes de services
- CQRS.
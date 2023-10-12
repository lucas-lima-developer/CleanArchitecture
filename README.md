# Clean Architecture

Projeto desenvolvido como uma prática para aplicar os princípios da arquitetura limpa utilizando ASP.NET Core 7 e SQLite.

Foi feito um simples CRUD de usuário utilizando:
- **MediatR**: Implementa o padrão de projeto Mediator.
- **FluentValidation**: biblioteca para validação de modelos
- **EntityFrameworkCore** : Uma versão do popular ORM Entity Framework que oferece suporte ao SQLite
- **AutoMapper** : Uma biblioteca que simplifica a transformação de objetos em .NET

---

<p align="center">
  <img src="https://github.com/lucas-lima-developer/CleanArchitecture/assets/58302967/6c9c3dd2-7627-4de0-a101-2b331bd5dba6" alt="Imagem 1">
</p>

## Sobre Arquitetura limpa 

A Clean Architecture é um padrão de design de software que tem como objetivo principal promover a organização e a clareza na estrutura de um aplicativo. Ela proporciona uma separação clara de responsabilidades entre as diferentes camadas do sistema.

# Principais componentes
- **Domínio (Domain)**: Nesta camada, reside a lógica de negócio e as entidades essenciais do domínio. Aqui você encontrará as definições de entidades, regras de negócio e interfaces de serviços.
- **Aplicação (Application)**:  Esta camada coordena as operações do sistema, utilizando os conceitos do Domínio para executar tarefas específicas.
- **Infraestrutura (Infrastructure)**: Contém os detalhes de implementação técnica, como acesso a banco de dados, configurações de ORM, entre outros.

---

<p align="center">
  <img src="https://github.com/lucas-lima-developer/CleanArchitecture/assets/58302967/f336bac1-28c5-4386-bba7-a246182ccdc9" alt="Imagem 2">
</p>

---

Estudo realizado acompanhando playlist: 
<a href="https://youtube.com/playlist?list=PLJ4k1IC8GhW3GICba2dLmiTZrVPw0SthC&si=Ec1toQ3TrN5Bx2XO">Link para a playlist</a>


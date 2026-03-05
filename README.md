# ASP.NET Pro Blog

Um sistema de blog moderno, rápido e responsivo, construído com as melhores práticas do ecossistema .NET. Este projeto utiliza a arquitetura Razor Pages para entregar uma experiência robusta focada em separação de responsabilidades (MVVM), performance e SEO.

![.NET](https://img.shields.io/badge/.NET-10.0-512BD4?logo=dotnet)
![C#](https://img.shields.io/badge/C%23-10%2B-239120?logo=csharp)
![Bootstrap](https://img.shields.io/badge/Bootstrap-5.2-7952B3?logo=bootstrap)

## Funcionalidades

* **Leitura de Artigos:** Visualização detalhada de posts com suporte a formatação rica de conteúdo.
* **Sistema de Comentários:** Interação direta dos leitores nos artigos, com validação de dados no lado do cliente e do servidor.
* **Categorização e Tags:** Organização eficiente de conteúdo, permitindo filtragem rápida.
* **Busca Integrada:** Motor de busca dinâmico para encontrar posts por título, resumo ou conteúdo.
* **Componentes Reutilizáveis:** Utilização avançada de `ViewComponents` para renderização independente (ex: Sidebar de categorias) e `Partial Views`.
* **Design Responsivo:** Interface limpa e adaptável a dispositivos móveis, desenvolvida com Bootstrap 5.

## Tecnologias e Padrões Utilizados

* **Framework:** ASP.NET Core Razor Pages (.NET 10)
* **Linguagem:** C# 10 / 12 (com uso de Primary Constructors)
* **ORM:** Entity Framework Core (com projeção de ViewModels via LINQ para otimização de performance)
* **Front-end:** HTML5, CSS3, Bootstrap 5.2, jQuery (para validações Unobtrusive)
* **Arquitetura/Design Patterns:**
  * Padrão MVVM (Model-View-ViewModel)
  * Injeção de Dependência (DI)
  * Repository Pattern / Encapsulamento de Data Access
  * Execução Assíncrona (Async/Await) para escalabilidade

## Roadmap e Próximos Passos
[X] Deploy em ambiente de produção (Microsoft Azure).<br>
*Porém estou pensado em migrar para Oracle OCI porque ela oferece uma VM gratis para testes.*

[ ] Configurar o mailgun para enviar emails de dentro do blog.

[ ] Área Administrativa (CRUD completo para Posts, Categorias e aprovação de Comentários).

[ ] Sanitização de HTML (XSS Protection) no conteúdo dos posts.

[ ] Pipelines de CI/CD utilizando Azure DevOps.

[ ] Implementação de Paginação Assíncrona na Home.

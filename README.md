AspNetPro.Blog README

<div align="center">
  <img src="https://capsule-render.vercel.app/api?type=waving&color=auto&height=200&section=header&text=AspNetPro.Blog&fontSize=60&theme=dracula" />
</div>

# AspNetPro.Blog

**Um sistema de blog moderno, rápido e responsivo, construído com as melhores práticas do ecossistema .NET.**  
Arquitetura baseada em **Razor Pages** com foco em separação de responsabilidades, performance e SEO.

---

### Visão Geral

AspNetPro.Blog é uma plataforma de conteúdo pensada para ser simples de manter e fácil de evoluir. Prioriza performance, segurança e experiência do leitor, oferecendo recursos essenciais para publicação e interação.

---

### Funcionalidades Principais

- **Leitura de Artigos**: Visualização detalhada de posts com suporte a formatação rica.
- **Sistema de Comentários**: Envio e carregamento de comentários com validação cliente/servidor.
- **Categorização e Tags**: Organização de conteúdo com filtros rápidos.
- **Busca Integrada**: Busca por título, resumo e conteúdo.
- **Componentes Reutilizáveis**: ViewComponents e Partial Views para renderização independente.
- **Design Responsivo**: Interface adaptada para dispositivos móveis com Bootstrap 5.
- **SEO**: Robots.txt e Sitemap gerados; roteamento otimizado.

---

### Tecnologias e Padrões

- **Framework**: ASP.NET Core Razor Pages (.NET 10)  
- **Linguagem**: C# 10 / 12  
- **ORM**: Entity Framework Core (projeções via LINQ)  
- **Front-end**: HTML5, CSS3, Bootstrap 5.2, jQuery (validações Unobtrusive)  
- **Padrões**: MVVM, Injeção de Dependência, Repository Pattern, Async/Await

---

### Roadmap e Próximos Passos

- **Concluído**
  - Deploy em ambiente de produção (Microsoft Azure) ✅
  - Robots.txt adicionado ✅
  - Sitemap adicionado ✅
  - Resolver de rotas adicionado ✅
  - CRUD de posts completo ✅
  - Painel administrativo inicial criado ✅
  - Inclusão de posts via painel ✅
  - Configurações secretas adicionadas ✅
  - Configurar Mailgun para envio de e-mails ✅
    
- **Em planejamento**
  - Migrar ambiente de testes para Oracle OCI (VM gratuita para testes) — avaliação em andamento
  - Área Administrativa completa (CRUD para Posts, Categorias, aprovação de Comentários)
  - Sanitização de HTML para proteção contra XSS
  - Pipelines de CI/CD com Azure DevOps
  - Implementação de paginação assíncrona na Home

---

### Como Rodar Localmente

1. **Pré requisitos**
   - .NET 10 SDK
   - PostgreSQL ou outro banco compatível
   - Node.js (opcional para tarefas front-end)

2. **Clonar repositório**
   ```bash
   git clone https://github.com/rodrigomorello6/ASPNET-BlogPro.git
   cd ASPNET-BlogPro/src/AspNetPro.Blog


Configurar variáveis

Copiar appsettings.Development.json.example para appsettings.Development.json

Ajustar connection string e chaves secretas

Executar migrações e iniciar
```bash
dotnet ef database update
dotnet run
```

---
Estrutura do Projeto

/Pages — Razor Pages e handlers

/ViewComponents — Componentes reutilizáveis (sidebar, listagens)

/Data — Migrations e contexto EF Core

/Services — Serviços de domínio e integrações

/wwwroot — Assets estáticos (CSS, JS, imagens)
---
Boas Práticas e Qualidade

Performance: projeções via LINQ para reduzir carga de memória

Segurança: validação cliente/servidor; próximo passo: sanitização de HTML

Manutenibilidade: separação de responsabilidades e patterns claros

DevOps: preparar pipelines de CI/CD para builds, testes e deploy automatizados

---
Contato

Autor: Rodrigo Morello

GitHub: https://github.com/rodrigomorello6 (github.com in Bing)

LinkedIn: https://www.linkedin.com/in/rodrigo-morello-dev/


# ControllRR 🔧
![GitHub License](https://img.shields.io/github/license/tcruzf/AuthProjeto?style=flat-square)
![GitHub Last Commit](https://img.shields.io/github/last-commit/tcruzf/AuthProjeto?style=flat-square)
![GitHub Issues](https://img.shields.io/github/issues/tcruzf/AuthProjeto?style=flat-square)

Sistema para controle de manutenções e gestão de produtos com interface web.

📌 **Recursos Principais:**
- Gestão de ordens de serviço
- Controle de estoque de produtos
- Autenticação de usuários
- Dashboard de métricas
- Registro de manutenções preventivas e corretivas

## 📋 Índice
- [Pré-requisitos](#pré-requisitos)
- [Instalação](#instalação)
- [Configuração](#configuração)
- [Funcionalidades](#funcionalidades)
- [Contribuição](#contribuição)
- [Licença](#licença)
- [Contato](#contato)

## 🛠️ Pré-requisitos
- .NET 6.0 SDK
- MariaDB 10.11+
- Entity Framework Core CLI

## 🚀 Instalação
```bash
git clone https://github.com/tcruzf/AuthProjeto.git
cd AuthProjeto
dotnet restore

dotnet ef migrations remove -f --project ControllRR.Infrastructure
dotnet ef migrations add InitialMigration --project ControllRR.Infrastructure --output-dir Data/Migrations
dotnet ef database update --project ControllRR.Infrastructure
var adminEmail = "admin@controllrr.com";
var createResult = await userManager.CreateAsync(user, "SenhaSegura123##");
Caso queira, poderá gerar um arquivo sql após as alterações:
/usr/bin/dotnet ef migrations --project ControllRR.Infrastructure script -o database.sql
```

✨ Funcionalidades
- Módulo	Status	Descrição
- Autenticação	✅ Completo	Login com roles de usuário
- Manutenções	🚧 Em Desenv.	Registro de ordens de serviço
- Estoque	🚧 Em Desenv.	Gestão de produtos e inventário
- Dashboard	⏳ Planejado	Métricas operacionais
- Relatórios	⏳ Planejado	Exportação de dados em PDF/Excel
- 🤝 Contribuição
- Faça um Fork do projeto

Crie sua Branch:

```bash

git checkout -b feature/nova-feature
Commit suas mudanças:


git commit -m 'feat: Adiciona nova funcionalidade'
Push para a Branch:

git push origin feature/nova-feature
Abra um Pull Request
```


📄 Licença
Distribuído sob licença MIT. Veja LICENSE para mais detalhes.

📧 Contato
Thiago Cruz
LinkedIn
Email: thiago@prefirolinux.com

Preview do Sistema
Dashboard Preview


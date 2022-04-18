[![Build](https://github.com/wellingtoong/GISA/actions/workflows/dotnet.yml/badge.svg)](https://github.com/wellingtoong/GISA/actions/workflows/dotnet.yml)

# TCC PUC Minas
Este projeto aborda a aplicabilidade da tecnologia no contexto de saúde, visando integrar soluções e conectar pessoas através de sistemas, afim de modernizar e aprimorar os serviços prestados pelas operadoras de saúde do país. Com o mundo sofrendo com a pandemia causada pelo vírus COVID-19 os problemas já conhecidos envolvendo a área da saúde pública e privada ganharam proporções ainda maiores, no entanto, também impulsionaram empresas a buscarem alternativas cada vez mais eficazes na tentativa de minimizar os problemas. A criação da arquitetura GISA visa melhorar a concepção e gestão de informações de usuários para maior controle, análise, flexibilidade e agilidade no atendimento.  O layout pensado na usabilidade final dos usuários com a utilização de um serviço moderno e intuitivo, facilita o controle de acesso, proporciona maior segurança no tráfico de dados, integra APIs de serviços internas e externas, provendo maior consistência e disponibilidade do produto. A padronização da arquitetura, prove a criação e integração de novos recursos, micro serviços, utilização de frameworks, dentre outros, tornando assim um sistema escalável e integrativo com alto esquema manutenibilidade e evolução.

## GISA
Gestão Integral da Saúde do Associado (GISA), é uma proposta arquitetural completa e totalmente integrada, constituída de módulos funcionais, que deve incorporar e/ou integrar os recursos existentes nos sistemas SAF, SGPS e SAS do modelo fictício do Boa Saúde.

## Macroarquitetura
![Macroarquitetura TCC (3)](https://user-images.githubusercontent.com/21322533/163737229-eb7bf8ab-98ca-45eb-b5b9-9b875f060f16.jpg)

## Interfaces disponiveis

| Serviço | URLs |
| ------ | ------ |
| Aplicação Web | https://localhost:44314/login |
| GISA Identity API | https://localhost:44389/swagger/index.html |
| GISA Convenios API | https://localhost:44309/swagger/index.html |
| GISA Pessoa API | https://localhost:44334/swagger/index.html |

## Tecnologias
- ASP NET Core v3.1
- Microsoft Identity
- Entity Framework Core
- Migrations
- AutoMapper
- RabbitMQ
- Swagger
- Docker

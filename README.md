# 🌊 My Aquarium Manager 🐠

**Faça o gerenciamento dos seus tanques com facilidade!**

My Aquarium Manager é uma aplicação web desenvolvida em ASP.NET Core MVC, projetada para auxiliar aquaristas a monitorar e gerenciar seus aquários e tanques de forma eficiente. O objetivo é proporcionar uma ferramenta intuitiva para acompanhar parâmetros, registrar eventos e manter a saúde do seu ecossistema aquático.

O projeto nasce depois da realização do curso de ASP.NET Core MVC da plataforma Next Wave Education do Luis Felipe, então, com o intuíto de fidelizar o que foi aprendido, eu um aquarista entusiasmado e iniciante resolvi desenvolver essa aplicação.

---

## 🚀 Tecnologias Utilizadas

* **ASP.NET Core MVC:** Para a estrutura web da aplicação.
* **C#:** Linguagem de programação principal.
* **Entity Framework Core:** ORM para persistência de dados.
* **SQL Server:** Banco de dados relacional.
* **Docker:** Para um ambiente de desenvolvimento isolado e fácil de configurar.
* **Arquitetura de Cebola:** Para uma separação clara de responsabilidades, facilitando a testabilidade e manutenção do código.
* **FluentValidation:** Para validação de modelos de entrada (DTOs/ViewModels) na camada web, garantindo a integridade dos dados antes do processamento.
* **xUnit:** Framework de testes de unidade para C#.
---

## 🛠️ Primeiros Passos (Getting Started)

Para rodar este projeto em sua máquina local, certifique-se de ter os seguintes pré-requisitos instalados:

* [.NET SDK 8.0](https://dotnet.microsoft.com/download/dotnet/8.0) ou superior.
* [Docker Desktop](https://www.docker.com/products/docker-desktop/)
* (Opcional) Um cliente SQL como [SQL Server Management Studio (SSMS)](https://docs.microsoft.com/sql/ssms/download-sql-server-management-studio-ssms) ou [Azure Data Studio](https://docs.microsoft.com/sql/azure-data-studio/download-azure-data-studio).

---

## 🐳 Configuração do SQL Server com Docker

Para uma configuração rápida do ambiente de banco de dados, utilizaremos o Docker.

### Passo 1: Instalar o Docker

1.  **Baixar o Docker Desktop:**
    * Acesse o site oficial do Docker: [docker.com](https://www.docker.com/).
    * Clique em “Get Started” e faça o download do Docker Desktop para o seu sistema operacional (Windows ou macOS).
2.  **Instalar o Docker:**
    * Execute o instalador que você baixou.
    * Siga as instruções na tela para concluir a instalação.
    * Após a instalação, inicie o Docker Desktop.
3.  **Verificar a Instalação:**
    * Abra um terminal (Prompt de Comando ou PowerShell no Windows, Terminal no macOS).
    * Execute o comando:
        ```bash
        docker --version
        ```
    * Isso deve retornar a versão do Docker instalada.

### Passo 2: Criar uma Instância do SQL Server

1.  **Baixar a Imagem do SQL Server:**
    * No terminal, execute o seguinte comando para baixar a imagem do SQL Server:
        ```bash
        docker pull mcr.microsoft.com/mssql/server
        ```
2.  **Criar e Executar um Contêiner do SQL Server:**
    * Após o download da imagem, você pode criar e iniciar um contêiner com o seguinte comando:
        ```bash
        docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=SuaSenhaForte123!" -p 1433:1433 --name sqlserver -d mcr.microsoft.com/mssql/server
        ```
    * **Importante:** Substitua `SuaSenhaForte123!` por uma senha forte de sua escolha.
    * O parâmetro `-p 1433:1433` expõe a porta padrão do SQL Server para que você possa se conectar a ele do seu host.

3.  **Verificar se o Contêiner está em Execução:**
    * Execute o comando:
        ```bash
        docker ps
        ```
    * Isso mostrará a lista de contêineres em execução. Você deve ver o seu contêiner do SQL Server (`sqlserver`) na lista.

### Passo 3: Conectar ao SQL Server

Você pode usar ferramentas como SQL Server Management Studio (SSMS), Azure Data Studio ou um cliente de linha de comando:

* **Servidor:** `localhost`
* **Usuário:** `SA`
* **Senha:** A senha que você definiu no Passo 2 (`SuaSenhaForte123!`).

### Passo 4: Gerenciar o Contêiner

* Para **parar** o contêiner:
    ```bash
    docker stop sqlserver
    ```
* Para **iniciar** o contêiner novamente:
    ```bash
    docker start sqlserver
    ```
* Para **remover** o contêiner (se necessário, atenção: isso apaga os dados):
    ```bash
    docker rm sqlserver
    ```

---

## 🗄️ Gerenciamento do Banco de Dados (Entity Framework Core Migrations)

O projeto `MyAquariumManager.Infrastructure` é responsável pela persistência de dados e contém o seu `DbContext`. Para gerenciar o schema do banco de dados, utilizamos o Entity Framework Core Migrations.

**Importante:** Certifique-se de que o **`MyAquariumManager.Infrastructure`** esteja selecionado como o "Default project" no **Package Manager Console** do Visual Studio, ou use o parâmetro `-Project MyAquariumManager.Infrastructure` em todos os comandos.

### 1. Criar uma Nova Migration

Compara seu modelo de dados com o banco de dados atual e gera o código C# para novas alterações.

```powershell
Add-Migration -Name MinhaPrimeiraMigration -Project MyAquariumManager.Infrastructure -OutputDir Data\Migrations
````

### 2. Reverter a Última Migration Adicionada (Apenas arquivos)

Remove o último arquivo de migration criado no seu projeto (útil se você cometeu um erro antes de aplicar ao banco).

```PowerShell
Remove-Migration -Project MyAquariumManager.Infrastructure
```

### 3. Aplicar Todas as Migrations Pendentes

Aplica todas as migrations ainda não aplicadas ao seu banco de dados. Se o banco não existir, ele será criado.

```PowerShell
Update-Database -Project MyAquariumManager.Infrastructure
```
### 4. Reverter para uma Migration Específica

Reverte ou aplica migrations para atingir um estado específico do banco de dados.

```PowerShell
Update-Database -Project MyAquariumManager.Infrastructure -TargetMigration <NomeDaMigration>
```
* Substitua <NomeDaMigration> pelo nome exato da migration para a qual você deseja reverter.
* Para reverter todas as migrations e deixar o banco vazio (removendo todas as tabelas criadas pelo EF Core):
```PoweShell
Update-Database -Project MyAquariumManager.Infrastructure -TargetMigration 0
```
---
## ▶️ Como Rodar a Aplicação
1. Abra a solução MyAquariumManager.sln no Visual Studio.
2. Certifique-se de que o projeto MyAquariumManager.Web esteja definido como o projeto de inicialização.
3. Pressione F5 para compilar e executar a aplicação.
   * Alternativamente, você pode navegar até a pasta MyAquariumManager.Web no terminal e executar:
```Bash
dotnet run
```

## 🏛️ Estrutura do Projeto (Arquitetura de Cebola)
Este projeto segue o padrão de Arquitetura de Cebola (ou Hexagonal), promovendo uma clara separação de responsabilidades e facilitando a manutenibilidade e testabilidade.

* **MyAquariumManager.Core (Domínio):** Contém as entidades de domínio (BaseEntity, Usuario, Conta e entre outras).
* **MyAquariumManager.Application (Aplicação):** Orquestra as operações da aplicação, define casos de uso e interfaces para serviços de domínio e infraestrutura. Lida com DTOs e mapeamentos.
* **MyAquariumManager.Infrastructure (Infraestrutura):** Implementa os contratos (interfaces) definidos na camada de Aplicação. Contém as implementações de persistência (EF Core, Contexto, Migrations), serviços externos e entre outros.
* **MyAquariumManager.Web (Apresentação):** É a interface do usuário (ASP.NET Core MVC). Contém Controllers, Views, ViewModels e toda a configuração da aplicação web.
* **MyAquariumManager.Tests.Unit (Testes de Unidade):** Contém os testes automatizados para as unidades de código das camadas Core, Application e Infrastructure, garantindo a validação do comportamento do domínio e da lógica de negócio. A estrutura de pastas dentro deste projeto espelha as camadas da solução para melhor organização.

## 🧪 Testes Automatizados
Este projeto inclui uma suíte de testes de unidade para garantir a qualidade e o comportamento esperado das diferentes camadas da aplicação.

### MyAquariumManager.Tests.Unit
* **Propósito:** Contém os testes de unidade focados em validar unidades isoladas de código, como entidades de domínio, serviços de aplicação e classes de infraestrutura.
* **Tecnologia:** Utiliza o framework xUnit.
* **Organização:** Os testes são organizados em pastas que espelham a estrutura das camadas do projeto (ex: Core/Entities, Application/Services), facilitando a navegação e o entendimento.

### Como Rodar os Testes:

1. No Visual Studio, vá em Test > Test Explorer (ou Ctrl+E, T).
2. No Test Explorer, clique em Run All Tests para executar todos os testes da solução.
* Alternativamente, você pode navegar até a pasta MyAquariumManager.Tests.Unit no terminal e executar:
```Bash
dotnet test
```

## 📧 Contato
Se tiver dúvidas ou sugestões, sinta-se à vontade para entrar em contato:

Diego Marques
[https://www.linkedin.com/in/diegomarquesaraujo/]
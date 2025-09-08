# 🚀 Entendendo Desafio Técnico - Microserviços  

## 📌 Descrição do Desafio  
Desenvolver uma aplicação com **arquitetura de microserviços** para gerenciamento de **estoque de produtos** e **vendas** em uma plataforma de e-commerce.  

O sistema será composto por **dois microserviços**:  
- **Gestão de Estoque** → responsável pelo cadastro e controle de produtos.  
- **Gestão de Vendas** → responsável pela criação e gerenciamento de pedidos.  

A comunicação será feita via **API Gateway** e **RabbitMQ**, com autenticação baseada em **JWT**.  

---

## 🛠️ Tecnologias Utilizadas  
- **.NET Core (C#)**  
- **Entity Framework Core**  
- **RESTful API**  
- **RabbitMQ** → comunicação entre microserviços  
- **JWT (JSON Web Token)** → autenticação  
- **Banco Relacional (SQL Server ou MySQL)**  
- **API Gateway**  

---

## 📐 Arquitetura Proposta  

### 🔹 Microserviço 1 → Gestão de Estoque  
- Cadastro de produtos (nome, descrição, preço, quantidade).  
- Consulta de catálogo e disponibilidade de estoque.  
- Atualização automática do estoque após vendas.  

### 🔹 Microserviço 2 → Gestão de Vendas  
- Criação de pedidos com validação de estoque.  
- Consulta de status dos pedidos.  
- Notificação de vendas para o serviço de estoque via RabbitMQ.  

### 🔹 API Gateway  
- Ponto único de entrada para as requisições.  
- Roteamento para o microserviço adequado.  

### 🔹 RabbitMQ  
- Comunicação assíncrona entre os microserviços.  
- Notificação de atualização de estoque após vendas.  

### 🔹 Autenticação JWT  
- Garantir que apenas usuários autenticados possam criar pedidos ou consultar estoque.  

---

## ⚙️ Funcionalidades Requeridas  

✅ **Gestão de Estoque**  
- Cadastro de produtos.  
- Consulta de produtos e quantidades.  
- Atualização do estoque após vendas.  

✅ **Gestão de Vendas**  
- Criação de pedidos com validação de estoque.  
- Consulta de status dos pedidos.  
- Notificação de vendas para o estoque.  

✅ **Comum a ambos**  
- Autenticação com JWT.  
- API Gateway centralizando o acesso.  

---

## 💼 Contexto do Negócio  
O sistema simula um **e-commerce**, onde empresas precisam gerenciar produtos e realizar vendas de forma eficiente.  

A arquitetura em microserviços garante:  
- **Escalabilidade** → possibilidade de adicionar novos serviços (ex: pagamentos, envios).  
- **Resiliência** → falhas em um serviço não comprometem o sistema inteiro.  
- **Manutenção facilitada** → separação clara de responsabilidades.  

---

## 📋 Requisitos Técnicos  
- API construída em **.NET Core (C#)**.  
- **Entity Framework** para acesso ao banco relacional.  
- **RabbitMQ** para comunicação assíncrona.  
- **JWT** para autenticação.  
- **API Gateway** para orquestração.  
- Boas práticas de **POO** e **RESTful APIs**.  

---

## ✅ Critérios de Aceitação  
- Cadastro de produtos no microserviço de estoque.  
- Criação de pedidos com validação de estoque no microserviço de vendas.  
- Comunicação entre microserviços via RabbitMQ.  
- API Gateway roteando requisições corretamente.  
- Autenticação via JWT garantindo segurança.  
- Código bem estruturado, seguindo boas práticas.  

---

## 🌟 Extras (Diferenciais)  
- **Testes unitários** para cadastro de produtos e criação de pedidos.  
- **Monitoramento e logs** para rastrear falhas.  
- **Escalabilidade** para novos microserviços no futuro.  

---

📚 **Bons estudos e boa codificação!**

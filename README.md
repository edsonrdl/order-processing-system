# Order Processing System

### Visão Geral
![order-processing-system](https://github.com/user-attachments/assets/6f31e143-0248-4a5b-9f19-30493409732d)

## Aviso Importante
Após a finalização do projeto, será disponibilizado o arquivo `docker-compose.yml` com toda a configuração necessária para criar os containers do RabbitMQ e dos bancos de dados MongoDB para os microserviços em Node.js.

---

## Projeto: Sistema de Processamento de Pedidos com Direct Exchange

### Objetivo

Demonstrar o uso de *Direct Exchange* no RabbitMQ em uma arquitetura de microserviços. Neste exemplo, a API ASP.NET Core atua como publicadora e microserviços em Node.js atuam como consumidores. Mensagens sobre diferentes etapas do processamento do pedido são roteadas para filas apropriadas por meio de *routing keys*.

---

### Estrutura do Projeto

1. **ASP.NET Core API (ProductOrderService):**
   - Recebe solicitações de pedidos e publica mensagens no *Direct Exchange* do RabbitMQ.
   - Define *routing keys* específicas para diferentes etapas do pedido, como `order.new`, `order.payment` e `order.notification`.
   - Utiliza o Swagger para testes e envio de mensagens para as filas.

2. **Node.js Microserviços:**
   - **OrderProcessorService:**
     - Consome mensagens da `order_queue` com *routing key* `order.new`.
   - **PaymentService:**
     - Consome mensagens da `payment_queue` com *routing key* `order.payment`.
   - **NotificationService:**
     - Consome mensagens da `notification_queue` com *routing key* `order.notification`.

---

### Funcionalidade do Sistema

1. **Envio do Pedido:**
   - A API publica uma mensagem com a *routing key* `order.new`, enviada para a fila `order_queue`.
2. **Processamento de Pagamento:**
   - A API publica uma mensagem com a *routing key* `order.payment`, enviada para a fila `payment_queue`.
3. **Notificação ao Usuário:**
   - A API publica uma mensagem com a *routing key* `order.notification`, enviada para a fila `notification_queue`.

---

### Benefícios do *Direct Exchange*

- **Flexibilidade:** Mensagens são roteadas para diferentes filas com base em *routing keys*, permitindo adicionar novos tipos de mensagens sem alterar a estrutura existente.
- **Escalabilidade:** Múltiplos consumidores podem ser adicionados para lidar com mensagens de um tipo específico.
- **Modularidade:** Cada microserviço gerencia um aspecto específico do fluxo de pedidos, facilitando a manutenção.

---

### Configuração da *Exchange*

- **Nome da Exchange:** `service_exchange`

---

### Pré-Requisitos

1. Certifique-se de que o Docker e o Docker Compose estão instalados na sua máquina.

2. Para gerar os containers da API e do RabbitMQ, execute o comando abaixo no diretório raiz do repositório principal:

   ```bash
   docker-compose up -d
   ```

   Isso irá gerar as imagens e iniciar os containers necessários.

3. Verifique se os containers estão rodando corretamente:

   ![Containers da API](https://github.com/user-attachments/assets/7d4ea054-d068-4564-9df9-2d01b92d9f2b)

---

### Teste de Requisições no Swagger

- Acesse o Swagger no seguinte endereço:
  - [http://localhost:9090/swagger/index.html](http://localhost:9090/swagger/index.html)

**Endpoints e Objetos de Teste:**

#### Order
```json
{
  "productName": "Computador",
  "quantity": 7,
  "status": 1
}
```

#### Payment
```json
{
  "orderId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
  "amount": 20,
  "status": 1,
  "paymentDate": "2024-11-25T20:24:56.663Z"
}
```

#### Notification
```json
{
  "orderId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
  "message": "teste",
  "status": 1
}
```

**Tipos de Status:**
- `Pending = 1`
- `Processing = 2`
- `Completed = 3`
- `Cancelled = 4`

---

### Configuração do RabbitMQ

1. Certifique-se de que o container do RabbitMQ está em execução.
2. Acesse a interface do RabbitMQ para visualizar as filas:
   - [http://localhost:15672/#/](http://localhost:15672/#/)

   ![Filas no RabbitMQ](https://github.com/user-attachments/assets/d6736e05-3311-408e-8dd1-f8144a800fa5)

---

### Microserviços (Repositórios)

1. **OrderProcessorService:**
   ```bash
   git clone https://github.com/edsonrdl/micro-service-order.git
   cd micro-service-order
   ```
   Clique para visualizar o README e seguir os passos:
   [OrderProcessorService](https://github.com/edsonrdl/micro-service-order)

2. **PaymentService:**
   ```bash
   git clone https://github.com/edsonrdl/micro-service-payment.git
   cd micro-service-payment
   ```
   Clique para visualizar o README e seguir os passos:
   [PaymentService](https://github.com/edsonrdl/micro-service-payment)

3. **NotificationService:**
   ```bash
   git clone https://github.com/edsonrdl/micro-service-notification.git
   cd micro-service-notification
   ```
   Clique para visualizar o README e seguir os passos:
   [NotificationService](https://github.com/edsonrdl/micro-service-notification)

4. **API Principal (ASP.NET Core):**
   ```bash
   git clone https://github.com/edsonrdl/order-processing-system.git
   cd order-processing-system
   ```

---

### Versões Utilizadas
- RabbitMQ: 3.13.7
- .NET Core: net8.0

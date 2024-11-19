# order-processing-system

### Visão Geral
![order-processing-system](https://github.com/user-attachments/assets/6f31e143-0248-4a5b-9f19-30493409732d)


## Atenção ! Após a finalização do projeto deixarei o docker-compose.ym com toda a confiruração para as imagens do projeto para criação dos container do RabbitMq e dos bancos de dados do Mongodb para os microservicos em Node.js

## Projeto: Sistema de Processamento de Pedidos com Topic Exchange

### Objetivo

Demonstrar o uso de *Topic Exchange* no RabbitMQ em uma arquitetura de microserviços. Neste exemplo, a API ASP.NET Core atua como publicadora e microserviços em Node.js atuam como consumidores. Mensagens sobre diferentes etapas do processamento do pedido são roteadas para filas apropriadas por meio de *routing keys*.

---

### Estrutura do Projeto

1. **ASP.NET Core API (ProductOrderService)**:
   - Recebe solicitações de pedidos e publica mensagens no *Topic Exchange* do RabbitMQ.
   - Define *routing keys* específicas para diferentes etapas do pedido, como `order.new`, `order.payment` e `order.notification`.
   - Utiliza o Swagger para testes e envio de mensagens para as filas.

2. **Node.js Microserviços**:
   - **OrderProcessorService**:
     - Consome mensagens da `order_queue` com *routing key* `order.new`.
   - **PaymentService**:
     - Consome mensagens da `payment_queue` com *routing key* `order.payment`.
   - **NotificationService**:
     - Consome mensagens da `notification_queue` com *routing key* `order.notification`.

---

### Funcionalidade do Sistema

1. **Envio do Pedido**:
   - A API publica uma mensagem com a *routing key* `order.new`, enviada para a fila `order_queue`.
2. **Processamento de Pagamento**:
   - A API publica uma mensagem com a *routing key* `order.payment`, enviada para a fila `payment_queue`.
3. **Notificação ao Usuário**:
   - A API publica uma mensagem com a *routing key* `order.notification`, enviada para a fila `notification_queue`.

---

### Benefícios do *Topic Exchange*

- **Flexibilidade**: As mensagens podem ser roteadas para diferentes filas com base em *routing keys*, permitindo adicionar novos tipos de mensagens sem modificar a estrutura.
- **Escalabilidade**: Múltiplos consumidores podem ser adicionados para lidar com mensagens de um tipo específico.
- **Modularidade**: Cada microserviço cuida de um aspecto do fluxo de pedido, tornando o código mais organizado e fácil de manter.

---

### Configuração da *Exchange*

- **Nome da Exchange**: `service_exchange`

---

### Microserviços (Repositórios)

1. **OrderProcessorService**:
   ```bash
   git clone https://github.com/edsonrdl/micro-service-order.git
   cd seu-repositorio-order
2. **PaymentService**:
   ```bash
   git clone https://github.com/edsonrdl/micro-service-payment.git
    cd seu-repositorio-payment
3. **NotificationService**:
   ```bash
   git clone https://github.com/edsonrdl/micro-service-notification.git
    cd seu-repositorio-notification
3. **API Principal (ASP.NET Core)**:
   ```bash
   git clone https://github.com/edsonrdl/order-processing-system.git
    cd seu-repositorio-notification
   
### Versões Utilizadas 
   - RabbitMQ: ____ (Versão utilizada : 3.13.7 )
   -.NET Core: ____ (Versão utilizada : net8.0 )



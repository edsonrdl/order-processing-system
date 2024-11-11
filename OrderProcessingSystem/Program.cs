using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using RabbitMQ.Client;
using OrderProcessingSystem.RabbitMqService;
using OrderProcessingSystem.Notificationservice;
using OrderProcessingSystem.OrderService;
using OrderProcessingSystem.PaymentService;
using OrderProcessingSystem.UseCases.NotificationCreate;
using OrderProcessingSystem.UseCases.PaymentCreate;
using OrderProcessingSystem.UseCases.OrderCreate;
using OrderProcessingSystem.Mapper.NotificationMapper;
using OrderProcessingSystem.Mapper.OrderMapper;
using OrderProcessingSystem.Mapper.PaymentMapper;

var builder = WebApplication.CreateBuilder(args);

// Adiciona controladores e serviços para API
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// Configuração do Swagger para documentação da API
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Order Processing API", Version = "v1" });
});
builder.Services.AddRazorPages();

// Configuração do RabbitMQ (injeção de dependência para uso em serviços)
builder.Services.AddSingleton<IConnectionFactory>(sp =>
{
    return new ConnectionFactory
    {
        HostName = builder.Configuration["RabbitMQ:HostName"] ?? "localhost",
        UserName = builder.Configuration["RabbitMQ:UserName"] ?? "guest",
        Password = builder.Configuration["RabbitMQ:Password"] ?? "guest"
    };
});

// Injeção de dependência para RabbitMQ
builder.Services.AddSingleton<IRabbitMqService, RabbitMqService>();

// Injeção de dependência dos serviços principais (Order, Notification, Payment)
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<INotificationService, NotificationService>();
builder.Services.AddScoped<IPaymentService, PaymentService>();

// Injeção de dependência dos casos de uso (UseCases)
builder.Services.AddScoped<IOrderCreate, OrderCreate>();
builder.Services.AddScoped<IPaymentCreate, PaymentCreate>();
builder.Services.AddScoped<INotificationCreate, NotificationCreate>();

// Injeção de dependência dos mapeadores (Mappers)
builder.Services.AddScoped<IOrderMapper, OrderMapper>();
builder.Services.AddScoped<IPaymentMapper, PaymentMapper>();
builder.Services.AddScoped<INotificationMapper, NotificationMapper>();

var app = builder.Build();

// Configuração do pipeline de requisições HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Order Processing API v1");
    });
}

app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapRazorPages();
app.MapControllers();

app.Run();

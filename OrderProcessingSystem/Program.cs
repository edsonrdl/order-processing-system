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

// Adiciona controladores e servi�os para API
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Order Processing API", Version = "v1" });
});

// Configura��o do RabbitMQ (inje��o de depend�ncia para uso em servi�os)
builder.Services.AddSingleton<IConnectionFactory>(sp =>
{
    return new ConnectionFactory
    {
        HostName = builder.Configuration["RabbitMQ:HostName"] ?? "localhost",
        UserName = builder.Configuration["RabbitMQ:UserName"] ?? "guest",
        Password = builder.Configuration["RabbitMQ:Password"] ?? "guest"
    };
});

// Inje��o de depend�ncia para RabbitMQ
builder.Services.AddSingleton<IRabbitMqService, RabbitMqService>();

// Inje��o de depend�ncia dos servi�os principais (Order, Notification, Payment)
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<INotificationService, NotificationService>();
builder.Services.AddScoped<IPaymentService, PaymentService>();

// Inje��o de depend�ncia dos casos de uso (UseCases)
builder.Services.AddScoped<IOrderCreate, OrderCreate>();
builder.Services.AddScoped<IPaymentCreate, PaymentCreate>();
builder.Services.AddScoped<INotificationCreate, NotificationCreate>();

// Inje��o de depend�ncia dos mapeadores (Mappers)
builder.Services.AddScoped<IOrderMapper, OrderMapper>();
builder.Services.AddScoped<IPaymentMapper, PaymentMapper>();
builder.Services.AddScoped<INotificationMapper, NotificationMapper>();

// Adiciona configura��o de CORS
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

var app = builder.Build();

// Configura��o do pipeline de requisi��es HTTP em desenvolvimento
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI(c =>
//    {
//        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Order Processing API v1");
//    });
//}

// Configura��o do pipeline de requisi��es HTTP em produ��o/container para testar a aplica��o
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Order Processing API v1");
});

// Configura��o do CORS
app.UseCors();

app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapControllers();
Console.WriteLine($"Environment: {builder.Environment.EnvironmentName}");
app.Run();


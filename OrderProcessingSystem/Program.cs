using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using RabbitMQ.Client;
using OrderProcessingSystem.Notificationservice;
using OrderProcessingSystem.OrderService;
using OrderProcessingSystem.PaymentService;
using OrderProcessingSystem.RabbitMqService;
using OrderProcessingSystem.UseCases.OrderCreate;
using OrderProcessingSystem.Mapper.NotificationMapper;
using OrderProcessingSystem.Mapper.OrderMapper;
using OrderProcessingSystem.UseCases.NotificationCreate;
using OrderProcessingSystem.UseCases.PaymentCreate;
using OrderProcessingSystem.Mapper.PaymentMapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// Configuração do Swagger
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Order Processing API", Version = "v1" });
});
builder.Services.AddRazorPages();

// Configuração do RabbitMQ (usando injeção de dependência para facilitar o uso em serviços)
builder.Services.AddSingleton<IConnectionFactory>(sp =>
{
    return new ConnectionFactory()
    {
        HostName = builder.Configuration["RabbitMQ:HostName"] ?? "localhost",
        UserName = builder.Configuration["RabbitMQ:UserName"] ?? "guest",
        Password = builder.Configuration["RabbitMQ:Password"] ?? "guest"
    };
});
//Inj RabbitQm
builder.Services.AddSingleton<IRabbitMqService, RabbitMqService>();
//Inj Services Order,Notification,Payment
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<INotificationService, NotificationService>();
builder.Services.AddScoped<IPaymentService, PaymentService>();
//Inj UseCases Create Order,Notification,Payment
builder.Services.AddScoped<IOrderCreate, OrderCreate>();
builder.Services.AddScoped<IPaymentCreate,PaymentCreate>();
builder.Services.AddScoped<INotificationCreate, NotificationCreate>();
//Inj Mapper  Order,Notification,Payment
builder.Services.AddScoped<IOrderMapper, OrderMapper>();
builder.Services.AddScoped<IPaymentMapper, PaymentMapper>();
builder.Services.AddScoped<IOrderMapper,  OrderMapper>();


var app = builder.Build();

// Configure the HTTP request pipeline.
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

using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using OrderProcessingSystem.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add services to the container.
builder.Services.AddRazorPages();

// Obtenha a string de conexão do PostgreSQL
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
                       ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

// Configura o AppDbContext para usar PostgreSQL
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseNpgsql(connectionString);
});



var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();

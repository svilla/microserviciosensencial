using Lil.Products;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "ProductsAPI", Version = "v1" });
    c.EnableAnnotations();
});

// A�adir los providers personalizados (tu propio c�digo)
builder.Services.AddProviders();

var app = builder.Build();

// Configurar el pipeline de HTTP.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "ProductsAPI v1");
    });
}

app.MapControllers(); // Aseg�rate de mapear los controladores

await app.RunAsync();

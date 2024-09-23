using Lil.Search;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "SearchAPI", Version = "v1" });
    c.EnableAnnotations();
});

builder.Services.AddSearchServices();

builder.Services.AddHttpClient("customersService", c=>
{
    var customersServiceUrl = builder.Configuration["Services:Customers"];

    if (string.IsNullOrEmpty(customersServiceUrl))
    {
        throw new InvalidOperationException("La URL para el servicio 'Customers' no está configurada correctamente.");
    }

    c.BaseAddress = new Uri(customersServiceUrl);
});

builder.Services.AddHttpClient("productsService", c =>
{
    var productsServiceUrl = builder.Configuration["Services:Products"];

    if (string.IsNullOrEmpty(productsServiceUrl))
    {
        throw new InvalidOperationException("La URL para el servicio 'Products' no está configurada correctamente.");
    }

    c.BaseAddress = new Uri(productsServiceUrl);
});

builder.Services.AddHttpClient("salesService", c =>
{
    var salesServiceUrl = builder.Configuration["Services:Sales"];

    if (string.IsNullOrEmpty(salesServiceUrl))
    {
        throw new InvalidOperationException("La URL para el servicio 'Sales' no está configurada correctamente.");
    }

    c.BaseAddress = new Uri(salesServiceUrl);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "SearchAPI v1");
    });
}

app.MapControllers();

await app.RunAsync();
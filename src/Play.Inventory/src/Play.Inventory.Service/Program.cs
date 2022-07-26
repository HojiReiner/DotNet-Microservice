using Play.Common.MassTransit;
using Play.Common.MongoDB;
using Play.Inventory.Service.Entities;

var builder = WebApplication.CreateBuilder(args);
var AllowedOriginSetting = "AllowedOrigin";

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Mongo
builder.Services.AddMongo();
builder.Services.AddMongoRepository<InventoryItem>("inventoryitems");
builder.Services.AddMongoRepository<CatalogItem>("catalogitems");

//RabbitMQ
builder.Services.AddMassTransitWithRabbitMQ();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    //CORS
    app.UseCors(buildr =>
    {
        buildr.WithOrigins(builder.Configuration[AllowedOriginSetting])
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

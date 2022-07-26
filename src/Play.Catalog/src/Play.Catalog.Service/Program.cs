using Play.Catalog.Service.Entities;
using Play.Common.MongoDB;
using Play.Common.MassTransit;
using Play.Common.Settings;

var builder = WebApplication.CreateBuilder(args);
var AllowedOriginSetting = "AllowedOrigin";

var serviceSettings = builder.Configuration.GetSection(nameof(ServiceSettings)).Get<ServiceSettings>();

// Add services to the container.
builder.Services.AddControllers(options =>
{
    options.SuppressAsyncSuffixInActionNames = false;
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Mongo
builder.Services.AddMongo();
builder.Services.AddMongoRepository<Item>("items");

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

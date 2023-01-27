using AutoMapper;
using FplHelperApi.Consuments;
using FplHelperApi.Messages.Contracts;
using FplHelperApi.Messages.Contracts.GetDataFromFplServer;
using FplHelperApi.Models.Profiles;
using FplHelperApi.Sagas;
using FplHelperApi.Utils;
using MassTransit;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// AUTO MAPPER
var mapperConfiguration = new MapperConfiguration(cfg => cfg.AddProfile(new FplHelperProfile()));
var mapper = mapperConfiguration.CreateMapper();
builder.Services.AddSingleton(mapper);

// FPL SERVER HTTP CLIENT
builder.Services.AddHttpClient(Constants.FPL_CLIENT, c =>
{
    c.BaseAddress = new Uri(Constants.FPL_BASE_URL);
});

// MASS TRANSIT
builder.Services.AddMassTransit(cfg =>
{   
    cfg.AddConsumersFromNamespaceContaining<GetDataFromFplServerHandlerStartMsgConsumer>();
    cfg.AddSagaStateMachine<GetDataFromFplServerSaga, GetDataFromFplServerState>().RedisRepository();

    cfg.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host("localhost", "/", h =>
        {
            h.Username("guest");
            h.Password("guest");
        });

        cfg.ConfigureEndpoints(context);
    });

    cfg.AddRequestClient<ISagaStartMessage>();
    cfg.AddRequestClient<IGetDataFromFplServerHandlerStartMsg>();    
});
builder.Services.AddMassTransitHostedService();


var app = builder.Build();


// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(builder =>
{
    builder.WithOrigins("http://localhost:3000")
    .AllowAnyHeader()
    .AllowAnyMethod()
    .AllowCredentials();
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

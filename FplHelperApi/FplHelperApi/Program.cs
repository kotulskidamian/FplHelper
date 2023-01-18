using AutoMapper;
using FplHelperApi.Models.Profiles;
using FplHelperApi.Utils;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var mapperConfiguration = new MapperConfiguration(cfg => cfg.AddProfile(new FplHelperProfile()));
var mapper = mapperConfiguration.CreateMapper();

builder.Services.AddSingleton(mapper);

builder.Services.AddHttpClient(Constants.FPL_CLIENT, c =>
{
    c.BaseAddress = new Uri(Constants.FPL_BASE_URL);
});

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

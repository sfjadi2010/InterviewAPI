using InterviewAPI.Models;
using InterviewAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient<ICharacters, Characters>("character_client", client =>
{
    client.BaseAddress = new Uri("https://rickandmortyapi.com/api/");
});
builder.Services.AddHttpClient<IPlanets, Planets>("planets_client", client => 
{
    client.BaseAddress = new Uri("https://swapi.dev/api/");
});
builder.Services.AddScoped<IPlanets, Planets>();
builder.Services.AddScoped<ICharacters, Characters>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

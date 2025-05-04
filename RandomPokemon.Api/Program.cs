using RandomPokemon.Api.Mappings;
using RandomPokemon.Services.Services;
using RandomPokemon.Data.Extensions;
using RandomPokemon.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(PokemonProfile));

builder.Services.AddDataServices();
builder.Services.AddScoped<PokemonService>();

builder.Services.AddControllers();
builder.Services.AddOpenApi();

var app = builder.Build();

//using (var scope = app.Services.CreateScope())
//{
//    var context = scope.ServiceProvider.GetRequiredService<RandomPokemonDbContext>();
//    await DatabaseSeeder.SeedData(context);
//}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();

using Application;
using Domain;
using Infrastructure;
using Infrastructure.EF;
using Infrastructure.EF.MariaDb;
using Infrastructure.EF.MySql;
using Infrastructure.EF.Postgres;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDomain();
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options => {
    options.CustomSchemaIds(x => x.FullName);
});

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

using (var scope = app.Services.CreateScope())
{
    var postgresSeeder = scope.ServiceProvider.GetRequiredService<Seeder<PostgresDbContext>>();
    var mySqlSeeder = scope.ServiceProvider.GetRequiredService<Seeder<MySqlDbContext>>();
    var mariaDbSeeder = scope.ServiceProvider.GetRequiredService<Seeder<MariaDbDbContext>>();

    await postgresSeeder.Seed();
    await mySqlSeeder.Seed();
    await mariaDbSeeder.Seed();
}

app.Run();

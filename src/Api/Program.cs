using Application;
using Domain;
using Infrastructure;
using Infrastructure.EF;
using Infrastructure.EF.MariaDb;
using Infrastructure.EF.MySql;
using Infrastructure.EF.Postgres;
using Infrastructure.MongoDB;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDomain();
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options => {
    options.CustomSchemaIds(x => x.FullName);
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var postgresSeeder = scope.ServiceProvider.GetRequiredService<EFSeeder<PostgresDbContext>>();
    // var mySqlSeeder = scope.ServiceProvider.GetRequiredService<EFSeeder<MySqlDbContext>>();
    // var mariaDbSeeder = scope.ServiceProvider.GetRequiredService<EFSeeder<MariaDbDbContext>>();
    // var mongoSeeder = scope.ServiceProvider.GetRequiredService<MongoSeeder>();

    await postgresSeeder.Seed();
    // await mySqlSeeder.Seed();
    // await mariaDbSeeder.Seed();
    // await mongoSeeder.Seed();
}

app.Run();

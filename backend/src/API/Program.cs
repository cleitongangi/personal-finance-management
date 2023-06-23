using Infra.IoC;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register dependencies for all layers (Domain, Data, etc)
builder.Services
    .AddDependencyInjectionForAllLayers(
        dbConnectionString: builder.Configuration.GetConnectionString("DbConnectionString") ?? throw new NullReferenceException("[DbConnectionString] not defined in appsettings.json")
    );

var app = builder.Build();

// Apply EF migrations in DB
app.Services.ApplyMigration();

// Apply EF migrations in DB
MigrationManager.ApplyMigration(app.Services);

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

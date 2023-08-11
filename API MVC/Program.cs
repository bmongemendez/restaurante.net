using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using API_MVC.Data;

var builder = WebApplication.CreateBuilder(args);

// Secrets
var connectionStringPassword = builder.Configuration["DbPassword"];

var connectionStringBuilder = new SqlConnectionStringBuilder(builder.Configuration.GetConnectionString("Default"));

connectionStringBuilder.Password = connectionStringPassword;

var connectionStringWithPassword = connectionStringBuilder.ConnectionString;

// Update configuration with the new connection string 
builder.Configuration["ConnectionStrings:Default"] = connectionStringWithPassword;

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddControllersWithViews()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
        // Otras configuraciones de JsonSerializerOptions
    });

// Conexion a la base de datos
builder.Services.AddDbContext<ProyectoDbContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMemoryCache();
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

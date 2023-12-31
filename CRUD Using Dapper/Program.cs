using CRUD_Using_Dapper.Common;
using CRUD_Using_Dapper.IService;
using CRUD_Using_Dapper.Services;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Add IConfiguration to the services
builder.Services.AddSingleton<IConfiguration>(builder.Configuration);
Global.ConnectionString = builder.Configuration.GetConnectionString("StudentDB");

builder.Services.AddScoped<IStudentService, StudentService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

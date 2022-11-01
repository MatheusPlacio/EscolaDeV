using AutoMapper;
using EscolaDeV.Context;
using EscolaDeV.Profiles;
using EscolaDeV.Services;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Conexão com o banco de dados \/
string Connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<DataContext>(options =>
                  options.UseSqlServer(Connection));

builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));

 builder.Services.AddControllers()
    .AddJsonOptions(options => options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ICursoService, CursoService>();
builder.Services.AddScoped<INotasService, NotasService>();
builder.Services.AddScoped<IJwtService, IJwtService>();

var mapperConfig = MapperConfig.GetMapperConfig();
IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

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

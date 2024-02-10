using Agua_e_Aventura.Data;
using Agua_e_Aventura.Repositorio.Implementacao;
using Agua_e_Aventura.Repositorio.Repositorio;
using Agua_e_Aventura.Repositorio.Implementacao;
using Microsoft.EntityFrameworkCore;
using Agua_e_Aventura.Mappings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AguaAventuraDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("AguaAventuraConnectionString")));

builder.Services.AddScoped<IPraiaRepositorio, SqlPraiaRepositorio>();
builder.Services.AddScoped<IRegionRepositorio, SqlRegiaoRepositorio>();

builder.Services.AddAutoMapper(typeof(AutoMappingProfiles));

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

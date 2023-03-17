using ConsumoAlimentario.Data;
using ConsumoAlimentario.Mapper;
using ConsumoAlimentario.Repository;
using ConsumoAlimentario.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConexionSQL"));
});

builder.Services.AddScoped<IAlimentoRepository, AlimentoRepository>();
builder.Services.AddScoped<IAlimentoCargadoRepository, AlimentoCargadoRepository>();



//automapper
builder.Services.AddAutoMapper(typeof(AlimentosMapper));

// Add services to the container.

builder.Services.AddControllers();
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

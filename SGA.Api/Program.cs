using Microsoft.EntityFrameworkCore;
using SG.IOC;
using SGA.Persistence.Contexts;

var builder = WebApplication.CreateBuilder(args);

// DbContext (SQL Server de ejemplo)
builder.Services.AddDbContext<SgaDbContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddSgaServices(); // registra repos y servicios

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
if (app.Environment.IsDevelopment()) { app.UseSwagger(); app.UseSwaggerUI(); }
app.UseHttpsRedirection();
app.MapControllers();
app.Run();

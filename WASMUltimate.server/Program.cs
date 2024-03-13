using Microsoft.EntityFrameworkCore;
using WASMUltimate.server.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DBConnection")));

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();

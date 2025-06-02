using Microsoft.EntityFrameworkCore;
using MiniJackPotManager.Data;



var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddDbContext<AppDbContent>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Use Swagger
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();


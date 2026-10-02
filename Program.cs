using Microsoft.EntityFrameworkCore;
using MobileMoneyAgregator.Services.JwtServices;
using Scalar.AspNetCore;


var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(
 options => options.UseNpgsql(connectionString)
);
builder.Services.AddControllers();
builder.Services.AddScoped<JwtService>();
builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}
app.MapControllers();
app.UseHttpsRedirection();
app.Run();


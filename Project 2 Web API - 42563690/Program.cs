using Microsoft.EntityFrameworkCore;
using Project_2_Web_API___42563690.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers().AddNewtonsoftJson(); //for json patch


builder.Services.AddDbContext<TelemetryContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Data Source=4256369cmpg323.database.windows.net;Initial Catalog=cmpg323DB;User ID=BonnieSibisi08;Encrypt=True;Authentication=ActiveDirectoryInteractive")));

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

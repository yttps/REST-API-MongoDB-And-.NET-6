using TodoAPI.Services;
using TodoAPI.Models;

var builder = WebApplication.CreateBuilder(args);

// ✅ Register MongoDB settings
builder.Services.Configure<TodoDatabaseSettings>(
    builder.Configuration.GetSection("TodoDatabaseSettings"));

// ✅ Register TodoService
builder.Services.AddSingleton<TodoService>();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
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
app.MapControllers();
app.Run();


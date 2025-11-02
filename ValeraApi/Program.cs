// Program.cs
using Microsoft.EntityFrameworkCore;
using ValeraApi.Data;
using ValeraApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Добавляем DbContext с SQLite
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=valera.db"));

// Регистрируем ValeraService как scoped
builder.Services.AddScoped<ValeraService>();

// Добавляем контроллеры
builder.Services.AddControllers();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Инициализация базы данных (применяем миграции и сиды)
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    context.Database.EnsureCreated(); // Создаёт БД, если нет
}

// Middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
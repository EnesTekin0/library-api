using LibraryApi.Data; // LibraryContext için
using Microsoft.EntityFrameworkCore; // DbContext ayarları için

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Veritabanı bağlantısı için DbContext'i ekliyoruz.
builder.Services.AddDbContext<LibraryContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// OpenAPI (Swagger) servisini ekliyoruz.
builder.Services.AddOpenApi();

// Controller desteğini ekliyoruz.
builder.Services.AddControllers(); // API için gerekli

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage(); // Hata ayıklama için
    app.MapOpenApi();
}

// HTTPS yönlendirmesini aktif ediyoruz.
app.UseHttpsRedirection();

// Endpoint'lerin hangi route'larla bağlanacağını belirtiyoruz.
app.UseRouting();
app.MapControllers(); // Tüm controllerları otomatik ekler

// Örnek GET endpoint'i
var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast");

app.Run();

// WeatherForecast kaydı
record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
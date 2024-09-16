var builder = WebApplication.CreateBuilder(args);


//ADD Controllers
builder.Services.AddControllers();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register HttpClient
//builder.Services.AddHttpClient();

builder.Services.AddHttpClient("Sample", client => {
    client.BaseAddress = new Uri("https://jsonplaceholder.typicode.com");
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast =  Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToList();

    forecast.Add(new WeatherForecast
    (
        DateOnly.FromDateTime(DateTime.Now.AddDays(-6)),  // New Date
        Random.Shared.Next(-20, 55),                     // New Temperature
        "Storming"
    ));    

    return forecast.ToArray();
})
.WithName("GetWeatherForecast")
.WithOpenApi();

app.MapControllers();


app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}

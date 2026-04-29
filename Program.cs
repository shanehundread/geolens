var builder = WebApplication.CreateBuilder(args);

// IMPORTANT for Docker
builder.WebHost.UseUrls("http://0.0.0.0:8080");

builder.Services.AddHttpClient();
builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader());
});

var app = builder.Build();

app.UseCors("AllowFrontend");

app.MapControllers();

app.Run();
var builder = WebApplication.CreateBuilder(args);

// IMPORTANT for Docker / Render
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

// 🔥 THIS IS WHAT YOU WERE MISSING (FRONTEND SUPPORT)
app.UseDefaultFiles();   // serves index.html automatically
app.UseStaticFiles();    // allows wwwroot files to load

app.MapControllers();

app.Run();
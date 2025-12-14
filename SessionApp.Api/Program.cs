using SessionApp.Api.Application.Interfaces;
using SessionApp.Api.Application.Services;
using SessionApp.Api.Infrastructure.Stores;
using SessionApp.Api.Hubs;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSignalR();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<ISessionStore, InMemorySessionStore>();
builder.Services.AddScoped<ISessionService, SessionService>();
// CORS (important for SignalR later)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials()
            .SetIsOriginAllowed(_ => true);
    });
});

var app = builder.Build();

app.UseCors("AllowAll");

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();
app.MapHub<SessionHub>("/sessionHub");

app.Run();
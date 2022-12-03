using SimpleCleanArchitecture.WebApp.Startup;

var builder = WebApplication.CreateBuilder(args);
Services.Add(builder.Services, builder.Environment, builder.Configuration);

var app = builder.Build();
Middlewares.Use(app, app.Environment, app.Configuration);

app.MapControllers();
app.Run();
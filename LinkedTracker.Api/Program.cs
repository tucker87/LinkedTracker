using LinkedTracker.Api;
using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder(args);

// Use the Startup class to configure services
var startup = new Startup(builder.Configuration);
startup.ConfigureServices(builder.Services);

var app = builder.Build();

// Use the Startup class to configure the app
startup.Configure(app, app.Environment);

await app.RunAsync();

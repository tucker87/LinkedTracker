using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace LinkedTracker.Api;

using var host = new HostBuilder()
    .ConfigureWebHost(webHostBuilder =>
    {
        webHostBuilder
            .UseTestServer() // If using TestServer
            .UseContentRoot(Directory.GetCurrentDirectory())
            .UseStartup()
            .UseKestrel();
    })
    .Build();

await host.StartAsync();


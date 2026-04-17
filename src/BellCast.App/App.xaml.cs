using System;
using System.IO;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;

namespace BellCast.App;

public partial class App : Application
{
    private readonly IHost _host;

    public static IServiceProvider Services { get; private set; } = null!;

    public App()
    {
        _host = Host.CreateDefaultBuilder()
            .UseSerilog((_, _, loggerConfig) =>
            {
                var logDir = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                    "BellCast", "logs");
                Directory.CreateDirectory(logDir);

                loggerConfig
                    .MinimumLevel.Information()
                    .Enrich.FromLogContext()
                    .WriteTo.File(
                        path: Path.Combine(logDir, "bellcast-.log"),
                        rollingInterval: RollingInterval.Day,
                        retainedFileCountLimit: 30,
                        outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}");
            })
            .ConfigureServices((_, services) =>
            {
                services.AddSingleton<MainWindow>();
            })
            .Build();

        Services = _host.Services;
    }

    protected override void OnStartup(StartupEventArgs e)
    {
        _host.Start();

        var log = Services.GetRequiredService<ILogger<App>>();
        log.LogInformation("BellCast starting up");

        var mainWindow = Services.GetRequiredService<MainWindow>();
        mainWindow.Show();

        base.OnStartup(e);
    }

    protected override void OnExit(ExitEventArgs e)
    {
        Log.Information("BellCast shutting down");

        _host.StopAsync(TimeSpan.FromSeconds(5)).GetAwaiter().GetResult();
        _host.Dispose();
        Log.CloseAndFlush();

        base.OnExit(e);
    }
}

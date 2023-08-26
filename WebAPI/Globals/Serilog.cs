public static partial class Global
{
    public static IServiceCollection AddSerilog(this IServiceCollection self)
    {
        var logger = new LoggerConfiguration()
            .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
            .Enrich.FromLogContext()
            .WriteTo.Console()
            .CreateBootstrapLogger();

        self.AddSingleton(logger);

        return self;
    }


    public static ConfigureHostBuilder UseSerilog(this ConfigureHostBuilder self)
    {
        self.UseSerilog((context, services, configuration) => configuration
            .ReadFrom.Configuration(context.Configuration)
            .ReadFrom.Services(services)
            .Enrich.FromLogContext());

        return self;
    }

    public static WebApplication UseSerilogRequestLogging(this WebApplication self)
    {
        self.UseSerilogRequestLogging(configure =>
        {
            configure.MessageTemplate = "HTTP {RequestMethod} {RequestPath} ({UserId}) responded {StatusCode} in {Elapsed:0.0000}ms";
        });

        return self;
    }
}



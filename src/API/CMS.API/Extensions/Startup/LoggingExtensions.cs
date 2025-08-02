using Serilog;


namespace CMS.API.Extensions.Startup
{
    public static class LoggingExtensions
    {
        public static void ConfigureLogging(this WebApplicationBuilder builder)
        {
            builder.Host.UseSerilog((context, loggerConfig) =>
            loggerConfig.ReadFrom.Configuration(context.Configuration));
            var logConfiguration = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .Enrich.WithEnvironmentName()
                .Enrich.WithMachineName();

            if (builder.Environment.IsDevelopment())
            {
                logConfiguration.WriteTo.Console();
            }

            Log.Logger = logConfiguration.CreateLogger();
        }
    }
}





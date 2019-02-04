namespace FinnishYnabConverter
{
    using System;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.DependencyInjection;
    using global::FinnishYnabConverter.Factories;
    using global::FinnishYnabConverter.Outputs;

    class Program
    {
        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            var serviceProvider = ConfigureServices(serviceCollection);

            var logger = serviceProvider.GetService<ILoggerFactory>()
                .CreateLogger(nameof(Program));

            try
            {
                var finnishYnabConverter = serviceProvider.GetService<IFinnishYnabConverter>();
                finnishYnabConverter.Start(args);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
            }
            finally
            {
                serviceProvider.Dispose();
            }
        }
        static ServiceProvider ConfigureServices(IServiceCollection serviceCollection)
        {
            return serviceCollection
                .AddLogging(o =>
                {
                    o.AddConsole();
                    o.SetMinimumLevel(LogLevel.Debug);
                })
                .AddSingleton<ILoggerFactory, LoggerFactory>()
                .AddTransient<IBankConverterFactory, BankConverterFactory>()
                .AddTransient<IBankValidatorFactory, BankValidatorFactory>()
                .AddTransient<IOutputProcessorFactory, OutputProcessorFactory>()
                .AddTransient<IFinnishYnabConverter, FinnishYnabConverter>()
                .AddTransient<IOutputProcessor, TextProcessor>()
                .BuildServiceProvider();
        }
    }
}

namespace FinnishYnabConverter
{
    using System;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.DependencyInjection;
    using global::FinnishYnabConverter.Factories;
    using global::FinnishYnabConverter.Outputs;

    class Program
    {

        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddLogging(o =>
                {
                    o.AddConsole();
                })
                .AddTransient<IBankConverterFactory, BankConverterFactory>()
                .AddTransient<IBankValidatorFactory, BankValidatorFactory>()
                .AddTransient<IOutputProcessorFactory, OutputProcessorFactory>()
                .AddTransient<IFinnishYnabConverter, FinnishYnabConverter>()
                .AddTransient<IOutputProcessor, TextProcessor>()
                .BuildServiceProvider();

            var logger = serviceProvider.GetService<ILoggerProvider>()
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
        }
    }
}

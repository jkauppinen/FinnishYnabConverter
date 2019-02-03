namespace FinnishYnabConverter
{
    using System;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.DependencyInjection;
    using global::FinnishYnabConverter.Factories;
    using global::FinnishYnabConverter.Outputs;
    using System.Threading;

    class Program
    {

        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddLogging(o =>
                {
                    o.AddConsole();
                })
                .AddTransient<IBankFormatterFactory, BankFormatterFactory>()
                .AddTransient<IBankValidatorFactory, BankValidatorFactory>()
                .AddTransient<IFinnishYnabConverter, FinnishYnabConverter>()
                .AddTransient<IOutputProcessor, TextProcessor>()
                .BuildServiceProvider();

            var logger = serviceProvider.GetService<ILoggerProvider>()
                .CreateLogger(nameof(Program));
                
            try
            {
                var FinnishYnabConverter = serviceProvider.GetService<IFinnishYnabConverter>();

                CancellationToken cancellationToken = CancellationToken.None;

                FinnishYnabConverter.Start(args, cancellationToken)
                .Wait(cancellationToken);

            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
            }
        }
    }
}

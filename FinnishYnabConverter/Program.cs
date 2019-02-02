namespace FinnishYnabConverter
{
    using System;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.DependencyInjection;
    using global::FinnishYnabConverter.Factories;

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
                .AddTransient<IFinnishYnabConverter, FinnishYnabConverter>()
                .BuildServiceProvider(); 
            
            var logger = serviceProvider.GetService<ILoggerProvider>()
                .CreateLogger(nameof(Program));
            
            var FinnishYnabConverter = serviceProvider.GetService<IFinnishYnabConverter>();
            FinnishYnabConverter.Start(args);
        }
    }
}

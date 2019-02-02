namespace FinnishYnabConverter
{
    using System;
    using System.Collections.Generic;
    using CommandLine;
    using global::FinnishYnabConverter.Factories;
    using global::FinnishYnabConverter.Configurations;
    using Microsoft.Extensions.Logging;
    using global::FinnishYnabConverter.Formatters;

    public class FinnishYnabConverter : IFinnishYnabConverter
    {
        IBankFormatterFactory _bankFormatterFactory;
        ILogger _logger;

        List<string> _supportedBanks = new List<string>()
        {
            "Handelsbanken"
        };

        public FinnishYnabConverter(ILoggerProvider loggerProvider, IBankFormatterFactory bankFormatterFactory)
        {
            _logger = loggerProvider.CreateLogger(nameof(FinnishYnabConverter));
            _bankFormatterFactory = bankFormatterFactory;
        }

        public void Start(string[] args)
        {
            Parser.Default.ParseArguments<ConsoleArgumentConfiguration>(args)
                   .WithParsed<ConsoleArgumentConfiguration>(o =>
                   {
                       IBankFormatter formatter = _bankFormatterFactory.CreateBankFormatter(o.BankName);
                       formatter.Format(o.InputFile, o.OutputDirectory);
                       _logger.LogInformation("Transactions have been formatted to YNAB compatible format");
                   });
        }
    }
}
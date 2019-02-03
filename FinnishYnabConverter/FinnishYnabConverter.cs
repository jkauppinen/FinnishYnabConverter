namespace FinnishYnabConverter
{
    using System;
    using System.Collections.Generic;
    using CommandLine;
    using global::FinnishYnabConverter.Factories;
    using global::FinnishYnabConverter.Configurations;
    using Microsoft.Extensions.Logging;
    using global::FinnishYnabConverter.Formatters;
    using global::FinnishYnabConverter.Validators;
    using System.Threading.Tasks;
    using System.Threading;
    using global::FinnishYnabConverter.Outputs;

    public class FinnishYnabConverter : IFinnishYnabConverter
    {
        IBankFormatterFactory _bankFormatterFactory;
        IBankValidatorFactory _bankValidatorFactory;
        IOutputProcessor _outputProcessor;
        public FinnishYnabConverter(IBankFormatterFactory bankFormatterFactory,
         IBankValidatorFactory bankValidatorFactory,
         IOutputProcessor outputProcessor)
        {
            _bankFormatterFactory = bankFormatterFactory;
            _bankValidatorFactory = bankValidatorFactory;
            _outputProcessor = outputProcessor;
        }

        public async Task Start(string[] args, CancellationToken cancellationToken)
        {
            Parser.Default.ParseArguments<ConsoleArgumentConfiguration>(args)
                   .WithParsed<ConsoleArgumentConfiguration>(o => 
                   {
                       InputFileInformation inputFileInformation = new InputFileInformation(o.BankName.Trim(), o.InputFile.Trim(), o.OutputDirectory.Trim());
                       IBankValidator bankValidator = _bankValidatorFactory.CreateBankValidator(inputFileInformation);
                       bankValidator.Validate(inputFileInformation);
                       IBankFormatter formatter = _bankFormatterFactory.CreateBankFormatter(inputFileInformation.BankName);
                       await _outputProcessor.Process(inputFileInformation, formatter, cancellationToken);
                   });
        }
    }
}
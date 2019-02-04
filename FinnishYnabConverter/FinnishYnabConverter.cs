namespace FinnishYnabConverter
{
    using System;
    using System.Collections.Generic;
    using CommandLine;
    using global::FinnishYnabConverter.Factories;
    using global::FinnishYnabConverter.Options;
    using global::FinnishYnabConverter.Converters;
    using global::FinnishYnabConverter.Validators;
    using System.Threading.Tasks;
    using System.Threading;
    using global::FinnishYnabConverter.Outputs;
    using global::FinnishYnabConverter.Inputs;
    using System.Text;
    using Microsoft.Extensions.Logging;

    public class FinnishYnabConverter : IFinnishYnabConverter
    {
        IBankConverterFactory _bankFormatterFactory;
        IBankValidatorFactory _bankValidatorFactory;
        IOutputProcessorFactory _outputProcessorFactory;
        ILogger _logger;
        public FinnishYnabConverter(IBankConverterFactory bankFormatterFactory,
         IBankValidatorFactory bankValidatorFactory,
         IOutputProcessorFactory outputProcessorFactory,
         ILoggerFactory loggerFactory)
        {
            _bankFormatterFactory = bankFormatterFactory;
            _bankValidatorFactory = bankValidatorFactory;
            _outputProcessorFactory = outputProcessorFactory;
            _logger = loggerFactory.CreateLogger(nameof(FinnishYnabConverter));
        }

        public void Start(string[] args)
        {
            Parser.Default.ParseArguments<ConversionOptions, SupportedBankOptions, SupportedEncodingOptions>(args)
                    .MapResult(
                    (ConversionOptions options) =>
                    {
                        InputFileInformation inputFileInformation = CreateInputFileInformation(options);
                        IBankValidator bankValidator = _bankValidatorFactory.CreateBankValidator(inputFileInformation);
                        bankValidator.Validate(inputFileInformation);
                        IBankConverter converter = _bankFormatterFactory.CreateBankFormatter(inputFileInformation.BankName);
                        var outputProcessor = _outputProcessorFactory.CreateOutputProcessor(inputFileInformation);
                        outputProcessor.Process(inputFileInformation, converter);
                        _logger.LogInformation("Transactions have been converted to YNAB format");
                        return 0;
                    },
                    (SupportedBankOptions options) =>
                    {
                        PrintSupportedBanks();
                        return 0;
                    },
                     (SupportedEncodingOptions options) =>
                     {
                         PrintSupportedEncodings();
                         return 0;
                     },
                    errs => 1);
        }

        private static InputFileInformation CreateInputFileInformation(ConversionOptions options)
        {
            return new InputFileInformation(
                                        bankName: options.BankName.Trim(),
                                       inputFilePath: options.InputFile.Trim(),
                                        outputDir: options.OutputDirectory.Trim(),
                                        inputFileEncoding: String.IsNullOrWhiteSpace(options.InputFileEncoding) ? Encoding.Default : Encoding.GetEncoding(options.InputFileEncoding));
        }

        private void PrintSupportedBanks()
        {
            foreach (var bank in SupportedBanks.Collection)
            {
                _logger.LogInformation(bank);
            }
        }

        private void PrintSupportedEncodings()
        {
            foreach (var encoding in Encoding.GetEncodings())
            {
                _logger.LogInformation(encoding.Name);
            }
        }
    }
}
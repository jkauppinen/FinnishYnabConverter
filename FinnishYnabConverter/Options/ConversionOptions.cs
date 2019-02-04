namespace FinnishYnabConverter.Options
{
    using CommandLine;
    using CommandLine.Text;
    using System.Collections.Generic;
    using System.Text;

    [Verb("convert",HelpText="Converts csv formatted transactions to YNAB format")]
    public class ConversionOptions
    {
        private readonly string _inputFile;
        private readonly string _outputDirectory;
        private readonly string _bankName;
        private readonly string _inputFileEncoding;
        public ConversionOptions(string inputFile, string outputDirectory, string bankName, string inputFileEncoding = null)
        {
            _inputFile = inputFile;
            _outputDirectory = outputDirectory;
            _bankName = bankName;
            _inputFileEncoding = inputFileEncoding;
        }

        [Option('i', "input", Required = true, HelpText = "Input file containing transactions")]
        public string InputFile { get {return _inputFile; } }

        [Option('o', "output", Required = true, HelpText = "Output directory")]
        public string OutputDirectory { get {return _outputDirectory; } }

        [Option('b', "bankname", Required = true, HelpText = "Name of your bank")]
        public string BankName { get {return _bankName; } }

        [Option('e', "encoding", Required = false, HelpText = "Encoding of the input file. Default it UTF-8 encoding.")]
        public string InputFileEncoding { get {return _inputFileEncoding; } }

        [Usage(ApplicationAlias = nameof(FinnishYnabConverter))]
        public static IEnumerable<Example> Examples
        {
            get
            {
                return new List<Example>() {
                    new Example("Convert file to a trendy format",
                     new ConversionOptions("/home/john/transactions/mytransactions.csv",
                     "/home/john/transactions",
                     "OP"))
                };
            }
        }
    }
}
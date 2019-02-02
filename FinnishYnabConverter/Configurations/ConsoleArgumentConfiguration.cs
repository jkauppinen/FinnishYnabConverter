namespace FinnishYnabConverter.Configurations
{
    using CommandLine;
    using System.Text;

    public class ConsoleArgumentConfiguration
    {
        [Option('i', "input", Required = true, HelpText = "Input file containing transactions")]
        public string InputFile { get; set; }

        [Option('o', "output", Required = true, HelpText = "Output directory")]
        public string OutputDirectory { get; set; }

        [Option('b', "bankname", Required = true, HelpText = "Name of your bank (Currently supports Handelsbanken)")]
        public string BankName { get; set; }
    }
}
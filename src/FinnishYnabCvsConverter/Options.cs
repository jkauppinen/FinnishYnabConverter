using CommandLine;
using System.Text;

namespace FinnishYnabCvsConverter
{
    public class Options
    {
        [Option('i', "input", Required = true, HelpText = "Input file containing transactions")]
        public string InputFile { get; set; }

        [Option('o', "output", Required = true, HelpText = "Output directory")]
        public string OutputDirectory { get; set; }

        [Option('b', "bankname", Required = true, HelpText = "Name of your bank")]
        public string BankName { get; set; }

        [HelpOption]
        public string GetUsage()
        {
            // this without using CommandLine.Text
            var usage = new StringBuilder();
            usage.AppendLine("Finnish-YNAB-Converter");
            usage.AppendLine("Read documentation on git for usage");
            return usage.ToString();
        }
    }
}
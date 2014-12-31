using CommandLine;
using log4net;
using System;

namespace Finnish_YNAB_Converter
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            log4net.Config.BasicConfigurator.Configure();
            ILog Log = LogManager.GetLogger(System.Reflection.MethodInfo.GetCurrentMethod().DeclaringType.FullName);
            var options = new Options();
            var parser = new Parser();
            if (parser.ParseArguments(args, options))
            {
                var formatter = FormatterFactory.CreateBankFormatter(options.BankName);
                formatter.Format(options.InputFile, options.OutputDirectory);
            }
            Console.WriteLine("Transactions have been formatted");
            Console.Read();
        }
    }
}
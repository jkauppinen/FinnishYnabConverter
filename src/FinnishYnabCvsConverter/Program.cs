using CommandLine;
using log4net;
using System;

namespace FinnishYnabCvsConverter
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            log4net.Config.BasicConfigurator.Configure();
            ILog Log = LogManager.GetLogger(System.Reflection.MethodInfo.GetCurrentMethod().DeclaringType.FullName);
            try
            {
                Options options = new Options();
                Parser parser = new Parser();
                if (parser.ParseArguments(args, options))
                {
                    IBankFormatter formatter = FormatterFactory.CreateBankFormatter(options.BankName);
                    formatter.Format(options.InputFile, options.OutputDirectory);
                }
                Console.WriteLine("Transactions have been formatted");
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }

            Console.WriteLine("Press any key to exit...");
            Console.Read();
        }
    }
}
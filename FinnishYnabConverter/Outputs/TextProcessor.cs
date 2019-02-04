namespace FinnishYnabConverter.Outputs
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using global::FinnishYnabConverter.Converters;
    using global::FinnishYnabConverter.Inputs;

    public class TextProcessor : IOutputProcessor
    {
        public void Process(InputFileInformation inputFileInformation, IBankConverter bankConverter)
        {
            if (inputFileInformation == null)
            {
                throw new ArgumentNullException(nameof(inputFileInformation));
            }

            string[] transactions = File.ReadAllLines(inputFileInformation.InputFilePath, inputFileInformation.InputFileEncoding);
            ICollection<string> formattedTransactions = bankConverter.Convert(transactions);
            string formattedFileName = $"{inputFileInformation.BankName}_ynab_transactions_{DateTime.Now.Year}{DateTime.Now.Month}{DateTime.Now.Day}.csv";
            string outputFilePath = Path.Combine(inputFileInformation.OutputDir, formattedFileName);

            using (TextWriter writer = new StreamWriter(outputFilePath, true, new UTF8Encoding(false)))
            {
                writer.NewLine = "\n";
                foreach (string formattedTransaction in formattedTransactions)
                    writer.WriteLine(formattedTransaction);
            }
        }
    }
}

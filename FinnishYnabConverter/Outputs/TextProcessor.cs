namespace FinnishYnabConverter.Outputs
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using global::FinnishYnabConverter.Formatters;

    public class TextProcessor : IOutputProcessor
    {
        public async Task Process(InputFileInformation inputFileInformation, IBankFormatter bankFormatter, CancellationToken cancellationToken)
        {
            string[] transactions = await File.ReadAllLinesAsync(inputFileInformation.InputFilePath, Encoding.Default, cancellationToken);
            ICollection<string> formattedTransactions = bankFormatter.Format(transactions);
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

namespace FinnishYnabConverter.Formatters
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;

    public class HandelsbankenFormatter : IBankFormatter
    {
        public void Format(string inputFilePath, string outputDir)
        {
            if (!File.Exists(inputFilePath))
            {
                throw new FileNotFoundException("File not found", inputFilePath);
            }

            if (!Directory.Exists(outputDir))
            {
                throw new DirectoryNotFoundException($"Directory {outputDir} not found");
            }

            string[] transactions = File.ReadAllLines(inputFilePath, Encoding.Default);
            List<string> formattedTransactions = new List<string>();

            for (int i = 0; i < transactions.Length; i++)
            {
                string formattedTransaction = "";
                string[] splittedTransaction = transactions[i].Split(';');
                if (i > 0)
                {
                    formattedTransaction += splittedTransaction[0].Replace("\"", "").Replace(".", "/") + ","; // Date
                    formattedTransaction += splittedTransaction[1].Replace("\"", "") + ",";
                    formattedTransaction += splittedTransaction[2].Replace("\"", "") + ","; // "Category" as empty
                    formattedTransaction += splittedTransaction[3].Replace("\"", "").Replace("'", "") + ","; // Memo
                    // Inflow or outflow
                    formattedTransaction += splittedTransaction[4].Contains("-") ?
                        splittedTransaction[4].Replace("\"", "").Replace(',', '.').Replace("-", "") + ","
                        : "," + splittedTransaction[4].Replace("\"", "").Replace(',', '.');
                }
                else
                {
                    formattedTransaction = "Date,Payee,Category,Memo,Outflow,Inflow";
                }
                formattedTransactions.Add(formattedTransaction);
            }
            string formattedFileName = $"Handelsbanken_ynab_transactions_{DateTime.Now.Year}{DateTime.Now.Month}{DateTime.Now.Day}.csv";
            string outputFilePath = Path.Combine(outputDir, formattedFileName);

            using (TextWriter writer = new StreamWriter(outputFilePath, true, new UTF8Encoding(false)))
            {
                writer.NewLine = "\n";
                foreach (string formattedTransaction in formattedTransactions)
                    writer.WriteLine(formattedTransaction);
            }
        }
    }
}
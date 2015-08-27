using log4net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FinnishYnabCvsConverter
{
    public class HandelsbankenFormatter : IBankFormatter
    {
        public static ILog Log;

        public HandelsbankenFormatter()
        {
            Log = LogManager.GetLogger(this.GetType());
        }

        public void Format(string path, string outputPath)
        {
            if (!File.Exists(path))
            {
                Log.Debug("Could not find file with path: " + path);
            }

            Log.Debug("Reading transactions to memory");

            string[] transactions = File.ReadAllLines(path, Encoding.Default);
            List<string> formattedTransactions = new List<string>();

            Log.Debug("Formatting transactions");
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
            Log.Debug("Writing formatted transactions to " + outputPath);
            string outputFileName = String.Format(outputPath + "Handelsbanken_transactions_{0}{1}{2}.csv", DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);

            using (TextWriter writer = new StreamWriter(outputFileName, true, new UTF8Encoding(false)))
            {
                writer.NewLine = "\n";
                foreach (string formattedTransaction in formattedTransactions)
                    writer.WriteLine(formattedTransaction);
            }
        }
    }
}
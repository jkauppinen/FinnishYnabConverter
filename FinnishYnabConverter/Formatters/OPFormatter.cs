namespace FinnishYnabConverter.Formatters
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;

    public class OPFormatter : IBankFormatter
    {
        public ICollection<string> Format(string[] transactions)
        {
            List<string> formattedTransactions = new List<string>();

            for (int i = 0; i < transactions.Length; i++)
            {
                string formattedTransaction = "";
                string[] splittedTransaction = transactions[i].Split(';');
                if (i > 0)
                {
                    formattedTransaction += splittedTransaction[0]
                    .Replace("\"", "")
                    .Replace(".", "/")
                     + ","; // Date

                    string test = splittedTransaction[5].Replace("\"", "");
                    formattedTransaction += splittedTransaction[5].Replace("\"", "") + ","; // Payee
                    formattedTransaction +=  ","; // Category as empty
                    formattedTransaction += splittedTransaction[8] + ","; // Memo

                    // Inflow or outflow
                    formattedTransaction += splittedTransaction[2].Contains("-") ?
                        splittedTransaction[2].Replace(',', '.').Replace("-", "") + ","
                        : "," + splittedTransaction[2].Replace(',', '.');

                }
                else
                {
                    formattedTransaction = "Date,Payee,Category,Memo,Outflow,Inflow";
                }
                formattedTransactions.Add(formattedTransaction);
            }
            return formattedTransactions; 
        }
    }
}
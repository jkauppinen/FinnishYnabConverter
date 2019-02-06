namespace FinnishYnabConverter.Tests
{
    using System;
    public static class Transactions
    {
        private static string _firstRow = "Date,Payee,Category,Memo,Outflow,Inflow";

        public static string[] CreateValidTransactions()
        {
            string[] validTransactions = new string[30];
            validTransactions[0] = _firstRow;
            DateTime dateToUse = new DateTime(DateTime.Now.Year, 1, 1);
            string payee = "BIG MONEY BUSINESS OY";
            string category = "";
            string memo = "MONEY GOES IN AND MONEY GOES OUT";
            double outflow = 0;
            double inflow = 0;
            Random r = new Random();

            for (int i = 0; i < 30; i++)
            {
                int coinFlip = r.Next(0, 2);
                double moneyValue = r.NextDouble();
                // Money goes out
                if (coinFlip == 1)
                {
                    outflow = moneyValue;
                    validTransactions[i] = $"{dateToUse.Day.ToString("'00")},{payee},{category},{memo},{outflow},,";
                }
                // Money goes in
                else
                {
                    inflow = r.NextDouble();
                    validTransactions[i] = $"{dateToUse.Day.ToString("'00") + ""},{payee},{category},{memo},,{inflow}";
                }
                dateToUse = dateToUse.AddDays(1);
            }
            return validTransactions;
        }
    }
}

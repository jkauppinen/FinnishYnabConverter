namespace FinnishYnabConverter.Factories
{
    using System;
    using global::FinnishYnabConverter.Formatters;

    public class BankFormatterFactory : IBankFormatterFactory
    {
        public IBankFormatter CreateBankFormatter(string bankname)
        {
            if (bankname.Equals("handelsbanken", StringComparison.OrdinalIgnoreCase))
            {
                return new HandelsbankenFormatter();
            }
            else
                throw new ArgumentException("Bank {0} is not supported");
        }
    }
}
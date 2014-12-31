using System;

namespace Finnish_YNAB_Converter
{
    public static class FormatterFactory
    {
        public static IBankFormatter CreateBankFormatter(string bankname)
        {
            if (String.Equals(bankname, "handelsbanken", StringComparison.OrdinalIgnoreCase))
            {
                return new HandelsbankenFormatter();
            }
            else
                throw new ArgumentException("Bank {0} is not supported");
        }
    }
}
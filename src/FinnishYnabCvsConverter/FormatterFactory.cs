using System;

namespace FinnishYnabCvsConverter
{
    public static class FormatterFactory
    {
        public static IBankFormatter CreateBankFormatter(string bankname)
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
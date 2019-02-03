namespace FinnishYnabConverter.Factories
{
    using System;
    using global::FinnishYnabConverter.Formatters;

    public class BankFormatterFactory : IBankFormatterFactory
    {
        public IBankFormatter CreateBankFormatter(string bankname)
        {
            if (bankname.Equals(SupportedBanks.Handelsbanken, StringComparison.OrdinalIgnoreCase))
            {
                return new HandelsbankenFormatter();
            }
            else if (bankname.Equals(SupportedBanks.OP, StringComparison.OrdinalIgnoreCase))
            {
                return new OPFormatter();
            }
            else
            {
                throw new ArgumentException("Bank not supported",nameof(bankname));
            }
        }
    }
}
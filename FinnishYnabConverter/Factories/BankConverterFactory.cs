namespace FinnishYnabConverter.Factories
{
    using System;
    using global::FinnishYnabConverter.Converters;

    public class BankConverterFactory : IBankConverterFactory
    {
        public IBankConverter CreateBankFormatter(string bankname)
        {
            if (bankname.Equals(SupportedBanks.Handelsbanken, StringComparison.OrdinalIgnoreCase))
            {
                return new HandelsbankenConverter();
            }
            else if (bankname.Equals(SupportedBanks.OP, StringComparison.OrdinalIgnoreCase))
            {
                return new OPConverter();
            }
            else
            {
                throw new ArgumentException("Bank not supported",nameof(bankname));
            }
        }
    }
}
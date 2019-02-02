namespace FinnishYnabConverter.Factories
{
    using System;
    using global::FinnishYnabConverter.Formatters;

    public interface IBankFormatterFactory
    {
        IBankFormatter CreateBankFormatter(string bankname);
    }
}
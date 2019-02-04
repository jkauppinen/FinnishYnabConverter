namespace FinnishYnabConverter.Factories
{
    using System;
    using global::FinnishYnabConverter.Converters;

    public interface IBankConverterFactory
    {
        IBankConverter CreateBankFormatter(string bankname);
    }
}
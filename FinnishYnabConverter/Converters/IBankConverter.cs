namespace FinnishYnabConverter.Converters
{
    using System.Collections.Generic;
    public interface IBankConverter
    {
        ICollection<string> Convert(string[] transactions);
    }
}
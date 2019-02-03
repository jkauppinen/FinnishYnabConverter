
namespace FinnishYnabConverter.Formatters
{
    using System.Collections.Generic;
    public interface IBankFormatter
    {
        ICollection<string> Format(string[] transactions);
    }
}
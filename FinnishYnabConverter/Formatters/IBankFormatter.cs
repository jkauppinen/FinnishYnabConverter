namespace FinnishYnabConverter.Formatters
{
    public interface IBankFormatter
    {
        void Format(string inputFilePath, string outputDir);
    }
}
namespace Finnish_YNAB_Converter
{
    public interface IBankFormatter
    {
        void Format(string inputPath, string outputPath);
    }
}
namespace FinnishYnabConverter
{
    public class InputFileInformation
    {
        public InputFileInformation(string bankName,string inputFilePath, string outputDir)
        {
            BankName = bankName;
            InputFilePath = inputFilePath;
            OutputDir = outputDir;
        }
        public string BankName { get; private set; }
        public string InputFilePath {get; private set;}
        public string OutputDir { get; private set; }
    }
}
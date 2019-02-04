using System.Text;

namespace FinnishYnabConverter.Inputs
{
    public class InputFileInformation
    {
        public InputFileInformation(string bankName, string inputFilePath, string outputDir, Encoding inputFileEncoding)
        {
            BankName = bankName;
            InputFilePath = inputFilePath;
            OutputDir = outputDir;
            InputFileEncoding = inputFileEncoding;
        }
        public string BankName { get; private set; }
        public string InputFilePath { get; private set; }
        public string OutputDir { get; private set; }
        public Encoding InputFileEncoding { get; private set; }
    }
}
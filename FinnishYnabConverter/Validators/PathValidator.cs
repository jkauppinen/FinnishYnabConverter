namespace FinnishYnabConverter.Validators
{
    using System;
    using System.Collections;
    using System.IO;
    using global::FinnishYnabConverter.Inputs;

    public class PathValidator : IBankValidator
    {
        public void Validate(InputFileInformation inputFileInformation)
        {
            if (!File.Exists(inputFileInformation.InputFilePath))
            {
                throw new FileNotFoundException("File not found",inputFileInformation.InputFilePath);
            }

            if (!Directory.Exists(inputFileInformation.OutputDir))
            {
                throw new DirectoryNotFoundException($"Directory {inputFileInformation.OutputDir} not found");
            }
        }
    }
}
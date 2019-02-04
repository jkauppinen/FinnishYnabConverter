
namespace FinnishYnabConverter.Outputs
{
    using System;
    using global::FinnishYnabConverter.Converters;
    using global::FinnishYnabConverter.Inputs;

    public interface IOutputProcessor
    {
        void Process(InputFileInformation inputFileInformation, IBankConverter bankConverter);
    }
}
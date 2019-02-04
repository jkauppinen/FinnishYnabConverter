namespace FinnishYnabConverter.Factories
{
    using global::FinnishYnabConverter.Inputs;
    using global::FinnishYnabConverter.Outputs;
    public interface IOutputProcessorFactory
    {
        IOutputProcessor CreateOutputProcessor(InputFileInformation inputFileInformation);
    }
}
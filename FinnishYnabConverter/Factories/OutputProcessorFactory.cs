namespace FinnishYnabConverter.Factories
{
    using global::FinnishYnabConverter.Inputs;
    using global::FinnishYnabConverter.Outputs;
    public class OutputProcessorFactory : IOutputProcessorFactory
    {
        public IOutputProcessor CreateOutputProcessor(InputFileInformation inputFileInformation)
        {
            return new TextProcessor();
        }
    }
}
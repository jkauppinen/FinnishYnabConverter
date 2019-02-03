
namespace FinnishYnabConverter.Outputs
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using global::FinnishYnabConverter.Formatters;

    public interface IOutputProcessor
    {
        Task Process(InputFileInformation inputFileInformation, IBankFormatter bankFormatter, CancellationToken cancellationToken);
    }
}
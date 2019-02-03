namespace FinnishYnabConverter
{
    using System.Threading;
    using System.Threading.Tasks;
    public interface IFinnishYnabConverter
    {
        Task Start(string[] args, CancellationToken cancellationToken);
    }
}
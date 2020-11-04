using System.Threading.Tasks;
using CryptoCompare.Models.Responses;
using JetBrains.Annotations;

namespace CryptoCompare.Clients
{
    public interface ITradingSignalsClient : IApiClient
    {
        Task<TradingSignalsResponse> BySymbol([NotNull] string toSymbol);
    }
}

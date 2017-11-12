namespace CryptoCompare
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ISubsClient : IApiClient
    {
        /// <summary>
        /// Get all the available streamer subscription channels for the requested pairs.
        /// </summary>
        /// <param name="fromSymbol">from symbol.</param>
        /// <param name="toSymbols">to symbols.</param>
        /// <returns>
        /// An asynchronous result that yields the list of subs.
        /// </returns>
        Task<SubListResponse> ListAsync(string fromSymbol, IEnumerable<string> toSymbols);
    }
}
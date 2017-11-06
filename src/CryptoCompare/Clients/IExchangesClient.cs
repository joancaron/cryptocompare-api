using System.Collections.Generic;
using System.Threading.Tasks;

namespace CryptoCompare
{
    /// <summary>
    /// Interface for exchanges api client.
    /// </summary>
    public interface IExchangesClient : IApiClient
    {
        /// <summary>
        /// all the exchanges that CryptoCompare has integrated with..
        /// </summary>
        Task<IDictionary<string, IDictionary<string, IEnumerable<string>>>> ListAsync();
    }
}

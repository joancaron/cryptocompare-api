using System.Collections.Generic;
using System.Threading.Tasks;

using CryptoCompare.Core;

namespace CryptoCompare.Clients
{
    public interface IPricesClient : IApiClient
    {
        /// <summary>
        /// Get the current price of any cryptocurrency in any other currency that you need.
        /// If the crypto does not trade directly into the toSymbol requested, BTC will be used for conversion.
        /// If the oposite pair trades we invert it (eg.: BTC-XMR).
        /// </summary>
        /// <param name="fromSymbol">from symbol.</param>
        /// <param name="toSymbols">to symbols.</param>
        /// <param name="exchangeName">Exchange name defult => CCCAGG</param>
        Task<IDictionary<string, decimal>> Single(string fromSymbol, IEnumerable<string> toSymbols, string exchangeName = null);
    }
}

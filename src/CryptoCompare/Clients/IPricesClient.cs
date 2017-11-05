using System.Collections.Generic;
using System.Threading.Tasks;

namespace CryptoCompare.Clients
{
    public interface IPricesClient : IApiClient
    {
        /// <summary>
        /// Same as single API path but with multiple from symbols.
        /// </summary>
        /// <param name="fromSymbols">from symbols.</param>
        /// <param name="toSymbols">to symbols.</param>
        /// <param name="tryConversion">(Optional) If set to false, it will try to get values without
        /// using any conversion at all (defaultVal:true)</param>
        /// <param name="exchangeName">(Optional) Exchange name defult => CCCAGG.</param>
        Task<IDictionary<string, IDictionary<string, decimal>>> Multi(
            IEnumerable<string> fromSymbols,
            IEnumerable<string> toSymbols,
            bool? tryConversion = null,
            string exchangeName = null);

        /// <summary>
        /// Get the current price of any cryptocurrency in any other currency that you need.
        /// If the crypto does not trade directly into the toSymbol requested, BTC will be used for conversion.
        /// If the oposite pair trades we invert it (eg.: BTC-XMR).
        /// </summary>
        /// <param name="fromSymbol">from symbol.</param>
        /// <param name="toSymbols">to symbols.</param>
        /// <param name="tryConversion">If set to false, it will try to get values without using any conversion at all (defaultVal:true)</param>
        /// <param name="exchangeName">Exchange name defult => CCCAGG</param>
        Task<IDictionary<string, decimal>> Single(
            string fromSymbol,
            IEnumerable<string> toSymbols,
            bool? tryConversion = null,
            string exchangeName = null);
    }
}

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CryptoCompare
{
    public interface IPricesClient : IApiClient
    {
        ///// <summary>
        ///// Compute the current trading info (price, vol, open, high, low etc) of the requested pair as a volume weighted average based on the exchanges requested.
        ///// </summary>
        ///// <param name="fromSymbol">from symbol.</param>
        ///// <param name="toSymbol">to symbol.</param>
        ///// <param name="markets">List of names of the exchanges.</param>
        ///// <param name="tryConversion">(Optional) If set to false, it will try to get values without
        ///// using any conversion at all (defaultVal:true)</param>
        Task<PriceAverageResponse> GenerateCustomAverageAsync(
            string fromSymbol,
            string toSymbol,
            IEnumerable<string> markets,
            bool? tryConversion = null);

        /// <summary>
        /// Same as single API path but with multiple from symbols.
        /// </summary>
        /// <param name="fromSymbols">from symbols.</param>
        /// <param name="toSymbols">to symbols.</param>
        /// <param name="tryConversion">(Optional) If set to false, it will try to get values without
        /// using any conversion at all (defaultVal:true)</param>
        /// <param name="exchangeName">(Optional) Exchange name defult => CCCAGG.</param>
        Task<PriceMultiResponse> MultipleSymbolsPriceAsync(
            IEnumerable<string> fromSymbols,
            IEnumerable<string> toSymbols,
            bool? tryConversion = null,
            string exchangeName = null);

        /// <summary>
        /// Get all the current trading info (price, vol, open, high, low etc) of any list of cryptocurrencies in any other currency that you need.
        /// If the crypto does not trade directly into the toSymbol requested, BTC will be used for conversion. 
        /// This API also returns Display values for all the fields.
        /// If the oposite pair trades we invert it (eg.: BTC-XMR).
        /// </summary>
        /// <param name="fromSymbols">from symbols.</param>
        /// <param name="toSymbols">to symbols.</param>
        /// <param name="tryConversion">(Optional) If set to false, it will try to get values without
        /// using any conversion at all (defaultVal:true)</param>
        /// <param name="exchangeName">(Optional) Exchange name default => CCCAGG.</param>
        Task<PriceMultiFullResponse> MultipleSymbolFullDataAsync(
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
        /// <param name="exchangeName">Exchange name default => CCCAGG</param>
        Task<PriceSingleResponse> SingleSymbolPriceAsync(
            string fromSymbol,
            IEnumerable<string> toSymbols,
            bool? tryConversion = null,
            string exchangeName = null);
    }
}

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CryptoCompare
{
    public interface IPricesClient : IApiClient
    {
        /// <summary>
        /// Compute the current trading info (price, vol, open, high, low etc) of the requested pair as a volume weighted average based on the exchanges requested.
        /// </summary>
        /// <param name="fromSymbol">from symbol.</param>
        /// <param name="toSymbol">to symbol.</param>
        /// <param name="exchangeNames">List of names of the exchanges.</param>
        /// <param name="tryConversion">(Optional) If set to false, it will try to get values without
        /// using any conversion at all (defaultVal:true)</param>
        Task<PriceAverageResponse> AverageAsync(
            string fromSymbol,
            string toSymbol,
            IEnumerable<string> exchangeNames,
            bool? tryConversion = null);

        /// <summary>
        /// Get the price of any cryptocurrency in any other currency that you need at a given timestamp.
        /// The price comes from the daily info - so it would be the price at the end of the day GMT based on the requested TS.
        /// If the crypto does not trade directly into the toSymbol requested, BTC will be used for conversion.
        /// Tries to get direct trading pair data, if there is none or it is more than 10 days before the ts requested, it uses BTC conversion.
        /// If the oposite pair trades we invert it (eg.: BTC-XMR)The calculation types are: Close - a Close of the day close price,MidHighLow - the average between the 24 H high and low.VolFVolT - the total volume to / the total volume from
        /// </summary>
        /// <param name="fromSymbol">from symbol.</param>
        /// <param name="toSymbols">to symbols.</param>
        /// <param name="requestedDate">The requested date.</param>
        /// <param name="calculationType">(Optional) Type of the calculation.</param>
        /// <param name="tryConversion">(Optional) If set to false, it will try to get values without
        /// using any conversion at all (defaultVal:true)</param>
        /// <param name="exchangeName">(Optional) Exchange name default => CCCAGG.</param>
        Task<PriceHistoricalReponse> HistoricalAsync(
            string fromSymbol,
            IEnumerable<string> toSymbols,
            DateTimeOffset requestedDate,
            CalculationType? calculationType = null,
            bool? tryConversion = null,
            IEnumerable<string> markets = null);

        /// <summary>
        /// Same as single API path but with multiple from symbols.
        /// </summary>
        /// <param name="fromSymbols">from symbols.</param>
        /// <param name="toSymbols">to symbols.</param>
        /// <param name="tryConversion">(Optional) If set to false, it will try to get values without
        /// using any conversion at all (defaultVal:true)</param>
        /// <param name="exchangeName">(Optional) Exchange name defult => CCCAGG.</param>
        Task<PriceMultiResponse> MultiAsync(
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
        Task<PriceMultiFullResponse> MultiFullAsync(
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
        Task<PriceSingleResponse> SingleAsync(
            string fromSymbol,
            IEnumerable<string> toSymbols,
            bool? tryConversion = null,
            string exchangeName = null);
    }
}

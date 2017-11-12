using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using JetBrains.Annotations;

namespace CryptoCompare
{
    public interface IHistoryClient : IApiClient
    {
        /// <summary>
        /// Get open, high, low, close, volumefrom and volumeto from the daily historical data.
        /// The values are based on 00:00 GMT time.It uses BTC conversion if data is not available because the coin is not trading in the specified currency.
        /// </summary>
        /// <param name="fromSymbol">from symbol. This cannot be null.</param>
        /// <param name="toSymbol">to symbol. This cannot be null.</param>
        /// <param name="limit">The limit number of returned results.</param>
        /// <param name="exchangeNames">List of exchanges names.</param>
        /// <param name="toDate">to date.</param>
        /// <param name="allData">(Optional) retrieve all data.</param>
        /// <param name="aggregate">(Optional) aggregates result.</param>
        /// <param name="tryConversion">(Optional) tries conversion.</param>
        Task<HistoryResponse> DayAsync(
            [NotNull] string fromSymbol,
            [NotNull] string toSymbol,
            int? limit,
            IEnumerable<string> exchangeNames,
            DateTimeOffset? toDate,
            bool? allData = null,
            int? aggregate = null,
            bool? tryConversion = null);

        /// <summary>
        /// Get open, high, low, close, volumefrom and volumeto from the hourly historical data.
        /// It uses BTC conversion if data is not available because the coin is not trading in the specified currency.
        /// </summary>
        /// <param name="fromSymbol">from symbol. This cannot be null.</param>
        /// <param name="toSymbol">to symbol. This cannot be null.</param>
        /// <param name="limit">The limit number of returned results.</param>
        /// <param name="exchangeNames">List of exchanges names.</param>
        /// <param name="toDate">to date.</param>
        /// <param name="allData">(Optional) retrieve all data.</param>
        /// <param name="aggregate">(Optional) aggregates result.</param>
        /// <param name="tryConversion">(Optional) tries conversion.</param>
        Task<HistoryResponse> HourAsync(
            [NotNull] string fromSymbol,
            [NotNull] string toSymbol,
            int? limit,
            IEnumerable<string> exchangeNames,
            DateTimeOffset? toDate,
            bool? allData = null,
            int? aggregate = null,
            bool? tryConversion = null);

        /// <summary>
        /// Get open, high, low, close, volumefrom and volumeto from the each minute historical data. 
        /// This data is only stored for 7 days, if you need more,use the hourly or daily path. 
        /// It uses BTC conversion if data is not available because the coin is not trading in the specified currency.
        /// </summary>
        /// <param name="fromSymbol">from symbol. This cannot be null.</param>
        /// <param name="toSymbol">to symbol. This cannot be null.</param>
        /// <param name="limit">The limit number of returned results.</param>
        /// <param name="exchangeNames">List of exchanges names.</param>
        /// <param name="toDate">to date.</param>
        /// <param name="allData">(Optional) retrieve all data.</param>
        /// <param name="aggregate">(Optional) aggregates result.</param>
        /// <param name="tryConversion">(Optional) tries conversion.</param>
        Task<HistoryResponse> MinuteAsync(
            [NotNull] string fromSymbol,
            [NotNull] string toSymbol,
            int? limit,
            IEnumerable<string> exchangeNames,
            DateTimeOffset? toDate,
            bool? allData = null,
            int? aggregate = null,
            bool? tryConversion = null);
    }
}

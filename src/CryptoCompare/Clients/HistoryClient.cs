using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

using JetBrains.Annotations;

namespace CryptoCompare
{
    public class HistoryClient : BaseApiClient, IHistoryClient
    {
        public HistoryClient([NotNull] HttpClient httpClient)
            : base(httpClient)
        {
        }

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
        public async Task<HistoryResponse> Day(
            [NotNull] string fromSymbol,
            [NotNull] string toSymbol,
            int? limit = null,
            IEnumerable<string> exchangeNames = null,
            DateTimeOffset? toDate = null,
            bool? allData = null,
            int? aggregate = null,
            bool? tryConversion = null)
        {
            return await this.History(
                       "day",
                       fromSymbol,
                       toSymbol,
                       limit,
                       exchangeNames,
                       toDate,
                       allData,
                       aggregate,
                       tryConversion);
        }

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
        public async Task<HistoryResponse> Hour(
            [NotNull] string fromSymbol,
            [NotNull] string toSymbol,
            int? limit = null,
            IEnumerable<string> exchangeNames = null,
            DateTimeOffset? toDate = null,
            bool? allData = null,
            int? aggregate = null,
            bool? tryConversion = null)
        {
            return await this.History(
                       "hour",
                       fromSymbol,
                       toSymbol,
                       limit,
                       exchangeNames,
                       toDate,
                       allData,
                       aggregate,
                       tryConversion);
        }

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
        public async Task<HistoryResponse> Minute(
            [NotNull] string fromSymbol,
            [NotNull] string toSymbol,
            int? limit = null,
            IEnumerable<string> exchangeNames = null,
            DateTimeOffset? toDate = null,
            bool? allData = null,
            int? aggregate = null,
            bool? tryConversion = null)
        {
            return await this.History(
                       "minute",
                       fromSymbol,
                       toSymbol,
                       limit,
                       exchangeNames,
                       toDate,
                       allData,
                       aggregate,
                       tryConversion);
        }

        private async Task<HistoryResponse> History(
            [NotNull] string method,
            [NotNull] string fromSymbol,
            [NotNull] string toSymbol,
            int? limit = null,
            IEnumerable<string> exchangeNames = null,
            DateTimeOffset? toDate = null,
            bool? allData = null,
            int? aggregate = null,
            bool? tryConversion = null)
        {
            Check.NotNullOrWhiteSpace(method, nameof(method));
            Check.NotNullOrWhiteSpace(toSymbol, nameof(toSymbol));
            Check.NotNullOrWhiteSpace(fromSymbol, nameof(fromSymbol));

            return await this.GetAsync<HistoryResponse>(
                       ApiUrls.History(
                           method,
                           fromSymbol,
                           toSymbol,
                           limit,
                           exchangeNames,
                           toDate,
                           allData,
                           aggregate,
                           tryConversion));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using CryptoCompare.Models.Responses;

using JetBrains.Annotations;

namespace CryptoCompare
{
    public interface IHistoryClient : IApiClient
    {
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
        /// <param name="markets">(Optional) Names of Exchanges default => CCCAGG.</param>
        Task<PriceHistoricalReponse> HistoricalForTimestampAsync(
            string fromSymbol,
            IEnumerable<string> toSymbols,
            DateTimeOffset requestedDate,
            IEnumerable<string> markets = null,
            CalculationType? calculationType = null,
            bool? tryConversion = null);

        /// <summary>
        /// Get open, high, low, close, volumefrom and volumeto from the daily historical data.
        /// The values are based on 00:00 GMT time.It uses BTC conversion if data is not available because the coin is not trading in the specified currency.
        /// </summary>
        /// <param name="fromSymbol">from symbol. This cannot be null.</param>
        /// <param name="toSymbol">to symbol. This cannot be null.</param>
        /// <param name="limit">The limit number of returned results.</param>
        /// <param name="exchangeName">Exchange name.</param>
        /// <param name="toDate">to date.</param>
        /// <param name="allData">(Optional) retrieve all data.</param>
        /// <param name="aggregate">(Optional) aggregates result.</param>
        /// <param name="tryConversion">(Optional) tries conversion.</param>
        Task<HistoryResponse> DailyAsync(
            [NotNull] string fromSymbol,
            [NotNull] string toSymbol,
            int? limit,
            string exchangeName = null,
            DateTimeOffset? toDate = null,
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
        /// <param name="exchangeName">Exchange name.</param>
        /// <param name="toDate">to date.</param>
        /// <param name="allData">(Optional) retrieve all data.</param>
        /// <param name="aggregate">(Optional) aggregates result.</param>
        /// <param name="tryConversion">(Optional) tries conversion.</param>
        Task<HistoryResponse> HourlyAsync(
            [NotNull] string fromSymbol,
            [NotNull] string toSymbol,
            int? limit = null,
            string exchangeName = null,
            DateTimeOffset? toDate = null,
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
        /// <param name="exchangeName">Exchange name.</param>
        /// <param name="toDate">to date.</param>
        /// <param name="allData">(Optional) retrieve all data.</param>
        /// <param name="aggregate">(Optional) aggregates result.</param>
        /// <param name="tryConversion">(Optional) tries conversion.</param>
        Task<HistoryResponse> MinutelyAsync(
            [NotNull] string fromSymbol,
            [NotNull] string toSymbol,
            int? limit = null,
            string exchangeName = null,
            DateTimeOffset? toDate = null,
            bool? allData = null,
            int? aggregate = null,
            bool? tryConversion = null);

        /// <summary>
        /// Get day average price. The values are based on hourly vwap data and the average can be calculated in different ways. It uses BTC conversion if data is not available because the coin is not trading in the specified currency. If tryConversion is set to false it will give you the direct data. If no toTS is given it will automatically do the current day. Also for different timezones use the UTCHourDiff param
        /// The calculation types are:
        /// HourVWAP - a VWAP of the hourly close price
        /// MidHighLow - the average between the 24 H high and low.
        /// VolFVolT - the total volume from / the total volume to (only avilable with tryConversion set to false so only for direct trades but the value should be the most accurate average day price)
        /// </summary>
        /// <param name="fromSymbol">The cryptocurrency symbol of interest. This cannot be null</param>
        /// <param name="toSymbol">The currency symbol to convert into. This cannot be null.</param>
        /// <param name="exchangeName">(Optional) The exchange to obtain data from (our aggregated average - CCCAGG - by default) .</param>
        /// <param name="toDate">(Optional) Last unix timestamp to return data for.</param>
        /// <param name="avgType">(Optional) Type of the average.</param>
        /// <param name="utcHourDiff">(Optional) By deafult it does UTC, if you want a different time zone just pass the hour difference. For PST you would pass -8 for example.</param>
        /// <param name="tryConversion">(Optional) If set to false, it will try to get only direct trading values.</param>
        Task<HistoryDayAverageResponse> DayAveragePriceAsync(
            [NotNull] string fromSymbol,
            [NotNull] string toSymbol,
            string exchangeName = null,
            DateTimeOffset? toDate = null,
            CalculationType? avgType = null,
            int? utcHourDiff = null,
            bool? tryConversion = null);

        /// <summary>
        /// Get total volume from the daily historical exchange data.The values are based on 00:00 GMT time. We store the data in BTC and we multiply by the BTC-tsym value.
        /// </summary>
        /// <param name="toSymbol">The currency symbol to convert into . This cannot be null.</param>
        /// <param name="exchangeName">(Optional) The exchange to obtain data from (our aggregated average - CCCAGG - by default) .</param>
        /// <param name="toDate">(Optional) Last unix timestamp to return data for.</param>
        /// <param name="limit">(Optional) The number of data points to return.</param>
        /// <param name="aggregate">(Optional) Time period to aggregate the data over (for daily it's days, for hourly it's hours and for minute histo it's minutes).</param>
        /// <param name="aggregatePredictableTimePeriods">(Optional) True by default, only used when the aggregate param is also in use. If false it will aggregate based on the current time. If the param is false and the time you make the call is 1pm - 2pm, with aggregate 2, it will create the time slots: ... 9am, 11am, 1pm. If the param is false and the time you make the call is 2pm - 3pm, with aggregate 2, it will create the time slots: ... 10am, 12am, 2pm. If the param is true (default) and the time you make the call is 1pm - 2pm, with aggregate 2, it will create the time slots: ... 8am, 10am, 12pm. If the param is true (default) and the time you make the call is 2pm - 3pm, with aggregate 2, it will create the time slots: ... 10am, 12am, 2pm..</param>
        /// <returns>
        /// The asynchronous result that yields a HistoryResponse.
        /// </returns>
        Task<ExchangeHistoryResponse> ExchangeDailyAsync(
            [NotNull] string toSymbol,
            string exchangeName = null,
            DateTimeOffset? toDate = null,
            int? limit = null,
            int? aggregate = null,
            bool? aggregatePredictableTimePeriods = null);

        /// <summary>
        /// Get total volume from the hourly historical exchange data.We store the data in BTC and we multiply by the BTC-tsym value.
        /// </summary>
        /// <param name="toSymbol">The currency symbol to convert into . This cannot be null.</param>
        /// <param name="exchangeName">(Optional) The exchange to obtain data from (our aggregated average - CCCAGG - by default) .</param>
        /// <param name="toDate">(Optional) Last unix timestamp to return data for.</param>
        /// <param name="limit">(Optional) The number of data points to return.</param>
        /// <param name="aggregate">(Optional) Time period to aggregate the data over (for daily it's days, for hourly it's hours and for minute histo it's minutes).</param>
        /// <param name="aggregatePredictableTimePeriods">(Optional) True by default, only used when the aggregate param is also in use. If false it will aggregate based on the current time. If the param is false and the time you make the call is 1pm - 2pm, with aggregate 2, it will create the time slots: ... 9am, 11am, 1pm. If the param is false and the time you make the call is 2pm - 3pm, with aggregate 2, it will create the time slots: ... 10am, 12am, 2pm. If the param is true (default) and the time you make the call is 1pm - 2pm, with aggregate 2, it will create the time slots: ... 8am, 10am, 12pm. If the param is true (default) and the time you make the call is 2pm - 3pm, with aggregate 2, it will create the time slots: ... 10am, 12am, 2pm..</param>
        /// <returns>
        /// The asynchronous result that yields a HistoryResponse.
        /// </returns>
        Task<ExchangeHistoryResponse> ExchangeHourlyAsync(
            [NotNull] string toSymbol,
            string exchangeName = null,
            DateTimeOffset? toDate = null,
            int? limit = null,
            int? aggregate = null,
            bool? aggregatePredictableTimePeriods = null);
    }
}

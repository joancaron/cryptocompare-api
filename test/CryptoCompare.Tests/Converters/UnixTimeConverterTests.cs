using System;
using System.Threading.Tasks;

using Xunit;

namespace CryptoCompare.Tests.Converters
{
    public class UnixTimeConverterTests
    {
        /// <summary>
        /// Should serialize candle data.
        /// </summary>
        /// <remarks>
        /// Test for https://github.com/joancaron/cryptocompare-api/issues/11
        /// </remarks>
        [Fact]
        public async Task ShouldSerializeCandleData()
        {
            var date = new DateTimeOffset(2018, 6, 15, 0, 0, 0, new TimeSpan(0, 0, 0));
            var unix = date.ToUnixTime();
            var hist = await CryptoCompareClient.Instance.History.HourlyAsync("BTC", "USD", 2, "Coinbase", date); 
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(hist);
        }
    }
}

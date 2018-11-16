using System;
using System.Threading.Tasks;

using CryptoCompare;

using Xunit;

namespace Cryptocompare.Integration.Tests.Clients
{
    public class HistoryClientTests
    {
        [Fact]
        public async Task CanCallHistoricalDailyEndpoint()
        {
            var result = await CryptoCompareClient.Instance.History.DailyAsync("BTC", "USD", 10);
            Assert.NotNull(result);
        }

        [Fact]
        public async Task CanCallHistoricalHourlyEndpoint()
        {
            var result = await CryptoCompareClient.Instance.History.HourlyAsync("BTC", "USD", 10);
            Assert.NotNull(result);
        }

        [Fact]
        public async Task CanCallHistoricalMinutelyEndpoint()
        {
            var result = await CryptoCompareClient.Instance.History.MinutelyAsync("BTC", "USD", 10);
            Assert.NotNull(result);
        }

        [Fact]
        public async Task CanCallHistoricalForTimestampEndpoint()
        {
            var result = await CryptoCompareClient.Instance.History.HistoricalForTimestampAsync("BTC", new[] { "USD" }, DateTimeOffset.Now.AddDays(-1));
            Assert.NotNull(result);
        }

        [Fact]
        public async Task CanCallDayAveragePriceEndpoint()
        {
            var result = await CryptoCompareClient.Instance.History.DayAveragePriceAsync("BTC", "USD");
            Assert.NotNull(result);
        }

        [Fact]
        public async Task CanCallExchangeDailyEndpoint()
        {
            var result = await CryptoCompareClient.Instance.History.ExchangeDailyAsync("BTC");
            Assert.NotNull(result);
        }

        [Fact]
        public async Task CanCallExchangeHourlyEndpoint()
        {
            var result = await CryptoCompareClient.Instance.History.ExchangeHourlyAsync("BTC");
            Assert.NotNull(result);
        }
    }
}

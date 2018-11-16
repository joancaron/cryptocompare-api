using System.Threading.Tasks;

using CryptoCompare;

using Xunit;

namespace Cryptocompare.Integration.Tests.Clients
{
    public class PriceClientTests
    {
        [Fact]
        public async Task CanCallSingleSymbolPriceEndpoint()
        {
            var result = await CryptoCompareClient.Instance.Prices.SingleSymbolPriceAsync("BTC", new[] { "USD", "JPY", "EUR" });
            Assert.NotNull(result);
        }

        [Fact]
        public async Task CanCallMultipleSymbolFullDataEndpoint()
        {
            var result = await CryptoCompareClient.Instance.Prices.MultipleSymbolFullDataAsync(new[] { "BTC", "ETH" }, new[] { "USD", "EUR" });
            Assert.NotNull(result);
        }

        [Fact]
        public async Task CanCallMultipleSymbolPriceEndpoint()
        {
            var result = await CryptoCompareClient.Instance.Prices.MultipleSymbolsPriceAsync(new[] { "BTC", "ETH" }, new[] { "USD", "EUR" });
            Assert.NotNull(result);
        }

        [Fact]
        public async Task CanCallGenerateCustomAverageEndpoint()
        {
            var result = await CryptoCompareClient.Instance.Prices.GenerateCustomAverageAsync("BTC", "USD", new[] { "Kraken" });
            Assert.NotNull(result);
        }
    }
}

using System.Threading.Tasks;

using CryptoCompare;

using Xunit;

namespace Cryptocompare.Integration.Tests.Clients
{
    public class TopListClientTests
    {
        [Fact]
        public async Task CanCallTopListByPairVolumeEndpoint()
        {
            var result = await CryptoCompareClient.Instance.Tops.ByPairVolumeAsync("BTC");
            Assert.NotNull(result);
        }

        [Fact]
        public async Task CanCallTopListExchangesFullDataByPairEndpoint()
        {
            var result = await CryptoCompareClient.Instance.Tops.ExchangesFullDataByPairAsync("BTC", "USD");
            Assert.NotNull(result);
        }

        [Fact]
        public async Task CanCallTopListExchangesVolumeDataByPairEndpoint()
        {
            var result = await CryptoCompareClient.Instance.Tops.ExchangesVolumeDataByPairAsync("BTC", "USD");
            Assert.NotNull(result);
        }

        [Fact]
        public async Task CanCallTopListTradingPairsEndpoint()
        {
            var result = await CryptoCompareClient.Instance.Tops.TradingPairsAsync("BTC");
            Assert.NotNull(result);
        }

        [Fact]
        public async Task CanCallTopListCoinFullDataByMarketCap()
        {
            var result = await CryptoCompareClient.Instance.Tops.CoinFullDataByMarketCap("EUR", 20);
            Assert.NotNull(result);
        }

        [Fact]
        public async Task CanCallTopListCoinFullDataBy24HVolume()
        {
            var result = await CryptoCompareClient.Instance.Tops.CoinFullDataBy24HVolume("EUR", 20);
            Assert.NotNull(result);
        }
    }
}

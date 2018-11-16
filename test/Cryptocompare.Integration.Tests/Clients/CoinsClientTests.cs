using System.Threading.Tasks;

using CryptoCompare;

using Xunit;

namespace Cryptocompare.Integration.Tests.Clients
{
    public class CoinsClientTests
    {
        [Fact]
        public async Task CanCallListEndpoint()
        {
            var result = await CryptoCompareClient.Instance.Coins.ListAsync();
            Assert.NotNull(result);
        }

        [Fact]
        public async Task CanCallSnapshotEndpoint()
        {
            var result = await CryptoCompareClient.Instance.Coins.SnapshotAsync("BTC", "USD");
            Assert.NotNull(result);
        }

        [Fact]
        public async Task CanCallSnapshotFullEndpoint()
        {
            var result = await CryptoCompareClient.Instance.Coins.SnapshotFullAsync(1182);
            Assert.NotNull(result);
        }
    }
}

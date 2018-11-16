using System.Threading.Tasks;

using CryptoCompare;

using Xunit;

namespace Cryptocompare.Integration.Tests.Clients
{
    public class MiningClientTests
    {
        [Fact]
        public async Task CanCallMiningContractsEndpoint()
        {
            var result = await CryptoCompareClient.Instance.Mining.ContractsAsync();
            Assert.NotNull(result);
        }

        [Fact]
        public async Task CanCallMiningEquipmentsEndpoint()
        {
            var result = await CryptoCompareClient.Instance.Mining.EquipmentsAsync();
            Assert.NotNull(result);
        }
    }
}

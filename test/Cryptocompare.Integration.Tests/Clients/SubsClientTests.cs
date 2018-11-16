using System.Threading.Tasks;

using CryptoCompare;

using Xunit;

namespace Cryptocompare.Integration.Tests.Clients
{
    public class SubsClientTests
    {
        [Fact]
        public async Task CanCallSocialStatsEndpoint()
        {
            var result = await CryptoCompareClient.Instance.Subs.ListAsync("BTC", new[] { "USD" });
            Assert.NotNull(result);
        }
    }
}

using System.Threading.Tasks;

using CryptoCompare;

using Xunit;

namespace Cryptocompare.Integration.Tests.Clients
{
    public class SocialStatsClientTests
    {
        [Fact]
        public async Task CanCallSocialStatsEndpoint()
        {
            var result = await CryptoCompareClient.Instance.SocialStats.StatsAsync(1182);
            Assert.NotNull(result);
        }
    }
}

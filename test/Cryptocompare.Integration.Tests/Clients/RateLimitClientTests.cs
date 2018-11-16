using System.Threading.Tasks;

using CryptoCompare;

using Xunit;

namespace Cryptocompare.Integration.Tests.Clients
{
    public class RateLimitClientTests
    {
        [Fact]
        public async Task CanCallRateLimitsCurrentHourEndpoint()
        {
            var result = await CryptoCompareClient.Instance.RateLimits.CurrentHourAsync();
            Assert.NotNull(result);
        }
    }
}

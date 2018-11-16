using System.Threading.Tasks;

using CryptoCompare;

using Xunit;

namespace Cryptocompare.Integration.Tests.Clients
{
    public class ExchangeClientTests
    {
        [Fact]
        public async Task CanCallExchangeListEndpoint()
        {
            var result = await CryptoCompareClient.Instance.Exchanges.ListAsync();
            Assert.NotNull(result);
        }
    }
}

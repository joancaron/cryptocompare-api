using System.Threading.Tasks;

using CryptoCompare;

using Xunit;

namespace Cryptocompare.Integration.Tests.Clients
{
    public class NewsClientTests
    {
        [Fact]
        public async Task CanCallNewsListEndpoint()
        {
            var result = await CryptoCompareClient.Instance.News.News();
            Assert.NotNull(result);
        }

        [Fact]
        public async Task CanCallNewsProvidersListEndpoint()
        {
            var result = await CryptoCompareClient.Instance.News.NewsProviders();
            Assert.NotNull(result);
        }
    }
}

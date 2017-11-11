using System.Linq;

using CryptoCompare.Tests.Infrastructure;

using FluentAssertions;

using Xunit;

namespace CryptoCompare.Tests.Models.Responses
{
    public class PriceHistoricalReponseTest
    {
        /// <summary>
        /// Can deserialize PriceHistoricalReponse.
        /// </summary>
        [Fact]
        public void Can_deserialize_PriceHistoricalReponse()
        {
            var model = TestHelper.ReadFixture("Prices.Historical").DeserializeJson<PriceHistoricalReponse>();

            model.Keys.Should().NotBeEmpty();
            model.Values.Should().NotBeEmpty();
            model.First().Value.First().Value.Should().BePositive();
        }
    }
}

using System.Linq;

using CryptoCompare.Tests.Infrastructure;

using FluentAssertions;

using Xunit;

namespace CryptoCompare.Tests.Models.Responses
{
    public class PriceMultiResponseTest
    {
        /// <summary>
        /// Can deserialize PriceMultiResponse.
        /// </summary>
        [Fact]
        public void Can_deserialize_PriceMultiResponse()
        {
            var model = TestHelper.ReadFixture("Prices.Multi").DeserializeJson<PriceMultiResponse>();

            model.Keys.Should().NotBeEmpty();
            model.Values.Should().NotBeEmpty();
            model.First().Value.First().Value.Should().BePositive();
        }
    }
}

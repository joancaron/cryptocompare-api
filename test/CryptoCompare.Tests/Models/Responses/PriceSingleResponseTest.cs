using System.Linq;

using CryptoCompare.Tests.Infrastructure;

using FluentAssertions;

using Xunit;

namespace CryptoCompare.Tests.Models.Responses
{
    public class PriceSingleResponseTest
    {
        /// <summary>
        /// Can deserialize PriceSingleResponse.
        /// </summary>
        [Fact]
        public void Can_deserialize_PriceSingleResponse()
        {
            var model = TestHelper.ReadFixture("Prices.Single").DeserializeJson<PriceSingleResponse>();

            model.Keys.Should().NotBeEmpty();
            model.Values.Should().NotBeEmpty();
            model.Values.First().Should().BePositive();
        }
    }
}

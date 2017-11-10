using System.Linq;

using CryptoCompare.Tests.Infrastructure;

using FluentAssertions;

using Xunit;

namespace CryptoCompare.Tests.Models.Responses
{
    public class PriceMultiFullResponseTest
    {
        /// <summary>
        /// Can deserialize PriceMultiResponse.
        /// </summary>
        [Fact]
        public void Can_deserialize_PriceMultiFullResponse()
        {
            var model = TestHelper.ReadFixture("Prices.MultiFull").DeserializeJson<PriceMultiFullResponse>();
            model.Raw.Should().NotBeNull();
            model.Display.Should().NotBeNull();
            model.Display.First().Value.Should().NotBeNull();
            model.Display.First().Value.First().Should().NotBeNull();
        }
    }
}

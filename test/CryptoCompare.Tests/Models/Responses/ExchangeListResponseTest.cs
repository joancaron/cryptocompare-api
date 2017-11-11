using System.Linq;

using CryptoCompare.Tests.Infrastructure;

using FluentAssertions;

using Xunit;

namespace CryptoCompare.Tests.Models.Responses
{
    public class ExchangeListResponseTest
    {
        /// <summary>
        /// Can deserialize ExchangeListResponse.
        /// </summary>
        [Fact]
        public void Can_deserialize_ExchangeListResponse()
        {
            var model = TestHelper.ReadFixture("Exchanges.List").DeserializeJson<ExchangeListResponse>();

            model.Keys.Should().NotBeEmpty();
            model.Values.Should().NotBeEmpty();

            var exchange = model.First();
            exchange.Key.Should().NotBeNullOrWhiteSpace();
            exchange.Value.Should().NotBeEmpty();
            exchange.Value.First().Value.Should().NotBeEmpty();
        }
    }
}

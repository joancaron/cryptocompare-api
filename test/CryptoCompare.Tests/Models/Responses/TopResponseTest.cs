using System.Linq;

using CryptoCompare.Tests.Infrastructure;

using FluentAssertions;

using Xunit;

namespace CryptoCompare.Tests.Models.Responses
{
    public class TopResponseTest
    {
        /// <summary>
        /// Can deserialize TopResponse.
        /// </summary>
        [Fact]
        public void Can_deserialize_TopResponse()
        {
            var model = TestHelper.ReadFixture("Tops.Pairs").DeserializeJson<TopResponse>();

            model.IsSuccessfulResponse.Should().BeTrue();
            model.Data.Should().NotBeEmpty();
            model.Data.Should().NotContainNulls();

            var info = model.Data.First();

            info.Exchange.Should().NotBeNullOrWhiteSpace();
            info.FromSymbol.Should().NotBeNullOrWhiteSpace();
            info.ToSymbol.Should().NotBeNullOrWhiteSpace();
            info.Volume24H.Should().BePositive();
            info.Volume24HTo.Should().BePositive();
        }
    }
}
namespace CryptoCompare.Tests.Models.Responses
{
    using System.Linq;

    using CryptoCompare.Tests.Infrastructure;

    using FluentAssertions;

    using Xunit;

    public class SubListResponseTest
    {
        /// <summary>
        /// Can deserialize TopResponse.
        /// </summary>
        [Fact]
        public void Can_deserialize_SubListResponse()
        {
            var model = TestHelper.ReadFixture("Subs.List").DeserializeJson<SubListResponse>();

            var result = model.First().Value;
            result.Should().NotBeNull();

            result.Current.Should().NotBeEmpty();
            result.Current.Should().NotContainNulls();
            result.Current.First().Exchange.Should().NotBeNullOrWhiteSpace();
            result.Current.First().FromSymbol.Should().NotBeNullOrWhiteSpace();
            result.Current.First().ToSymbol.Should().NotBeNullOrWhiteSpace();

            result.Trades.Should().NotBeEmpty();
            result.Trades.Should().NotContainNulls();
            result.Trades.First().Exchange.Should().NotBeNullOrWhiteSpace();
            result.Trades.First().FromSymbol.Should().NotBeNullOrWhiteSpace();
            result.Trades.First().ToSymbol.Should().NotBeNullOrWhiteSpace();

            result.CurrentAgg.Should().NotBeNull();
            result.CurrentAgg.Exchange.Should().NotBeNullOrWhiteSpace();
            result.CurrentAgg.FromSymbol.Should().NotBeNullOrWhiteSpace();
            result.CurrentAgg.ToSymbol.Should().NotBeNullOrWhiteSpace();
        }
    }
}
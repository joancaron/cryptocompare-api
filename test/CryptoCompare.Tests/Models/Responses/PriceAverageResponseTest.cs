using System;

using CryptoCompare.Tests.Infrastructure;

using FluentAssertions;

using Xunit;

namespace CryptoCompare.Tests.Models.Responses
{
    public class PriceAverageResponseTest
    {
        /// <summary>
        /// Can deserialize PriceAverageResponse.
        /// </summary>
        [Fact]
        public void Can_deserialize_PriceAverageResponse()
        {
            var model = TestHelper.ReadFixture("Prices.Average").DeserializeJson<PriceAverageResponse>();

            model.Display.Should().NotBeNull();
            model.Display.FromSymbol.Should().NotBeNullOrWhiteSpace();
            model.Display.ToSymbol.Should().NotBeNullOrWhiteSpace();
            model.Display.Market.Should().NotBeNullOrWhiteSpace();
            model.Display.Price.Should().NotBeNullOrWhiteSpace();
            model.Display.LastUpdate.Should().NotBeNullOrWhiteSpace();
            model.Display.LastVolume.Should().NotBeNullOrWhiteSpace();
            model.Display.LastVolumeTo.Should().NotBeNullOrWhiteSpace();
            model.Display.LastTradeId.Should().NotBeNullOrWhiteSpace();
            model.Display.Volume24Hour.Should().NotBeNullOrWhiteSpace();
            model.Display.Volume24HourTo.Should().NotBeNullOrWhiteSpace();
            model.Display.Open24Hour.Should().NotBeNullOrWhiteSpace();
            model.Display.High24Hour.Should().NotBeNullOrWhiteSpace();
            model.Display.Low24Hour.Should().NotBeNullOrWhiteSpace();
            model.Display.LastMarket.Should().NotBeNullOrWhiteSpace();
            model.Display.Change24Hour.Should().NotBeNullOrWhiteSpace();
            model.Display.ChangePCT24Hour.Should().NotBeNullOrWhiteSpace();
            model.Display.ChangeDay.Should().NotBeNullOrWhiteSpace();
            model.Display.ChangePCTDay.Should().NotBeNullOrWhiteSpace();

            model.Raw.Should().NotBeNull();
            model.Raw.FromSymbol.Should().NotBeNullOrWhiteSpace();
            model.Raw.FromSymbol.Should().NotBeNullOrWhiteSpace();
            model.Raw.ToSymbol.Should().NotBeNullOrWhiteSpace();
            model.Raw.Market.Should().NotBeNullOrWhiteSpace();
            model.Raw.Price.Should().BePositive();
            model.Raw.LastUpdate.Should().BeAfter(DateTimeOffset.MinValue);
            model.Raw.LastVolume.Should().BePositive();
            model.Raw.LastVolumeTo.Should().BePositive();
            model.Raw.LastTradeId.Should().NotBeNullOrWhiteSpace();
            model.Raw.Volume24Hour.Should().BePositive();
            model.Raw.Volume24HourTo.Should().BePositive();
            model.Raw.Open24Hour.Should().BePositive();
            model.Raw.High24Hour.Should().BePositive();
            model.Raw.Low24Hour.Should().BePositive();
            model.Raw.LastMarket.Should().NotBeNullOrWhiteSpace();
            model.Raw.Change24Hour.Should().NotBe(0);
            model.Raw.ChangePCT24Hour.Should().NotBe(0);
            model.Raw.ChangeDay.Should().BePositive();
            model.Raw.ChangePCTDay.Should().BePositive();
        }
    }
}

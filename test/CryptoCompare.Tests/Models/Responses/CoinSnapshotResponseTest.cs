using System;
using System.Linq;

using CryptoCompare.Tests.Infrastructure;

using FluentAssertions;

using Xunit;

namespace CryptoCompare.Tests.Models.Responses
{
    public class CoinSnapshotResponseTest
    {
        /// <summary>
        /// Cam deserialize CoinSnapshotResponse.
        /// </summary>
        [Fact]
        public void Cam_deserialize_CoinSnapshotResponse()
        {
            var model = TestHelper.ReadFixture("Coins.Snapshot").DeserializeJson<CoinSnapshotResponse>();

            model.IsSuccessfulResponse.Should().BeTrue();
            model.Data.Algorithm.Should().NotBeNullOrWhiteSpace();
            model.Data.ProofType.Should().NotBeNullOrWhiteSpace();
            model.Data.BlockNumber.Should().BePositive();
            model.Data.NetHashesPerSecond.Should().BePositive();
            model.Data.TotalCoinsMined.Should().BePositive();
            model.Data.BlockReward.Should().BePositive();

            // Aggregated data
            model.Data.AggregatedData.Should().NotBeNull();
            model.Data.AggregatedData.Type.Should().NotBeNullOrWhiteSpace();
            model.Data.AggregatedData.Market.Should().NotBeNullOrWhiteSpace();
            model.Data.AggregatedData.FromSymbol.Should().NotBeNullOrWhiteSpace();
            model.Data.AggregatedData.ToSymbol.Should().NotBeNullOrWhiteSpace();
            model.Data.AggregatedData.Flags.Should().NotBeNullOrWhiteSpace();
            model.Data.AggregatedData.Price.Should().BePositive();
            model.Data.AggregatedData.LastUpdate.Should().BeAfter(DateTimeOffset.MinValue);
            model.Data.AggregatedData.LastVolume.Should().BePositive();
            model.Data.AggregatedData.LastVolumeTo.Should().BePositive();
            model.Data.AggregatedData.LastTradeId.Should().NotBeNullOrWhiteSpace();
            model.Data.AggregatedData.VolumeDay.Should().BePositive();
            model.Data.AggregatedData.VolumeDayTo.Should().BePositive();
            model.Data.AggregatedData.Volume24Hour.Should().BePositive();
            model.Data.AggregatedData.Volume24HourTo.Should().BePositive();
            model.Data.AggregatedData.OpenDay.Should().BePositive();
            model.Data.AggregatedData.HighDay.Should().BePositive();
            model.Data.AggregatedData.LowDay.Should().BePositive();
            model.Data.AggregatedData.Open24Hour.Should().BePositive();
            model.Data.AggregatedData.High24Hour.Should().BePositive();
            model.Data.AggregatedData.Low24Hour.Should().BePositive();

            // Exchanges
            model.Data.Exchanges.Should().NotBeEmpty();
            model.Data.Exchanges.Should().NotContainNulls();

            var exchange = model.Data.Exchanges.First();

            exchange.Type.Should().NotBeNullOrWhiteSpace();
            exchange.Market.Should().NotBeNullOrWhiteSpace();
            exchange.FromSymbol.Should().NotBeNullOrWhiteSpace();
            exchange.Flags.Should().NotBeNullOrWhiteSpace();
            exchange.Price.Should().BePositive();
            exchange.LastUpdate.Should().BeAfter(DateTimeOffset.MinValue);
            exchange.LastVolume.Should().BePositive();
            exchange.LastVolumeTo.Should().BePositive();
            exchange.LastTradeId.Should().NotBeNullOrWhiteSpace();
            exchange.Volume24Hour.Should().BePositive();
            exchange.Volume24HourTo.Should().BePositive();
            exchange.Open24Hour.Should().BePositive();
            exchange.High24Hour.Should().BePositive();
            exchange.Low24Hour.Should().BePositive();
        }
    }
}

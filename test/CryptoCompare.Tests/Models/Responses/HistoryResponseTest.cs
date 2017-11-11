using System;
using System.Linq;
using System.Threading.Tasks;

using CryptoCompare.Tests.Infrastructure;

using FluentAssertions;

using Xunit;

namespace CryptoCompare.Tests.Models.Responses
{
    public class HistoryResponseTest
    {
        /// <summary>
        /// Can deserialize HistoryReponse.
        /// </summary>
        [Fact]
        public void Can_deserialize_HistoryReponse()
        {
            var model = TestHelper.ReadFixture("History").DeserializeJson<HistoryResponse>();

            model.IsSuccessfulResponse.Should().BeTrue();
            model.Data.Should().NotBeEmpty();

            var candle = model.Data.First();
            candle.Time.Should().BeAfter(DateTimeOffset.MinValue);
            candle.Close.Should().BePositive();
            candle.High.Should().BePositive();
            candle.Low.Should().BePositive();
            candle.Open.Should().BePositive();
            candle.VolumeFrom.Should().BePositive();
            candle.VolumeTo.Should().BePositive();
        }
    }
}

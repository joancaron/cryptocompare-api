using System.Linq;

using CryptoCompare.Tests.Infrastructure;

using FluentAssertions;

using Xunit;

namespace CryptoCompare.Tests.Models.Responses
{
    public class CoinListResponseTest
    {
        /// <summary>
        /// Can deserialize coin list response.
        /// </summary>
        [Fact]
        public void Can_deserialize_coin_list_response()
        {
            var model = TestHelper.ReadFixture("Coins.List").DeserializeJson<CoinListResponse>();

            model.IsSuccessfulResponse.Should().BeTrue();
            model.BaseImageUrl.Should().NotBeNullOrWhiteSpace();
            model.BaseLinkUrl.Should().NotBeNullOrWhiteSpace();
            model.Coins.Should().NotBeEmpty();

            var coin = model.Coins.First();
            coin.Value.Id.Should().NotBeNullOrWhiteSpace();
            coin.Value.Url.Should().NotBeNullOrWhiteSpace();
            coin.Value.ImageUrl.Should().NotBeNullOrWhiteSpace();
            coin.Value.CoinName.Should().NotBeNullOrWhiteSpace();
            coin.Value.FullName.Should().NotBeNullOrWhiteSpace();
            coin.Value.Algorithm.Should().NotBeNullOrWhiteSpace();
            coin.Value.ProofType.Should().NotBeNullOrWhiteSpace();
            coin.Value.FullyPremined.Should().NotBeNullOrWhiteSpace();
            coin.Value.TotalCoinSupply.Should().NotBeNullOrWhiteSpace();
            coin.Value.PreMinedValue.Should().NotBeNullOrWhiteSpace();
            coin.Value.TotalCoinsFreeFloat.Should().NotBeNullOrWhiteSpace();
            coin.Value.SortOrder.Should().BePositive();
        }
    }
}

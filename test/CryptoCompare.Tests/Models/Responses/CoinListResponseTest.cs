using System.Linq;

using CryptoCompare.Tests.Infrastructure;

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

            Assert.True(model.IsSuccessfulResponse);
            Assert.NotNull(model.BaseImageUrl);
            Assert.NotNull(model.BaseLinkUrl);
            Assert.NotEmpty(model.Coins);

            var coin = model.Coins.First();
            Assert.NotNull(coin.Value.Id);
            Assert.NotNull(coin.Value.Url);
            Assert.NotNull(coin.Value.ImageUrl);
            Assert.NotNull(coin.Value.CoinName);
            Assert.NotNull(coin.Value.FullName);
            Assert.NotNull(coin.Value.Algorithm);
            Assert.NotNull(coin.Value.ProofType);
            Assert.NotNull(coin.Value.FullyPremined);
            Assert.NotNull(coin.Value.TotalCoinSupply);
            Assert.NotNull(coin.Value.PreMinedValue);
            Assert.NotNull(coin.Value.TotalCoinsFreeFloat);
            Assert.True(coin.Value.SortOrder > 0);
        }
    }
}

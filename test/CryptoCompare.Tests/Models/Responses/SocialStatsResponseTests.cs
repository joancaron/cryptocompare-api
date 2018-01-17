using CryptoCompare.Tests.Infrastructure;

using FluentAssertions;

using Xunit;

namespace CryptoCompare.Tests.Models.Responses
{
    public class SocialStatsResponseTests
    {
        /// <summary>
        /// Can deserialize RateLimitsResponse.
        /// </summary>
        [Fact]
        public void Can_deserialize_SocialStatsResponse()
        {
            var model = TestHelper.ReadFixture("SocialStats.Stats").DeserializeJson<SocialStatsResponse>();
            model.Message.Should().NotBeNullOrWhiteSpace();
            model.Response.Should().BeEquivalentTo("Success");
            model.SocialStats.General.Should().NotBeNull();
            model.SocialStats.General.Name.Should().BeEquivalentTo("BTC");
            model.SocialStats.CryptoCompare.Should().NotBeNull();
            model.SocialStats.CryptoCompare.SimilarItems[0].Id.ShouldBeEquivalentTo(7605);
            model.SocialStats.CryptoCompare.CryptopianFollowers[0].Id.ShouldBeEquivalentTo(495830);
            model.SocialStats.Twitter.Following.Should().BeEquivalentTo("105");
            model.SocialStats.Reddit.PostsPerHour.Should().BeEquivalentTo("23.93");
            model.SocialStats.Facebook.Likes.ShouldBeEquivalentTo(36497);
            model.SocialStats.CodeRepository.Repositories[0].CreatedAt.Should().BeEquivalentTo("1304525025");
        }
    }
}

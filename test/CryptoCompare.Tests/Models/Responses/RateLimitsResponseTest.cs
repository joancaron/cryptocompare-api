using CryptoCompare.Tests.Infrastructure;

using FluentAssertions;

using Xunit;

namespace CryptoCompare.Tests.Models.Responses
{
    public class RateLimitsResponseTest
    {
        /// <summary>
        /// Can deserialize RateLimitsResponse.
        /// </summary>
        [Fact]
        public void Can_deserialize_RateLimitsResponse()
        {
            var model = TestHelper.ReadFixture("RateLimits").DeserializeJson<RateLimitResponse>();

            model.IsSuccessfulResponse.Should().BeTrue();
            model.CallsLeft.Should().NotBeNull();
            model.CallsLeft.Price.Should().BePositive();
            model.CallsLeft.Histo.Should().BePositive();
            model.CallsLeft.News.Should().BePositive();

            model.CallsMade.Should().NotBeNull();
            model.CallsMade.Price.Should().BePositive();
            model.CallsMade.Histo.Should().BePositive();
            model.CallsMade.News.Should().BePositive();
        }
    }
}

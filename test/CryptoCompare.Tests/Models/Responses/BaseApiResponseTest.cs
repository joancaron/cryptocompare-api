using CryptoCompare.Tests.Infrastructure;

using FluentAssertions;

using Xunit;

namespace CryptoCompare.Tests.Models.Responses
{
    public class BaseApiResponseTest
    {
        /// <summary>
        /// Can deserialize error.
        /// </summary>
        [Fact]
        public void Can_deserialize_error()
        {
            var model = TestHelper.ReadFixture("Error").DeserializeJson<BaseApiResponse>();

            model.IsSuccessfulResponse.Should().BeFalse();
            model.Status.Should().NotBeNullOrWhiteSpace();
            model.StatusMessage.Should().NotBeNullOrWhiteSpace();
            model.StatusType.Should().BePositive();
            model.Path.Should().NotBeNullOrWhiteSpace();
            model.ErrorsSummary.Should().NotBeNullOrWhiteSpace();
        }
    }
}

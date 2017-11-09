using CryptoCompare.Tests.Infrastructure;

using Xunit;

namespace CryptoCompare.Tests.Models.Responses
{
    public class BaseApiResponseTest
    {
        /// <summary>
        /// Can deserialize error.
        /// </summary>
        [Fact]
        public void CanDeserializeError()
        {
            var model = TestHelper.ReadFixture("Error").DeserializeJson<BaseApiResponse>();

            Assert.False(model.IsSuccessfulResponse);
            Assert.Equal("Error", model.Status);
            Assert.Equal("Message", model.StatusMessage);
            Assert.Equal(1, model.StatusType);
            Assert.Equal("/stats/", model.Path);
            Assert.Equal("Not implemented", model.ErrorsSummary);
        }
    }
}

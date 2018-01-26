using System.Linq;

using CryptoCompare.Tests.Infrastructure;

using FluentAssertions;

using Xunit;

namespace CryptoCompare.Tests.Models.Responses
{
    public class TopVolumesResponseTest
    {
        /// <summary>
        /// Can deserialize TopVolumesResponse.
        /// </summary>
        [Fact]
        public void Can_deserialize_TopVolumesResponse()
        {
            var model = TestHelper.ReadFixture("Tops.Volumes").DeserializeJson<TopVolumesResponse>();

            model.IsSuccessfulResponse.Should().BeTrue();
            model.VolSymbol.Should().NotBeNullOrWhiteSpace();
            model.Data.Should().NotBeEmpty();
            model.Data.Should().NotContainNulls();

            var info = model.Data.First();
            info.Symbol.Should().NotBeNullOrWhiteSpace();
            info.Supply.Should().BePositive();
            info.Fullname.Should().NotBeNullOrWhiteSpace();
            info.Name.Should().NotBeNullOrWhiteSpace();
            info.Id.Should().NotBeNullOrWhiteSpace();
            info.Volume24HourTo.Should().BePositive();
        }
    }
}
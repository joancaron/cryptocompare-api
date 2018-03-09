using System;
using System.Linq;

using CryptoCompare.Tests.Infrastructure;

using FluentAssertions;

using Xunit;

namespace CryptoCompare.Tests.Models.Responses
{
    public class MiningEquipmentsResponseTest
    {
        /// <summary>
        /// Can deserialize MiningEquipmentsResponse.
        /// </summary>
        [Fact]
        public void Can_deserialize_MiningEquipmentsResponse()
        {
            var model = TestHelper.ReadFixture("Mining.Equipments").DeserializeJson<MiningEquipmentsResponse>();

            model.IsSuccessfulResponse.Should().BeTrue();
            model.MiningData.Should().NotBeNull();

            var equipment = model.MiningData.First();

            equipment.Value.AffiliateUrl.Should().NotBeNullOrWhiteSpace();
            equipment.Value.Algorithm.Should().NotBeNullOrWhiteSpace();
            equipment.Value.Company.Should().NotBeNullOrWhiteSpace();
            equipment.Value.Cost.Should().BeGreaterOrEqualTo(0);
            equipment.Value.CurrenciesAvailable.Should().NotBeNullOrWhiteSpace();
            equipment.Value.CurrenciesAvailableLogo.Should().NotBeNullOrWhiteSpace();
            equipment.Value.CurrenciesAvailableName.Should().NotBeNullOrWhiteSpace();
            equipment.Value.Currency.Should().NotBeNullOrWhiteSpace();
            equipment.Value.HashesPerSecond.Should().NotBeNullOrWhiteSpace();
            equipment.Value.Id.Should().NotBeNullOrWhiteSpace();
            equipment.Value.LogoUrl.Should().NotBeNullOrWhiteSpace();
            equipment.Value.Name.Should().NotBeNullOrWhiteSpace();
            equipment.Value.ParentId.Should().NotBeNullOrWhiteSpace();
            equipment.Value.Recommended.Should().BeTrue();
            equipment.Value.Sponsored.Should().BeTrue();
            equipment.Value.ParentId.Should().NotBeNullOrWhiteSpace();

            equipment.Value.EquipmentType.Should().NotBeNullOrWhiteSpace();
            equipment.Value.PowerConsumption.Should().NotBeNullOrWhiteSpace();
        }
    }
}

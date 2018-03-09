using System;
using System.Linq;

using CryptoCompare.Tests.Infrastructure;

using FluentAssertions;

using Xunit;

namespace CryptoCompare.Tests.Models.Responses
{
    public class MiningContractsResponseTest
    {
        /// <summary>
        /// Can deserialize MiningContractsResponse.
        /// </summary>
        [Fact]
        public void Can_deserialize_MiningContractsResponse()
        {
            var model = TestHelper.ReadFixture("Mining.Contracts").DeserializeJson<MiningContractsResponse>();

            model.IsSuccessfulResponse.Should().BeTrue();
            model.MiningData.Should().NotBeNull();

            var contract = model.MiningData.First();

            contract.Value.AffiliateUrl.Should().NotBeNullOrWhiteSpace();
            contract.Value.Algorithm.Should().NotBeNullOrWhiteSpace();
            contract.Value.Company.Should().NotBeNullOrWhiteSpace();
            contract.Value.Cost.Should().BeGreaterOrEqualTo(0);
            contract.Value.CurrenciesAvailable.Should().NotBeNullOrWhiteSpace();
            contract.Value.CurrenciesAvailableLogo.Should().NotBeNullOrWhiteSpace();
            contract.Value.CurrenciesAvailableName.Should().NotBeNullOrWhiteSpace();
            contract.Value.Currency.Should().NotBeNullOrWhiteSpace();
            contract.Value.HashesPerSecond.Should().NotBeNullOrWhiteSpace();
            contract.Value.Id.Should().NotBeNullOrWhiteSpace();
            contract.Value.LogoUrl.Should().NotBeNullOrWhiteSpace();
            contract.Value.Name.Should().NotBeNullOrWhiteSpace();
            contract.Value.ParentId.Should().NotBeNullOrWhiteSpace();
            contract.Value.Recommended.Should().BeTrue();
            contract.Value.Sponsored.Should().BeTrue();
            contract.Value.ParentId.Should().NotBeNullOrWhiteSpace();

            contract.Value.ContractLength.Should().NotBeNullOrWhiteSpace();
            contract.Value.FeePercentage.Should().NotBeNullOrWhiteSpace();
            contract.Value.FeeValue.Should().BePositive();
            contract.Value.FeeValueCurrency.Should().NotBeNullOrWhiteSpace();
        }
    }
}

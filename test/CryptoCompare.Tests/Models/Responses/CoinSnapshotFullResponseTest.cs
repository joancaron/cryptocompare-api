using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;

using CryptoCompare.Tests.Infrastructure;

using FluentAssertions;

using Xunit;

namespace CryptoCompare.Tests.Models.Responses
{
    public class CoinSnapshotFullResponseTest
    {
        /// <summary>
        /// Can deserialize CoinSnapshotFullResponse.
        /// </summary>
        [Fact]
        public void Can_deserialize_CoinSnapshotFullResponse()
        {
            
            var model = TestHelper.ReadFixture("Coins.SnapshotFull").DeserializeJson<CoinSnapshotFullResponse>();

            model.IsSuccessfulResponse.Should().BeTrue();
            model.Data.Should().NotBeNull();

            // SEO
            model.Data.SEO.PageTitle.Should().NotBeNullOrWhiteSpace();
            model.Data.SEO.PageDescription.Should().NotBeNullOrWhiteSpace();
            model.Data.SEO.BaseUrl.Should().NotBeNullOrWhiteSpace();
            model.Data.SEO.BaseImageUrl.Should().NotBeNullOrWhiteSpace();
            model.Data.SEO.OgImageUrl.Should().NotBeNullOrWhiteSpace();
            model.Data.SEO.OgImageWidth.Should().BePositive();
            model.Data.SEO.OgImageHeight.Should().BePositive();

            // General
            model.Data.General.Should().NotBeNull();
            model.Data.General.Id.Should().NotBeNullOrWhiteSpace();
            model.Data.General.DocumentType.Should().NotBeNullOrWhiteSpace();
            model.Data.General.H1Text.Should().NotBeNullOrWhiteSpace();
            model.Data.General.DangerTop.Should().NotBeNullOrWhiteSpace();
            model.Data.General.WarningTop.Should().NotBeNullOrWhiteSpace();
            model.Data.General.InfoTop.Should().NotBeNullOrWhiteSpace();
            model.Data.General.Symbol.Should().NotBeNullOrWhiteSpace();
            model.Data.General.Url.Should().NotBeNullOrWhiteSpace();
            model.Data.General.BaseAngularUrl.Should().NotBeNullOrWhiteSpace();
            model.Data.General.Name.Should().NotBeNullOrWhiteSpace();
            model.Data.General.ImageUrl.Should().NotBeNullOrWhiteSpace();
            model.Data.General.Features.Should().NotBeNullOrWhiteSpace();
            model.Data.General.Technology.Should().NotBeNullOrWhiteSpace();
            model.Data.General.TotalCoinsMined.Should().BePositive();
            model.Data.General.Algorithm.Should().NotBeNullOrWhiteSpace();
            model.Data.General.ProofType.Should().NotBeNullOrWhiteSpace();
            model.Data.General.StartDate.Should().BeAfter(DateTime.MinValue);
            model.Data.General.Twitter.Should().NotBeNullOrWhiteSpace();
            model.Data.General.AffiliateUrl.Should().NotBeNullOrWhiteSpace();
            model.Data.General.Website.Should().NotBeNullOrWhiteSpace();
            model.Data.General.LastBlockExplorerUpdateTS.Should().BeAfter(DateTimeOffset.MinValue);
            model.Data.General.DifficultyAdjustment.Should().NotBeNullOrWhiteSpace();
            model.Data.General.BlockRewardReduction.Should().NotBeNullOrWhiteSpace();
            model.Data.General.BlockNumber.Should().BePositive();
            model.Data.General.BlockTime.Should().BePositive();
            model.Data.General.NetHashesPerSecond.Should().BePositive();
            model.Data.General.TotalCoinsMined.Should().BePositive();
            model.Data.General.PreviousTotalCoinsMined.Should().BePositive();
            model.Data.General.BlockReward.Should().BePositive();

            // ICO
            model.Data.ICO.Should().NotBeNull();
            model.Data.ICO.Status.Should().NotBeNullOrWhiteSpace();
            model.Data.ICO.Description.Should().NotBeNullOrWhiteSpace();
            model.Data.ICO.TokenType.Should().NotBeNullOrWhiteSpace();
            model.Data.ICO.Website.Should().NotBeNullOrWhiteSpace();
            model.Data.ICO.WebsiteLink.Should().NotBeNullOrWhiteSpace();
            model.Data.ICO.PublicPortfolioUrl.Should().NotBeNullOrWhiteSpace();
            model.Data.ICO.PublicPortfolioId.Should().NotBeNullOrWhiteSpace();
            model.Data.ICO.Features.Should().NotBeNullOrWhiteSpace();
            model.Data.ICO.FundingTarget.Should().NotBeNullOrWhiteSpace();
            model.Data.ICO.FundingCap.Should().NotBeNullOrWhiteSpace();
            model.Data.ICO.ICOTokenSupply.Should().NotBeNullOrWhiteSpace();
            model.Data.ICO.TokenSupplyPostICO.Should().NotBeNullOrWhiteSpace();
            model.Data.ICO.TokenPercentageForInvestors.Should().NotBeNullOrWhiteSpace();
            model.Data.ICO.TokenReserveSplit.Should().NotBeNullOrWhiteSpace();
            model.Data.ICO.Date.Should().BeAfter(DateTimeOffset.MinValue);
            model.Data.ICO.EndDate.Should().BeAfter(DateTimeOffset.MinValue);
            model.Data.ICO.FundsRaisedList.Should().NotBeNullOrWhiteSpace();
            model.Data.ICO.FundsRaisedUSD.Should().NotBeNullOrWhiteSpace();
            model.Data.ICO.StartPrice.Should().NotBeNullOrWhiteSpace();
            model.Data.ICO.StartPriceCurrency.Should().NotBeNullOrWhiteSpace();
            model.Data.ICO.PaymentMethod.Should().NotBeNullOrWhiteSpace();
            model.Data.ICO.Jurisdiction.Should().NotBeNullOrWhiteSpace();
            model.Data.ICO.LegalAdvisers.Should().NotBeNullOrWhiteSpace();
            model.Data.ICO.LegalForm.Should().NotBeNullOrWhiteSpace();
            model.Data.ICO.SecurityAuditCompany.Should().NotBeNullOrWhiteSpace();
            model.Data.ICO.Blog.Should().NotBeNullOrWhiteSpace();
            model.Data.ICO.BlogLink.Should().NotBeNullOrWhiteSpace();
            model.Data.ICO.WhitePaper.Should().NotBeNullOrWhiteSpace();
            model.Data.ICO.WhitePaperLink.Should().NotBeNullOrWhiteSpace();

            // Streamer data
            model.Data.StreamerDataRaw.Should().NotBeEmpty();
            model.Data.StreamerDataRaw.Should().NotContainNulls();

            // Subs
            model.Data.Subs.Should().NotBeEmpty();
            var sub = model.Data.Subs.First();
            sub.SubId.Should().Be(SubId.Current);
            sub.Exchange.Should().NotBeNullOrWhiteSpace();
            sub.FromSymbol.Should().NotBeNullOrWhiteSpace();
            sub.ToSymbol.Should().NotBeNullOrWhiteSpace();
        }

        /// <summary>
        /// BugFix_8_Should not raise exception when deserialize json.
        /// </summary>
        [Fact]
        public void BugFix_8_Should_not_raise_exception_when_deserializes_json()
        {
            var coin = TestHelper.ReadFixture("Coins.BugFix-8_SnapshotFull-33639").DeserializeJson<CoinSnapshotFullResponse>();
        }
    }
}

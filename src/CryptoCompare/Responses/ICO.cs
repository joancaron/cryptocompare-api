using System;

using CryptoCompare.Converters;

using Newtonsoft.Json;

namespace CryptoCompare.Responses
{
    public class ICO
    {
        public string Blog { get; set; }

        public string BlogLink { get; set; }

        [JsonConverter(typeof(UnixTimeConverter))]
        public DateTimeOffset Date { get; set; }

        public string Description { get; set; }

        [JsonConverter(typeof(UnixTimeConverter))]
        public DateTimeOffset EndDate { get; set; }

        public string Features { get; set; }

        public string FundingCap { get; set; }

        public string FundingTarget { get; set; }

        public string FundsRaisedList { get; set; }

        public string FundsRaisedUSD { get; set; }

        public string ICOTokenSupply { get; set; }

        public string Jurisdiction { get; set; }

        public string LegalAdvisers { get; set; }

        public string LegalForm { get; set; }

        public string PaymentMethod { get; set; }

        public string PublicPortfolioId { get; set; }

        public string PublicPortfolioUrl { get; set; }

        public string SecurityAuditCompany { get; set; }

        public decimal StartPrice { get; set; }

        public string StartPriceCurrency { get; set; }

        public string Status { get; set; }

        public string TokenPercentageForInvestors { get; set; }

        public string TokenReserveSplit { get; set; }

        public string TokenSupplyPostICO { get; set; }

        public string TokenType { get; set; }

        public string Website { get; set; }

        public string WebsiteLink { get; set; }

        public string WhitePaper { get; set; }

        public string WhitePaperLink { get; set; }
    }
}

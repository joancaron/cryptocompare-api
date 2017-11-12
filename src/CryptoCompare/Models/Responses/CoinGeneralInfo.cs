using System;

using Newtonsoft.Json;

namespace CryptoCompare
{
    public class CoinGeneralInfo
    {
        public string AffiliateUrl { get; set; }

        public string Algorithm { get; set; }

        public string BaseAngularUrl { get; set; }

        public long BlockNumber { get; set; }

        public long BlockReward { get; set; }

        public string BlockRewardReduction { get; set; }

        public long BlockTime { get; set; }

        public string DangerTop { get; set; }

        public string Description { get; set; }

        public string DifficultyAdjustment { get; set; }

        public string DocumentType { get; set; }

        public string Features { get; set; }

        public string H1Text { get; set; }

        public string Id { get; set; }

        public string ImageUrl { get; set; }

        public string InfoTop { get; set; }

        [JsonConverter(typeof(UnixTimeConverter))]
        public DateTimeOffset LastBlockExplorerUpdateTS { get; set; }

        public string Name { get; set; }

        public double NetHashesPerSecond { get; set; }

        public double PreviousTotalCoinsMined { get; set; }

        public string ProofType { get; set; }

        [JsonConverter(typeof(IsoDateTimeWithFormatConverter), "dd/MM/yyyy")]
        public DateTimeOffset StartDate { get; set; }

        public string Symbol { get; set; }

        public string Technology { get; set; }

        public double TotalCoinsMined { get; set; }

        public long TotalCoinSupply { get; set; }

        public string Twitter { get; set; }

        public string Url { get; set; }

        public string WarningTop { get; set; }

        public string Website { get; set; }
    }
}

using Newtonsoft.Json;

namespace CryptoCompare
{
    public class CoinFullAggregatedData : CoinAggregatedData
    {
        [JsonProperty("CHANGE24HOUR")]
        public decimal? Change24Hour { get; set; }

        [JsonProperty("CHANGEDAY")]
        public decimal? ChangeDay { get; set; }

        [JsonProperty("CHANGEPCT24HOUR")]
        public decimal? ChangePCT24Hour { get; set; }

        [JsonProperty("CHANGEPCTDAY")]
        public decimal? ChangePCTDay { get; set; }

        [JsonProperty("MKTCAP")]
        public decimal? MarketCap { get; set; }

        [JsonProperty("TOTALVOLUME24H")]
        public decimal? TotalVolume24H { get; set; }

        [JsonProperty("TOTALVOLUME24HTO")]
        public decimal? TotalVolume24HTo { get; set; }
    }
}

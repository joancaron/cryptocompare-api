using Newtonsoft.Json;

namespace CryptoCompare
{
    public class CoinFullAggregatedDataDisplay
    {
        [JsonProperty("CHANGE24HOUR")]
        public string Change24Hour { get; set; }

        [JsonProperty("CHANGEDAY")]
        public string ChangeDay { get; set; }

        [JsonProperty("CHANGEPCT24HOUR")]
        public string ChangePCT24Hour { get; set; }

        [JsonProperty("CHANGEPCTDAY")]
        public string ChangePCTday { get; set; }

        [JsonProperty("FROMSYMBOL")]
        public string FromSymbol { get; set; }

        [JsonProperty("HIGH24HOUR")]
        public string High24Hour { get; set; }

        [JsonProperty("HIGHDAY")]
        public string HighDay { get; set; }

        [JsonProperty("LASTMARKET")]
        public string LastMarket { get; set; }

        [JsonProperty("LASTTRADEID")]
        public string LastTradeid { get; set; }

        [JsonProperty("LASTUPDATE")]
        public string LastUpdate { get; set; }

        [JsonProperty("LASTVOLUME")]
        public string LastVolume { get; set; }

        [JsonProperty("LASTVOLUMETO")]
        public string LastVolumeTo { get; set; }

        [JsonProperty("LOW24HOUR")]
        public string Low24Hour { get; set; }

        [JsonProperty("LOWDAY")]
        public string LowDay { get; set; }

        [JsonProperty("MARKET")]
        public string Market { get; set; }

        [JsonProperty("MKTCAP")]
        public string MarketCap { get; set; }

        [JsonProperty("OPEN24HOUR")]
        public string Open24Hour { get; set; }

        [JsonProperty("OPENDAY")]
        public string OpenDay { get; set; }

        [JsonProperty("PRICE")]
        public string Price { get; set; }

        [JsonProperty("SUPPLY")]
        public string Supply { get; set; }

        [JsonProperty("TOSYMBOL")]
        public string ToSymbol { get; set; }

        [JsonProperty("TOTALVOLUME24H")]
        public string TotalVolume24H { get; set; }

        [JsonProperty("TOTALVOLUME24HTO")]
        public string TotalVolume24HTo { get; set; }

        [JsonProperty("VOLUME24HOUR")]
        public string Volume24Hour { get; set; }

        [JsonProperty("VOLUME24HOURTO")]
        public string Volume24HourTo { get; set; }

        [JsonProperty("VOLUMEDAY")]
        public string VolumeDay { get; set; }

        [JsonProperty("VOLUMEDAYTO")]
        public string VolumeDayTo { get; set; }
    }
}

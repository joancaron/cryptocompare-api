using System;

using Newtonsoft.Json;

namespace CryptoCompare
{
    public class AggregatedData
    {
        [JsonProperty("FLAGS")]
        public string Flags { get; set; }

        [JsonProperty("FROMSYMBOL")]
        public string FromSymbol { get; set; }

        [JsonProperty("HIGH24HOUR")]
        public decimal? High24Hour { get; set; }

        [JsonProperty("LASTTRADEID")]
        public string LastTradeId { get; set; }

        [JsonConverter(typeof(UnixTimeConverter))]
        [JsonProperty("LASTUPDATE")]
        public DateTimeOffset LastUpdate { get; set; }

        [JsonProperty("LASTVOLUME")]
        public decimal? LastVolume { get; set; }

        [JsonProperty("LASTVOLUMETO")]
        public decimal? LastVolumeTo { get; set; }

        [JsonProperty("LOW24HOUR")]
        public decimal? Low24Hour { get; set; }

        [JsonProperty("MARKET")]
        public string Market { get; set; }

        [JsonProperty("OPEN24HOUR")]
        public decimal? Open24Hour { get; set; }

        [JsonProperty("PRICE")]
        public decimal? Price { get; set; }

        [JsonProperty("TOSYMBOL")]
        public string ToSymbol { get; set; }

        [JsonProperty("TYPE")]
        public string Type { get; set; }

        [JsonProperty("VOLUME24HOUR")]
        public decimal? Volume24Hour { get; set; }

        [JsonProperty("VOLUME24HOURTO")]
        public decimal? Volume24HourTo { get; set; }
    }
}

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
        public double? High24Hour { get; set; }

        [JsonProperty("LASTTRADEID")]
        public string LastTradeId { get; set; }

        [JsonConverter(typeof(UnixTimeConverter))]
        [JsonProperty("LASTUPDATE")]
        public DateTimeOffset LastUpdate { get; set; }

        [JsonProperty("LASTVOLUME")]
        public double? LastVolume { get; set; }

        [JsonProperty("LASTVOLUMETO")]
        public double? LastVolumeTo { get; set; }

        [JsonProperty("LOW24HOUR")]
        public double? Low24Hour { get; set; }

        [JsonProperty("MARKET")]
        public string Market { get; set; }

        [JsonProperty("OPEN24HOUR")]
        public double? Open24Hour { get; set; }

        [JsonProperty("PRICE")]
        public double? Price { get; set; }

        [JsonProperty("TOSYMBOL")]
        public string ToSymbol { get; set; }

        [JsonProperty("TYPE")]
        public string Type { get; set; }

        [JsonProperty("VOLUME24HOUR")]
        public double? Volume24Hour { get; set; }

        [JsonProperty("VOLUME24HOURTO")]
        public double? Volume24HourTo { get; set; }
    }
}

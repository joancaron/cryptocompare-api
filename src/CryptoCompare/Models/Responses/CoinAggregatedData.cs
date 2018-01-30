using Newtonsoft.Json;

namespace CryptoCompare
{
    public class CoinAggregatedData : AggregatedData
    {
        [JsonProperty("HIGHDAY")]
        public double? HighDay { get; set; }

        [JsonProperty("LASTMARKET")]
        public string LastMarket { get; set; }

        [JsonProperty("LOWDAY")]
        public double? LowDay { get; set; }

        [JsonProperty("OPENDAY")]
        public double? OpenDay { get; set; }

        [JsonProperty("VOLUMEDAY")]
        public double? VolumeDay { get; set; }

        [JsonProperty("VOLUMEDAYTO")]
        public double? VolumeDayTo { get; set; }
    }
}

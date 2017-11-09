using Newtonsoft.Json;

namespace CryptoCompare
{
    public class CoinAggregatedData : AggregatedData
    {
        [JsonProperty("HIGHDAY")]
        public decimal HighDay { get; set; }

        [JsonProperty("LASTMARKET")]
        public string LastMarket { get; set; }

        [JsonProperty("LOWDAY")]
        public decimal LowDay { get; set; }

        [JsonProperty("OPENDAY")]
        public decimal OpenDay { get; set; }

        [JsonProperty("VOLUMEDAY")]
        public decimal VolumeDay { get; set; }

        [JsonProperty("VOLUMEDAYTO")]
        public decimal VolumeDayTo { get; set; }
    }
}

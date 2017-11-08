using Newtonsoft.Json;

namespace CryptoCompare
{
    public class PriceAverageResponse
    {
        [JsonProperty("DISPLAY")]
        public CoinFullAggregatedDataDisplay Display { get; set; }

        [JsonProperty("RAW")]
        public CoinFullAggregatedData Raw { get; set; }
    }
}

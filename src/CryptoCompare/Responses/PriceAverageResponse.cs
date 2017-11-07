using System.Collections.Generic;

using Newtonsoft.Json;

namespace CryptoCompare
{
    public class PriceAverageResponse
    {
        [JsonProperty("RAW")]
        public CoinFullAggregatedData Raw { get; set; }

        [JsonProperty("DISPLAY")]
        public CoinFullAggregatedDataDisplay Display { get; set; }
    }
}

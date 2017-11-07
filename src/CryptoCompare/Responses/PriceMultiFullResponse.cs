using System.Collections.Generic;

using Newtonsoft.Json;

namespace CryptoCompare
{
    public class PriceMultiFullResponse
    {
        [JsonProperty("RAW")]
        public IDictionary<string, IDictionary<string, CoinFullAggregatedData>> Raw { get; set; }

        [JsonProperty("DISPLAY")]
        public IDictionary<string, IDictionary<string, CoinFullAggregatedDataDisplay>> Display { get; set; }
    }
}

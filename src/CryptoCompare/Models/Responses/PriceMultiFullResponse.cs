using Newtonsoft.Json;

namespace CryptoCompare
{
    public class PriceMultiFullResponse
    {
        [JsonProperty("DISPLAY")]
        public PriceMultiFullDisplay Display { get; set; }

        [JsonProperty("RAW")]
        public PriceMultiFullRaw Raw { get; set; }
    }
}

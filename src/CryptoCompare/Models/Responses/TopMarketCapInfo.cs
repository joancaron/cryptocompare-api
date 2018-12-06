using Newtonsoft.Json;

namespace CryptoCompare
{
    public class TopMarketCapInfo
    {
        public CoinInfo CoinInfo { get; set; }

        [JsonProperty("DISPLAY")]
        public MarketCapDisplay Display { get; set; }

        [JsonProperty("RAW")]
        public MarketCapRaw Raw { get; set; }
    }
}

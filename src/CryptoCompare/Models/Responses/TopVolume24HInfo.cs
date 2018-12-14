using Newtonsoft.Json;

namespace CryptoCompare
{
    public class TopVolume24HInfo
    {
        public CoinInfo CoinInfo { get; set; }

        [JsonProperty("DISPLAY")]
        public Volume24HDisplay Display { get; set; }

        [JsonProperty("RAW")]
        public Volume24HRaw Raw { get; set; }
    }
}

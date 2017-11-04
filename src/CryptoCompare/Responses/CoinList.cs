using System.Collections.Generic;

using CryptoCompare.Clients;

using Newtonsoft.Json;

namespace CryptoCompare.Responses
{
    public class CoinList : BaseApiResponse
    {
        [JsonProperty("Data")]
        public IDictionary<string, CoinInfo> Coins { get; set; }
    }
}
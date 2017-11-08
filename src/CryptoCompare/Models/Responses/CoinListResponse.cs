using System.Collections.Generic;

using Newtonsoft.Json;

namespace CryptoCompare
{
    /// <summary>
    /// List of coins.
    /// </summary>
    /// <seealso cref="T:CryptoCompare.Responses.BaseApiResponse"/>
    public class CoinListResponse : BaseApiResponse
    {
        /// <summary>
        /// Gets or sets the coins data.
        /// </summary>
        [JsonProperty("Data")]
        public IReadOnlyDictionary<string, CoinInfo> Coins { get; set; }
    }
}

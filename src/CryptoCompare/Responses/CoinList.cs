using System.Collections.Generic;

using Newtonsoft.Json;

namespace CryptoCompare
{
    /// <summary>
    /// List of coins.
    /// </summary>
    /// <seealso cref="T:CryptoCompare.Responses.BaseApiResponse"/>
    public class CoinList : BaseApiResponse
    {
        /// <summary>
        /// Gets or sets the coins data.
        /// </summary>
        [JsonProperty("Data")]
        public IDictionary<string, CoinInfo> Coins { get; set; }
    }
}

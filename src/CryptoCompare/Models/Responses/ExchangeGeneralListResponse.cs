using System.Collections.Generic;

using Newtonsoft.Json;

namespace CryptoCompare
{
    /// <summary>
    /// List of all exchanges general info.
    /// </summary>
    /// <seealso cref="T:CryptoCompare.Responses.BaseApiResponse"/>
    public class ExchangeGeneralListResponse : BaseApiResponse
    {
        public string BaseImageUrl { get; set; }

        public string BaseLinkUrl { get; set; }

        /// <summary>
        /// Gets or sets the exchanges data.
        /// </summary>
        [JsonProperty("Data")]
        public IReadOnlyDictionary<string, ExchangeGeneralInfo> Exchanges { get; set; }
    }
}

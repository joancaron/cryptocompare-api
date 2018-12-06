using System.Collections.Generic;

using Newtonsoft.Json;

namespace CryptoCompare
{
    public class TopMarketCapResponse : BaseApiResponse
    {
        public IReadOnlyList<TopMarketCapInfo> Data { get; set; }
    }
}

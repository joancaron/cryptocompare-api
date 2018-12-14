using System.Collections.Generic;

using Newtonsoft.Json;

namespace CryptoCompare
{
    public class TopVolume24HResponse : BaseApiResponse
    {
        public IReadOnlyList<TopVolume24HInfo> Data { get; set; }
    }
}

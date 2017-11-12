using System.Collections.Generic;

namespace CryptoCompare
{
    public class TopResponse : BaseApiResponse
    {
        public IReadOnlyList<TopInfo> Data { get; set; }
    }
}

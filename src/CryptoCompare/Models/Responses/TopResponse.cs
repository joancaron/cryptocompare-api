namespace CryptoCompare
{
    using System.Collections.Generic;

    public class TopResponse : BaseApiResponse
    {
        public IReadOnlyList<TopInfo> Data { get; set; }
    }
}
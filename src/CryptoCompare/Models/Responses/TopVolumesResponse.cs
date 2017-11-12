using System.Collections.Generic;

namespace CryptoCompare
{
    public class TopVolumesResponse : BaseApiResponse
    {
        public IReadOnlyList<TopVolumeInfo> Data { get; set; }

        public string VolSymbol { get; set; }
    }
}

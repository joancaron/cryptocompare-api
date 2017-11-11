namespace CryptoCompare
{
    using System.Collections.Generic;

    public class TopVolumesResponse : BaseApiResponse
    {
        public string VolSymbol { get; set; }
        public IReadOnlyList<TopVolumeInfo> Data { get; set; }
    }
}
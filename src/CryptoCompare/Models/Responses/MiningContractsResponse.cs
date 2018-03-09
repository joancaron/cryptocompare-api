using System.Collections.Generic;

namespace CryptoCompare
{
    public class MiningContractsResponse : BaseApiResponse
    {
        public IReadOnlyDictionary<string, MiningContract> MiningData { get; set; }
    }
}

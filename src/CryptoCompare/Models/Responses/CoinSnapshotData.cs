using System.Collections.Generic;

namespace CryptoCompare
{
    public class CoinSnapshotData
    {
        public CoinAggregatedData AggregatedData { get; set; }

        public string Algorithm { get; set; }

        public long? BlockNumber { get; set; }

        public double? BlockReward { get; set; }

        public IReadOnlyList<AggregatedData> Exchanges { get; set; }

        public double? NetHashesPerSecond { get; set; }

        public string ProofType { get; set; }

        public long TotalCoinsMined { get; set; }
    }
}

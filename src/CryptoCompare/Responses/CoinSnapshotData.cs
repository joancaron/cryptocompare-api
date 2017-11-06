using System.Collections.Generic;

namespace CryptoCompare
{
    public class CoinSnapshotData
    {
        public CoinSnapshotAggregatedData AggregatedData { get; set; }

        public string Algorithm { get; set; }

        public long BlockNumber { get; set; }

        public double BlockReward { get; set; }

        public IEnumerable<CoinSnapshotExchange> Exchanges { get; set; }

        public double NetHashesPerSecond { get; set; }

        public string ProofType { get; set; }

        public long TotalCoinsMined { get; set; }
    }
}

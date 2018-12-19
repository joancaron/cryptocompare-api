using System.Collections.Generic;

namespace CryptoCompare
{
    public class TopExchangeInfo
    {
        public CoinInfo CoinInfo { get; set; }

        public AggregatedData AggregatedData { get; set; }

        public IEnumerable<CoinFullAggregatedDataDisplay> Exchanges { get; set; }
    }
}
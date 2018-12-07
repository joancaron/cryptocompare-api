using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace CryptoCompare
{
    public class MarketCapRaw : ReadOnlyDictionary<string, CoinFullAggregatedData>
    {
        public MarketCapRaw(IDictionary<string, CoinFullAggregatedData> dictionary)
            : base(dictionary)
        {
        }
    }
}
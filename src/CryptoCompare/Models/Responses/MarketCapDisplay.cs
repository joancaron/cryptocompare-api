using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace CryptoCompare
{
    public class MarketCapDisplay : ReadOnlyDictionary<string, CoinFullAggregatedDataDisplay>
    {
        public MarketCapDisplay(IDictionary<string, CoinFullAggregatedDataDisplay> dictionary)
            : base(dictionary)
        {
        }
    }
}
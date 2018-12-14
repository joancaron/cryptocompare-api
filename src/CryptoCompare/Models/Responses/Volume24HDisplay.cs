using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace CryptoCompare
{
    public class Volume24HDisplay : ReadOnlyDictionary<string, CoinFullAggregatedDataDisplay>
    {
        public Volume24HDisplay(IDictionary<string, CoinFullAggregatedDataDisplay> dictionary)
            : base(dictionary)
        {
        }
    }
}
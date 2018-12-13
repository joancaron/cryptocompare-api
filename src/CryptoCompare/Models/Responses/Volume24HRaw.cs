using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace CryptoCompare
{
    public class Volume24HRaw : ReadOnlyDictionary<string, CoinFullAggregatedData>
    {
        public Volume24HRaw(IDictionary<string, CoinFullAggregatedData> dictionary)
            : base(dictionary)
        {
        }
    }
}
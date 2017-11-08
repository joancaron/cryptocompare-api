using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace CryptoCompare
{
    public class PriceMultiFullRaw : ReadOnlyDictionary<string, IReadOnlyDictionary<string, CoinFullAggregatedData>>
    {
        public PriceMultiFullRaw(IDictionary<string, IReadOnlyDictionary<string, CoinFullAggregatedData>> dictionary)
            : base(dictionary)
        {
        }
    }
}

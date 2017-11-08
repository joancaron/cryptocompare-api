using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace CryptoCompare
{
    public class
        PriceMultiFullDisplay : ReadOnlyDictionary<string, IReadOnlyDictionary<string, CoinFullAggregatedDataDisplay>>
    {
        public PriceMultiFullDisplay(
            IDictionary<string, IReadOnlyDictionary<string, CoinFullAggregatedDataDisplay>> dictionary)
            : base(dictionary)
        {
        }
    }
}

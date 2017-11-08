using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace CryptoCompare
{
    public class PriceHistoricalReponse : ReadOnlyDictionary<string, IReadOnlyDictionary<string, decimal>>
    {
        public PriceHistoricalReponse(IDictionary<string, IReadOnlyDictionary<string, decimal>> dictionary)
            : base(dictionary)
        {
        }
    }
}

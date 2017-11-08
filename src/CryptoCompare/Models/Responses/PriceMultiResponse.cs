using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace CryptoCompare
{
    public class PriceMultiResponse : ReadOnlyDictionary<string, IReadOnlyDictionary<string, decimal>>
    {
        public PriceMultiResponse(IDictionary<string, IReadOnlyDictionary<string, decimal>> dictionary)
            : base(dictionary)
        {
        }
    }
}

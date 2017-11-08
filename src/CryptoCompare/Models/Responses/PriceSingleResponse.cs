using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace CryptoCompare
{
    public class PriceSingleResponse : ReadOnlyDictionary<string, decimal>
    {
        public PriceSingleResponse(IDictionary<string, decimal> dictionary)
            : base(dictionary)
        {
        }
    }
}

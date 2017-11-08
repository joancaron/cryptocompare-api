using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace CryptoCompare
{
    public class ExchangeListResponse : ReadOnlyDictionary<string, IReadOnlyDictionary<string, IReadOnlyList<string>>>
    {
        public ExchangeListResponse(IDictionary<string, IReadOnlyDictionary<string, IReadOnlyList<string>>> dictionary)
            : base(dictionary)
        {
        }
    }
}

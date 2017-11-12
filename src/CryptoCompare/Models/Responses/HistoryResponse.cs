using System.Collections.Generic;

namespace CryptoCompare
{
    public class HistoryResponse : BaseApiResponse
    {
        public IReadOnlyList<CandleData> Data { get; set; }
    }
}

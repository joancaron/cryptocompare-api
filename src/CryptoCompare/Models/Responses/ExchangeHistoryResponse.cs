using System.Collections.Generic;

namespace CryptoCompare
{
    public class ExchangeHistoryResponse : BaseApiResponse
    {
        public IReadOnlyList<ExchangeHistoryData> Data { get; set; }
    }
}
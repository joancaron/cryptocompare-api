using System.Collections.Generic;

namespace CryptoCompare.Models.Responses
{
    public class TradingSignalsResponse : BaseApiResponse
    {
        public TradingSignalsData Data { get; set; }
    }
}
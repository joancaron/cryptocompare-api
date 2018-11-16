using System;

using Newtonsoft.Json;

namespace CryptoCompare
{
    public class ExchangeHistoryData
    {
        [JsonConverter(typeof(UnixTimeConverter))]
        public DateTimeOffset Time { get; set; }

        public decimal Volume { get; set; }
    }
}
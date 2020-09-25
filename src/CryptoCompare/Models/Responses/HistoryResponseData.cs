using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace CryptoCompare
{
    public class HistoryResponseData
    {
        public bool Aggregated { get; set; }

        [JsonConverter(typeof(UnixTimeConverter))]
        public DateTimeOffset TimeFrom { get; set; }

        [JsonConverter(typeof(UnixTimeConverter))]
        public DateTimeOffset TimeTo { get; set; }

        public IReadOnlyList<CandleData> Data { get; set; }
    }
}
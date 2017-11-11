using System;

using Newtonsoft.Json;

namespace CryptoCompare
{
    public class CandleData
    {
        [JsonConverter(typeof(UnixTimeConverter))]
        public DateTimeOffset Time { get; set; }

        public decimal Close { get; set; }

        public decimal High { get; set; }

        public decimal Low { get; set; }

        public decimal Open { get; set; }

        public decimal VolumeFrom { get; set; }

        public decimal VolumeTo { get; set; }
    }
}
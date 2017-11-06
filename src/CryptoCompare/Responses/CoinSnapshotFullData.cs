using System.Collections.Generic;

using Newtonsoft.Json;

namespace CryptoCompare
{
    public class CoinSnapshotFullData
    {
        public CoinGeneralInfo General { get; set; }

        public ICO ICO { get; set; }

        public SEO SEO { get; set; }

        public string[] StreamerDataRaw { get; set; }

        [JsonConverter(typeof(StringToSubConverter))]
        public IEnumerable<Sub> Subs { get; set; }
    }
}

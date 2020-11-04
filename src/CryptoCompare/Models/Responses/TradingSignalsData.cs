using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace CryptoCompare.Models.Responses
{
    public class TradingSignalsData
    {
        public long Id { get; set; }

        public long Time { get; set; }

        public string Symbol { get; set; }

        public string PartnerSymbol { get; set; }

        public Signal InOutVar { get; set; }

        public Signal LargetxsVar { get; set; }

        public Signal AddressesNetGrowth { get; set; }

        public Signal ConcentrationVar { get; set; }
    }

    public partial class Signal
    {
        public string Category { get; set; }

        public string Sentiment { get; set; }

        public double Value { get; set; }

        public double Score { get; set; }

        [JsonProperty("score_threshold_bearish")]
        public double ScoreThresholdBearish { get; set; }

        [JsonProperty("score_threshold_bullish")]
        public double ScoreThresholdBullish { get; set; }
    }
}
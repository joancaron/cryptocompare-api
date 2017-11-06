using JetBrains.Annotations;

namespace CryptoCompare
{
    public struct Sub
    {
        public Sub([NotNull] string exchange, [NotNull]string fromSymbol, SubId subId, [NotNull]string toSymbol)
        {
            Check.NotNullOrWhiteSpace(exchange, nameof(exchange));
            Check.NotNullOrWhiteSpace(fromSymbol, nameof(fromSymbol));
            Check.NotNullOrWhiteSpace(toSymbol, nameof(toSymbol));
            this.Exchange = exchange;
            this.FromSymbol = fromSymbol;
            this.SubId = subId;
            this.ToSymbol = toSymbol;
        }

        public string Exchange { get; set; }

        public string FromSymbol { get; set; }

        public SubId SubId { get; set; }

        public string ToSymbol { get; set; }

        public override string ToString()
        {
            return $"{this.SubId:D}~{this.Exchange}~{this.FromSymbol}~{this.ToSymbol}";
        }
    }
}

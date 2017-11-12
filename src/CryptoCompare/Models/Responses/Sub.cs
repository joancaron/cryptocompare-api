using System;

using JetBrains.Annotations;

namespace CryptoCompare
{
    public struct Sub : IEquatable<Sub>
    {
        public bool Equals(Sub other) => string.Equals(this.Exchange, other.Exchange)
                                            && string.Equals(this.FromSymbol, other.FromSymbol)
                                            && this.SubId == other.SubId 
                                            && string.Equals(this.ToSymbol, other.ToSymbol);

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }
            return obj is Sub sub && this.Equals(sub);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = this.Exchange.GetHashCode();
                hashCode = (hashCode * 397) ^ this.FromSymbol.GetHashCode();
                hashCode = (hashCode * 397) ^ (int)this.SubId;
                hashCode = (hashCode * 397) ^ this.ToSymbol.GetHashCode();
                return hashCode;
            }
        }

        public Sub([NotNull] string exchange, [NotNull] string fromSymbol, SubId subId, [NotNull] string toSymbol)
        {
            Check.NotNullOrWhiteSpace(exchange, nameof(exchange));
            Check.NotNullOrWhiteSpace(fromSymbol, nameof(fromSymbol));
            Check.NotNullOrWhiteSpace(toSymbol, nameof(toSymbol));
            this.Exchange = exchange;
            this.FromSymbol = fromSymbol;
            this.SubId = subId;
            this.ToSymbol = toSymbol;
        }

        public string Exchange { get; }

        public string FromSymbol { get; }

        public SubId SubId { get; }

        public string ToSymbol { get; }

        public override string ToString()
        {
            return $"{this.SubId:D}~{this.Exchange}~{this.FromSymbol}~{this.ToSymbol}";
        }
    }
}

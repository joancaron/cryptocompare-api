namespace CryptoCompare
{
    public class Sub
    {
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

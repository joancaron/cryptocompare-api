namespace CryptoCompare
{
    public class MiningContract : MiningData
    {
        public string ContractLength { get; set; }

        public string FeePercentage { get; set; }

        public double FeeValue { get; set; }

        public string FeeValueCurrency { get; set; }
    }
}

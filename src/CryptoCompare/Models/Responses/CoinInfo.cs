namespace CryptoCompare
{
    /// <summary>
    /// Information about the coin. (Coin list endpoint)
    /// </summary>
    public class CoinInfo
    {
        /// <summary>
        /// Gets or sets the algorithm of the coin.
        /// </summary>
        public string Algorithm { get; set; }

        /// <summary>
        /// Gets or sets the name of the coin.
        /// </summary>
        public string CoinName { get; set; }

        /// <summary>
        /// Gets or sets the full name of the coins.
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// Gets or sets the number of fully premined coins.
        /// </summary>
        /// <value>
        /// The fully premined.
        /// </value>
        public string FullyPremined { get; set; }

        /// <summary>
        /// Gets or sets the internal id, this is used in other calls.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets he logo image of the coin.
        /// </summary>
        public string ImageUrl { get; set; }

        /// <summary>
        /// Gets or sets the coin name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the pre-mined value.
        /// </summary>
        public string PreMinedValue { get; set; }

        /// <summary>
        /// Gets or sets the proof type.
        /// </summary>
        public string ProofType { get; set; }

        /// <summary>
        /// Gets the sort order.
        /// </summary>
        public int SortOrder { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the  coin is sponsored.
        /// </summary>
        public bool Sponsored { get; set; }

        /// <summary>
        /// Gets or sets the symbol.
        /// </summary>
        public string Symbol { get; set; }

        /// <summary>
        /// Gets or sets the total number of freed coins.
        /// </summary>
        public string TotalCoinsFreeFloat { get; set; }

        /// <summary>
        /// Gets or sets the total number of supplied coins.
        /// </summary>
        public string TotalCoinSupply { get; set; }

        /// <summary>
        /// Gets or sets the url of the coin on cryptocompare.
        /// </summary>
        public string Url { get; set; }
    }
}

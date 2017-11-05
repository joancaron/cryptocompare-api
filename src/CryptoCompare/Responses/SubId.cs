namespace CryptoCompare.Responses
{
    public enum SubId
    {
        /// <summary>
        /// Trade level data on a currency pair from a specific exchange.
        /// </summary>
        Trade = 0,

        /// <summary>
        /// Latest quote update of a currency pair from a specific exchange.
        /// </summary>
        Current = 2,

        /// <summary>
        /// Quote update aggregated over the last 24 hours of a currency pair from a specific exchange.
        /// </summary>
        CurrentAgg = 4
    }
}

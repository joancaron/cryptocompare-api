namespace CryptoCompare.Responses
{
    public enum CalculationType
    {
        /// <summary>
        /// The day close price.
        /// </summary>
        Close,

        /// <summary>
        /// The average between the 24 H high and low.
        /// </summary>
        MidHighLow,

        /// <summary>
        /// The total volume to / the total volume from.
        /// </summary>
        VolFVolT
    }
}

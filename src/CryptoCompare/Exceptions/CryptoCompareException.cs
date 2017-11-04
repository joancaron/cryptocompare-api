using System.Net.Http;

using CryptoCompare.Responses;

namespace CryptoCompare.Exceptions
{
    /// <summary>
    /// Global Exception for signalling cryptocompare api errors.
    /// </summary>
    /// <seealso cref="T:System.Exception"/>
    public class CryptoCompareException : HttpRequestException
    {
        /// <summary>
        /// Initializes a new instance of the CryptoCompare.Exceptions.CryptoCompareException
        /// class.
        /// </summary>
        /// <param name="apiResponseObject">The API response object.</param>
        public CryptoCompareException(BaseApiResponse apiResponseObject)
            : base($"{apiResponseObject.StatusType} - {apiResponseObject.StatusMessage}")
        {
        }
    }
}

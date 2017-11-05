using System;
using System.Net.Http;

using CryptoCompare.Helpers;
using CryptoCompare.Responses;

using JetBrains.Annotations;

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
        /// <param name="apiResponse">Reason of api failure.</param>
        public CryptoCompareException(BaseApiResponse apiResponse)
            : base(FormatErrorMessage(apiResponse))
        {
        }

        /// <summary>
        /// Initializes a new instance of the CryptoCompare.Exceptions.CryptoCompareException
        /// class.
        /// </summary>
        /// <param name="apiResponse">Reason of api failure.</param>
        /// <param name="innerException">The inner exception.</param>
        public CryptoCompareException(BaseApiResponse apiResponse, Exception innerException)
            : base(FormatErrorMessage(apiResponse), innerException)
        {
        }

        private static string FormatErrorMessage(BaseApiResponse apiResponse)
        {
            var reason = string.Empty;

            if (apiResponse != null)
            {
                reason = $"{apiResponse.StatusType} : {apiResponse.StatusMessage} {apiResponse.ErrorsSummary} => {apiResponse.Path}";
            }

            return reason;
        }
    }
}

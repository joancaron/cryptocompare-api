using System;
using System.Net.Http;

using CryptoCompare.Clients;
using CryptoCompare.Helpers;

using JetBrains.Annotations;

namespace CryptoCompare
{
    /// <summary>
    /// CryptoCompare api client.
    /// </summary>
    /// <seealso cref="T:CryptoCompare.ICryptoCompareClient"/>
    public class CryptoCompareClient : ICryptoCompareClient
    {
        private static readonly Lazy<CryptoCompareClient> Lazy =
            new Lazy<CryptoCompareClient>(() => new CryptoCompareClient());

        private readonly HttpClient _httpClient;

        private bool _isDisposed;

        /// <summary>
        /// Initializes a new instance of the CryptoCompare.CryptoCompareClient class.
        /// </summary>
        /// <param name="httpClientHandler">Custom HTTP client handler. Can be used to define proxy settigs</param>
        public CryptoCompareClient([NotNull] HttpClientHandler httpClientHandler)
        {
            Check.NotNull(httpClientHandler, nameof(httpClientHandler));
            this._httpClient = new HttpClient(httpClientHandler, true);
        }

        private CryptoCompareClient()
        {
            this._httpClient = new HttpClient();
        }

        /// <summary>
        /// Gets a Singleton instance of CryptoCompare api client.
        /// </summary>
        /// <value>
        /// The instance.
        /// </value>
        public static CryptoCompareClient Instance => Lazy.Value;

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or
        /// resetting unmanaged resources.
        /// </summary>
        /// <seealso cref="M:System.IDisposable.Dispose()"/>
        public void Dispose() => this.Dispose(true);

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or
        /// resetting unmanaged resources.
        /// </summary>
        /// <param name="disposing">True to release both managed and unmanaged resources; false to
        /// release only unmanaged resources.</param>
        internal virtual void Dispose(bool disposing)
        {
            if (!this._isDisposed)
            {
                if (disposing)
                {
                    this._httpClient?.Dispose();
                }
                this._isDisposed = true;
            }
        }

        public IRateLimitsClient RateLimits => new RateLimitsClient(this._httpClient);
    }
}

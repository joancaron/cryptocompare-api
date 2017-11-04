using System;
using System.Net.Http;
using System.Threading.Tasks;

using CryptoCompare.Exceptions;
using CryptoCompare.Helpers;
using CryptoCompare.Responses;

using JetBrains.Annotations;

using Newtonsoft.Json;

namespace CryptoCompare.Clients
{
    /// <summary>
    /// A base API client.
    /// </summary>
    public abstract class BaseApiClient
    {
        private readonly HttpClient _httpClient;

        /// <summary>
        /// Initializes a new instance of the CryptoCompare.Clients.BaseApiClient class.
        /// </summary>
        /// <param name="httpClient">The HTTP client. This cannot be null.</param>
        protected BaseApiClient([NotNull] HttpClient httpClient)
        {
            Check.NotNull(httpClient, nameof(httpClient));
            this._httpClient = httpClient;
        }

        /// <summary>
        /// Sends an api request asynchronously.
        /// </summary>
        /// <exception cref="CryptoCompareException">Thrown when a CryptoCompare api error occurs.</exception>
        /// <typeparam name="TApiResponse">Type of the API response.</typeparam>
        /// <param name="httpMethod">The HttpMethod</param>
        /// <param name="resourceUri">The resource uri path</param>
        /// <returns>
        /// The asynchronous result that yields a TApiResponse.
        /// </returns>
        protected async Task<TApiResponse> SendRequestAsync<TApiResponse>(
            HttpMethod httpMethod,
            [NotNull] Uri resourceUri)
        {
            Check.NotNull(resourceUri, nameof(resourceUri));

            var response = await this._httpClient.SendAsync(new HttpRequestMessage(httpMethod, resourceUri))
                               .ConfigureAwait(false);
            response.EnsureSuccessStatusCode();

            var apiResponseObject =
                JsonConvert.DeserializeObject<TApiResponse>(
                    await response.Content.ReadAsStringAsync().ConfigureAwait(false));

            var baseApiResponse = apiResponseObject as BaseApiResponse;
            if (baseApiResponse != null && !baseApiResponse.IsSuccessfulResponse)
            {
                throw new CryptoCompareException(baseApiResponse);
            }

            return apiResponseObject;
        }
    }
}

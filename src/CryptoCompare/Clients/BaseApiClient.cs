using System;
using System.Net.Http;
using System.Threading.Tasks;

using JetBrains.Annotations;

using Newtonsoft.Json;

namespace CryptoCompare
{
    /// <summary>
    /// A base API client.
    /// </summary>
    public abstract class BaseApiClient : IApiClient
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
        /// Sends an api request asynchronously usin GET method.
        /// </summary>
        /// <typeparam name="TApiResponse">Type of the API response.</typeparam>
        /// <param name="resourceUri">The resource uri path.</param>
        /// <returns>
        /// The asynchronous result that yields the asynchronous.
        /// </returns>
        /// <seealso cref="M:CryptoCompare.Clients.IApiClient.GetAsync{TApiResponse}(Uri)"/>
        public Task<TApiResponse> GetAsync<TApiResponse>(Uri resourceUri) =>
            this.SendRequestAsync<TApiResponse>(HttpMethod.Get, resourceUri);

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
        public async Task<TApiResponse> SendRequestAsync<TApiResponse>(HttpMethod httpMethod, [NotNull] Uri resourceUri)
        {
            Check.NotNull(resourceUri, nameof(resourceUri));

            var response = await this._httpClient.SendAsync(new HttpRequestMessage(httpMethod, resourceUri))
                               .ConfigureAwait(false);

            response.EnsureSuccessStatusCode();

            var jsonResponse = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            try
            {
                var apiResponseObject = JsonConvert.DeserializeObject<TApiResponse>(jsonResponse);

                var baseApiResponse = apiResponseObject as BaseApiResponse;
                if (baseApiResponse != null && !baseApiResponse.IsSuccessfulResponse)
                {
                    throw new CryptoCompareException(baseApiResponse);
                }

                return apiResponseObject;
            }
            catch (JsonSerializationException jsonSerializationException)
            {
                var apiErrorResponse = JsonConvert.DeserializeObject<BaseApiResponse>(jsonResponse);
                throw new CryptoCompareException(apiErrorResponse, jsonSerializationException);
            }
        }
    }
}

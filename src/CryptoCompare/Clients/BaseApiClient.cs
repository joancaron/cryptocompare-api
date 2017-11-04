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
    internal abstract class BaseApiClient
    {
        private readonly HttpClient _httpClient;

        protected BaseApiClient([NotNull] HttpClient httpClient)
        {
            Check.NotNull(httpClient, nameof(httpClient));
            this._httpClient = httpClient;
        }

        protected abstract Uri BaseUri { get; }

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
            [NotNull] string resourceUri)
            where TApiResponse : BaseApiResponse
        {
            Check.NotNull(this.BaseUri, nameof(resourceUri));
            Check.NotNullOrWhiteSpace(resourceUri, nameof(resourceUri));

            var uri = new Uri(this.BaseUri, resourceUri);

            var response = await this._httpClient.SendAsync(new HttpRequestMessage(httpMethod, uri))
                               .ConfigureAwait(false);
            response.EnsureSuccessStatusCode();

            var apiResponseObject =
                JsonConvert.DeserializeObject<TApiResponse>(
                    await response.Content.ReadAsStringAsync().ConfigureAwait(false));

            return apiResponseObject.IsSuccessfulResponse
                       ? apiResponseObject
                       : throw new CryptoCompareException(apiResponseObject);
        }
    }
}

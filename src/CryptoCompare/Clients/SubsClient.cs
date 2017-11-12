namespace CryptoCompare
{
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;

    using JetBrains.Annotations;

    public class SubsClient : BaseApiClient, ISubsClient
    {
        /// <summary>
        /// Initializes a new instance of the CryptoCompare.SubsClient class.
        /// </summary>
        /// <param name="httpClient">The HTTP client. This cannot be null.</param>
        public SubsClient([NotNull] HttpClient httpClient)
            : base(httpClient)
        {
        }

        /// <summary>
        /// Get all the available streamer subscription channels for the requested pairs.
        /// </summary>
        /// <param name="fromSymbol">from symbol.</param>
        /// <param name="toSymbols">to symbols.</param>
        /// <returns>
        /// An asynchronous result that yields the list of subs.
        /// </returns>
        /// <seealso cref="M:CryptoCompare.ISubsClient.ListAsync(string,IEnumerable{string})"/>
        public async Task<SubListResponse> ListAsync([NotNull] string fromSymbol, [NotNull] IEnumerable<string> toSymbols)
        {
            Check.NotEmpty(toSymbols, nameof(toSymbols));
            Check.NotNull(fromSymbol, nameof(fromSymbol));
            return await this.GetAsync<SubListResponse>(ApiUrls.SubsList(fromSymbol, toSymbols));
        }
    }
}
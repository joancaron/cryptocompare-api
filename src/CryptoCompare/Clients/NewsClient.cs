using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using CryptoCompareApi.News;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace CryptoCompare
{
    public class NewsClient : BaseApiClient , INewsClient
	{
        public NewsClient([NotNull] HttpClient httpClient) : base(httpClient)
	    {
	    }

		public async Task<IEnumerable<NewsProvider>> NewsProviders()
		{
		    return await base.GetAsync<IEnumerable<NewsProvider>>(ApiUrls.NewsProviders()).ConfigureAwait(false);
		}

        public async Task<IEnumerable<NewsEntity>> News(string lang = null, long? lTs = null, string[] feeds = null, bool? sign = null)
        {
            return await base.GetAsync<IEnumerable<NewsEntity>>(ApiUrls.News(lang,lTs,feeds,sign)).ConfigureAwait(false);
        }

    }
}

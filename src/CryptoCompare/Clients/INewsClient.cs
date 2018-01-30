using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CryptoCompare;

namespace CryptoCompareApi.News
{
    public interface INewsClient
    {
		/// <summary>
		/// Return all news providers.
		/// </summary>
		/// <returns></returns>
	    Task<IEnumerable<NewsProvider>> NewsProviders();
        /// <summary>
        /// Get all news 
        /// </summary>
        /// <param name="lang">Language - EN,PT etc.</param>
        /// <param name="lTs">Timestamp</param>
        /// <param name="feeds">Feeds - for news</param>
        /// <param name="sign">if true cryptocompare will sign request</param>
        /// <returns></returns>
        Task<IEnumerable<NewsEntity>> News(string lang = null, long? lTs = null, string[] feeds = null,
            bool? sign = null);

    }
}

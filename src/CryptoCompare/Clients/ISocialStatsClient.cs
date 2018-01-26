using System.Threading.Tasks;
using JetBrains.Annotations;

namespace CryptoCompare
{
    public interface ISocialStatsClient
    {
        /// <summary>
        /// Get all the available social stats for a coin.
        /// </summary>
        /// <param name="id">coin id.</param>
        /// <returns>
        /// An asynchronous result that yields an object containing the social stats.
        /// </returns>
        Task<SocialStatsResponse> StatsAsync([NotNull] int id);
    }
}

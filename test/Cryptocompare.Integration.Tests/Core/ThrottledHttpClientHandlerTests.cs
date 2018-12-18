using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

using CryptoCompare;

using Xunit;

namespace Cryptocompare.Integration.Tests.Clients
{
    public class ThrottledHttpClientHandlerTests
    {
        [Fact]
        public async Task WaitsBetweenQueries()
        {
            var throttleDelayMs = 200;
            var queriesCount = 5;

            var client = new CryptoCompareClient(throttleDelayMs: throttleDelayMs);

            var stopWatch = new Stopwatch();
            stopWatch.Start();

            await Task.WhenAll(Enumerable.Repeat("start", queriesCount)
               .Select(async _ => await client.RateLimits.CurrentHourAsync()));


            stopWatch.Stop();

            var minExpectedElapsedTime = queriesCount * throttleDelayMs;
            Assert.True(stopWatch.ElapsedMilliseconds > minExpectedElapsedTime, $"Elapsed time should have been greater than {minExpectedElapsedTime}ms, but was {stopWatch.ElapsedMilliseconds}ms.");
        }

    }
}

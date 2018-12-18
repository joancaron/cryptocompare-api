using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace CryptoCompare
{
    public class ThottledHttpClientHandler : HttpClientHandler
    {
        private readonly SemaphoreSlim _semaphore;
        private readonly int _millisecondsDelay;

        /// <summary>
        /// An <see cref="HttpClientHandler"></see> with a throttle to limit the maximum rate at which queries are sent.
        /// </summary>
        /// <param name="millisecondsDelay">The number of milliseconds to wait between calls to the base <see cref="HttpClientHandler.SendAsync"></see> method.</param>
        /// <exception cref="T:System.ArgumentOutOfRangeException">The <paramref name="millisecondsDelay">millisecondsDelay</paramref> argument is less than or equal to 0.</exception>
        public ThottledHttpClientHandler(int millisecondsDelay)
        {
            if (millisecondsDelay <= 0) throw new ArgumentOutOfRangeException(nameof(millisecondsDelay));

            _millisecondsDelay = millisecondsDelay;
            _semaphore = new SemaphoreSlim(1, 1);
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage requestMessage, CancellationToken cancellationToken)
        {
            Check.NotNull(requestMessage, nameof(requestMessage));

            await _semaphore.WaitAsync(cancellationToken);
            try
            {
                return await base.SendAsync(requestMessage, cancellationToken);
            }
            finally
            {
                await Task.Delay(_millisecondsDelay, cancellationToken);
                _semaphore.Release(1);
            }
        }
    }
}
